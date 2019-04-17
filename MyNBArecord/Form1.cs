using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net;
using System.IO;

namespace MyNBArecord
{
    public partial class MainForm : Form
    {
        //建立MYSQL 連線
        static string conn = "datasource=localhost;username=root;password=830814";
        MySqlConnection sqlconn = new MySqlConnection(conn);
        //MYSQL指令
        MySqlCommand sqlcomm;
        //接收回傳
        MySqlDataAdapter sqlAdapter;
        //回傳表格
        DataTable dt;
        //隊名LIST
        string[] teamNameC = {"暴龍", "公鹿", "溜馬", "塞爾提克", "76人", "活塞", "黃蜂", "魔術", "籃網", "熱火", "巫師", "公牛", "尼克", "老鷹", "騎士",
            "勇士", "金塊", "拓荒者", "灰熊", "快艇", "雷霆", "湖人", "鵜鶘", "國王", "馬刺", "火箭", "爵士", "灰狼", "獨行俠", "太陽"};
        string[] teamNameE = {"TOR", "MIL", "IND", "BOS", "PHI", "DET", "CHA", "ORL", "BKN", "MIA", "WAS", "CHI", "NY", "ATL", "CLE",
            "GS", "DEN", "POR", "MEM", "LAC", "OKC", "LAL", "NO", "SAC", "SA", "HOU", "UTA", "MIN", "DAL", "PHO"};
        //日期比對
        DateTime dateTime;
        int totelGame, awayGameWin, homeGameWin, awayGameLose, homeGameLose, awayHigh, homeHigh, avgPoint;
        int gameCnt = 0;
        string finalResult = "";
        string result = "";
        List<GameRecord> gameRecords = new List<GameRecord>();
        List<PictureBox> pictures = new List<PictureBox>();
        List<Label> scores = new List<Label>(), qscores = new List<Label>(), statuss = new List<Label>();
        List<Bitmap> images = new List<Bitmap>();
        bool todayOff = false , isUpdate = false;
        public MainForm()
        {
            InitializeComponent();
            addList();
            //建立網頁連結
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://www.playsport.cc/livescore.php?aid=3");
            //request.Proxy = proxy;
            WebResponse response;
            StreamReader reader;
            request.Method = "GET";
            //取得網頁回應
            response = request.GetResponse();
            //放入StreamReader
            reader = new StreamReader(response.GetResponseStream());
            //將Stream讀入字串
            result = reader.ReadToEnd();
            reader.Close();
            response.Close();
            finalResult = "";
            //取得需要的資料放入finalResult
            getMatchList();
            //顯示資料
            putInList(finalResult);
            //判斷今天比賽是否都結束
            for (int i = 0; i < gameCnt; i++)
            {
                if (gameRecords[i].Status.Equals("比賽結束 "))
                {
                    todayOff = true;    
                }
                else
                {
                    todayOff = false;
                    break;
                }
            }
            //查詢所有紀錄
            listAll();
            //判斷今日是否已新增至DB 若無新增
            if (todayOff && !isUpdate)
            {
                DialogResult a = MessageBox.Show("是否為季後賽?", "提醒", MessageBoxButtons.YesNo);
                if (a == DialogResult.Yes)
                {
                    for (int i = 0; i < gameCnt; i++)
                    {
                        AutoAdd(true,gameRecords[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < gameCnt; i++)
                    {
                        AutoAdd(false,gameRecords[i]);
                    }
                }
                
            }
            //查詢所有紀錄
            listAll();
        }

        //自動新增DB
        public void AutoAdd(bool playoffs,GameRecord gameRecord)
        {
            string sqladd = "insert into nbarecord.matchrecord(matchdate,away,awaypoint,home,homepoint) " +
                "values (date('" + DateTime.Now.ToString("yyyy-MM-dd") + "'),\"" + gameRecord.AwayName + "\"," + gameRecord.AwayScore + ",\"" 
                + gameRecord.HomeName + "\"," + gameRecord.HomeScore + ")";
            //建立 新增語法
            sqlcomm = sqlconn.CreateCommand();
            //傳入SQL新增語句
            sqlcomm.CommandText = sqladd;
            //開啟SQL
            sqlconn.Open();
            //執行語法
            sqlcomm.ExecuteNonQuery();
            if (playoffs)
            {
                string playffadd = "insert into nbarecord.playoffrecord(matchdate,away,awaypoint,home,homepoint) " +
                "values (date('" + DateTime.Now.ToString("yyyy-MM-dd") + "'),\"" + gameRecord.AwayName + "\"," + gameRecord.AwayScore + ",\""
                + gameRecord.HomeName + "\"," + gameRecord.HomeScore + ")";
                sqlcomm.CommandText = playffadd;
                sqlcomm.ExecuteNonQuery();
            }
            //關閉SQL
            sqlconn.Close();
            listAll();
        }

        //手動新增DB
        private void addRecord_Click(object sender, EventArgs e)
        {
            string sqlHomeName = "", sqlAwayName = "";
            for (int i = 0; i < teamNameC.Length; i++)
            {
                if (awayName.Text.Equals(teamNameC[i]))
                {
                    sqlAwayName = awayName.Text;
                }
                else if (homeName.Text.Equals(teamNameC[i]))
                {
                    sqlHomeName = homeName.Text;
                }
            }
            bool dateCheck = DateTime.TryParse(matchDate.Text, out dateTime);
            if (sqlHomeName.Equals("") || sqlAwayName.Equals("") || dateCheck == false)
            {
                MessageBox.Show("日期格式或隊伍名稱輸入錯誤!!!!.....", "錯誤提示!!!");
                clearInput();
            }
            else if (sqlHomeName== sqlAwayName)
            {
                MessageBox.Show("自己打自己!?!?!?!?", "錯誤提示!!!");
                clearInput();
            }
            else
            {
                if (playoffsCheck.Checked)
                {
                    string playffadd = "insert into nbarecord.playoffrecord(matchdate,away,awaypoint,home,homepoint) values (date('" + matchDate.Text + "'),\"" + sqlAwayName + "\"," + awayPoint.Text + ",\"" + sqlHomeName + "\"," + homePoint.Text + ")";
                }
                string sqladd = "insert into nbarecord.matchrecord(matchdate,away,awaypoint,home,homepoint) values (date('" + matchDate.Text + "'),\"" + sqlAwayName + "\"," + awayPoint.Text + ",\"" + sqlHomeName + "\"," + homePoint.Text + ")";
                //建立 新增語法
                sqlcomm = sqlconn.CreateCommand();
                //傳入SQL新增語句
                sqlcomm.CommandText = sqladd;
                //開啟SQL
                sqlconn.Open();
                //執行語法
                sqlcomm.ExecuteNonQuery();
                if (playoffsCheck.Checked)
                {
                    string playffadd = "insert into nbarecord.playoffrecord(matchdate,away,awaypoint,home,homepoint) values (date('" + matchDate.Text + "'),\"" + sqlAwayName + "\"," + awayPoint.Text + ",\"" + sqlHomeName + "\"," + homePoint.Text + ")";
                    sqlcomm.CommandText = playffadd;
                    sqlcomm.ExecuteNonQuery();
                }
                //關閉SQL
                sqlconn.Close();
                //清除新增輸入框
                clearInput();
                awayName.Focus();
                listAll();
            }
        }

        //查詢
        private void search_Click(object sender, EventArgs e)
        {
            clearAVG();
            string team1Name = "", team2Name = "";
            for (int i = 0; i < teamNameC.Length; i++)
            {
                if (searchName.Text.Equals(teamNameC[i]))
                {
                    team1Name = searchName.Text;
                }else if (searchName2.Text.Equals(teamNameC[i]))
                {
                    team2Name = searchName2.Text;
                }
            }
            if(!team1Name.Equals("")&& !team2Name.Equals(""))
            {
                searchMethod(team1Name, team2Name);
            }
            else if (!team1Name.Equals("")|| !team2Name.Equals(""))
            {
                if (!team1Name.Equals("")) { searchMethod(team1Name,""); }
                else { searchMethod("",team2Name); }
            }
            else { MessageBox.Show("無法查詢,請確認隊伍..."); }
        }

        //查詢方法 顯示所有資料
        public void searchMethod(string team1,string team2)
        {
            string sqlSearch = "";
            if (!(team1=="")&& !(team2 == ""))
            {
                sqlSearch = "select DATE_FORMAT(matchdate,\'%y-%m-%d\') as 對戰日, away as 客隊,awaypoint as 客隊得分,home as 主隊,homepoint as 主隊得分 " +
            "from nbarecord.matchrecord where away = \"" + team1 + "\" or home =\"" + team1 + "\"or away = \"" + team2 + "\" or home =\"" + team2 + "\" order by matchdate desc;";
            }
            else if(!(team1 == ""))
            {
                sqlSearch = "select DATE_FORMAT(matchdate,\'%y-%m-%d\') as 對戰日, away as 客隊,awaypoint as 客隊得分,home as 主隊,homepoint as 主隊得分 " +
            "from nbarecord.matchrecord where away = \"" + team1 + "\" or home =\"" + team1 + "\" order by matchdate desc;";
            }
            else if (!(team2 == ""))
            {
                sqlSearch = "select DATE_FORMAT(matchdate,\'%y-%m-%d\') as 對戰日, away as 客隊,awaypoint as 客隊得分,home as 主隊,homepoint as 主隊得分 " +
            "from nbarecord.matchrecord where away = \"" + team2 + "\" or home =\"" + team2 + "\" order by matchdate desc;";
            }

            //建立查詢 傳入查詢語句及SQL連線
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            //接收查詢回傳值
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            //建立表格
            dt = new DataTable();
            //將回傳值填入表格
            sqlAdapter.Fill(dt);
            //DataGridView 顯示表格
            dataShow.DataSource = dt;
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            if (!(team1 == ""))
            {
                homePointAVG.Text = homePointAvgMethod(team1);
                homeLoseAVG.Text = homeLoseAvgMethod(team1);
                awayPointAVG.Text = awayPointAvgMethod(team1);
                awayLoseAVG.Text = awayLoseAvgMethod(team1);
                win(1,team1);
                bigPointMethod(1,team1);
            }
            if (!(team2 == ""))
            {
                homePointAVG2.Text = homePointAvgMethod(team2);
                homeLoseAVG2.Text = homeLoseAvgMethod(team2);
                awayPointAVG2.Text = awayPointAvgMethod(team2);
                awayLoseAVG2.Text = awayLoseAvgMethod(team2);
                win(2,team2);
                bigPointMethod(2,team2);
            }
            getTenRecord(ds, team1, team2);
            changeDataColor(dataShow, team1, team2);
        }

        //取得主場平均得分
        public string homePointAvgMethod(string name)
        {
            string sqlSearch = "select round(avg(homepoint),2) from nbarecord.matchrecord where home =\"" + name + "\";";
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            //回傳表格 第一個資料表 第一行第一列 轉成字串
            return ds.Tables[0].Rows[0][0].ToString();
        }

        //取得主場平均失分
        public string homeLoseAvgMethod(string name)
        {
            string sqlSearch = "select round(avg(awaypoint),2) from nbarecord.matchrecord where home =\"" + name + "\";";
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        //取得客場平均得分
        public string awayPointAvgMethod(string name)
        {
            string sqlSearch = "select round(avg(awaypoint),2) from nbarecord.matchrecord where away =\"" + name + "\";";
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        //取得客場平均失分
        public string awayLoseAvgMethod(string name)
        {
            string sqlSearch = "select round(avg(homepoint),2) from nbarecord.matchrecord where away =\"" + name + "\";";
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        //取得主客所有場次勝負
        public void win(int who ,string name)
        {
            string sqlSearch0 = "select count(\"id\") from nbarecord.matchrecord where away = \"" + name + "\" or home=\"" + name + "\";";
            sqlcomm = new MySqlCommand(sqlSearch0, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            //取得表格第一行第一列的值後轉成INT
            totelGame = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();

            string sqlSearch1 = "select count(\"id\") from nbarecord.matchrecord where away = \"" + name + "\" and awaypoint>homepoint;";
            sqlcomm = new MySqlCommand(sqlSearch1, sqlconn);
            sqlconn.Open();
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            awayGameWin = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();

            string sqlSearch2 = "select count(\"id\") from nbarecord.matchrecord where home = \"" + name + "\" and homepoint>awaypoint;";
            sqlcomm = new MySqlCommand(sqlSearch2, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            homeGameWin = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();

            string sqlSearch3 = "select count(\"id\") from nbarecord.matchrecord where away = \"" + name + "\" and awaypoint<homepoint;";
            sqlcomm = new MySqlCommand(sqlSearch3, sqlconn);
            sqlconn.Open();
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            awayGameLose = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();

            string sqlSearch4 = "select count(\"id\") from nbarecord.matchrecord where home = \"" + name + "\" and homepoint<awaypoint;";
            sqlcomm = new MySqlCommand(sqlSearch4, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            homeGameLose = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();
            switch (who)
            {
                case 1:
                    gameWin.Text = (awayGameWin + homeGameWin).ToString();
                    gameLose.Text = (totelGame - (awayGameWin + homeGameWin)).ToString();
                    awayWin.Text = awayGameWin.ToString();
                    homeWin.Text = homeGameWin.ToString();
                    awayLose.Text = awayGameLose.ToString();
                    homeLose.Text = homeGameLose.ToString();
                    break;
                case 2:
                    gameWin2.Text = (awayGameWin + homeGameWin).ToString();
                    gameLose2.Text = (totelGame - (awayGameWin + homeGameWin)).ToString();
                    awayWin2.Text = awayGameWin.ToString();
                    homeWin2.Text = homeGameWin.ToString();
                    awayLose2.Text = awayGameLose.ToString();
                    homeLose2.Text = homeGameLose.ToString();
                    break;
            }
        }

        //計算大於100場次及機率
        public void bigPointMethod(int who, string name)
        {
            string sqlSearch0 = "select count(\"awaypoint\") from nbarecord.matchrecord where away = \"" + name + "\" and awaypoint>100;";
            sqlcomm = new MySqlCommand(sqlSearch0, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            awayHigh = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();

            string sqlSearch1 = "select count(\"homepoint\") from nbarecord.matchrecord where home = \"" + name + "\" and homepoint>100;";
            sqlcomm = new MySqlCommand(sqlSearch1, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            homeHigh = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();

            string sqlSearch2 = "select avg(awaypoint+homepoint) from nbarecord.matchrecord where home = \"" + name + "\" or away = \"" + name + "\"";
            sqlcomm = new MySqlCommand(sqlSearch2, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            avgPoint = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();

            switch (who)
            {
                case 1:
                    awayBig.Text = awayHigh.ToString();
                    //  ( (轉成浮點術後計算) *100)轉成字串並四捨五入到第二位 + %
                    awayBigChance.Text = (((float)awayHigh / (float)(int.Parse(awayWin.Text) + int.Parse(awayLose.Text))) * 100).ToString("f2") + "%";
                    homeBig.Text = homeHigh.ToString();
                    homeBigChance.Text = (((float)homeHigh / (float)(int.Parse(homeWin.Text) + int.Parse(homeLose.Text))) * 100).ToString("f2") + "%";
                    avgTotalPoint.Text = avgPoint.ToString("f2");
                    break;
                case 2:
                    awayBig2.Text = awayHigh.ToString();
                    awayBigChance2.Text = (((float)awayHigh / (float)(int.Parse(awayWin2.Text) + int.Parse(awayLose2.Text))) * 100).ToString("f2") + "%";
                    homeBig2.Text = homeHigh.ToString();
                    homeBigChance2.Text = (((float)homeHigh / (float)(int.Parse(homeWin2.Text) + int.Parse(homeLose2.Text))) * 100).ToString("f2") + "%";
                    avgTotalPoint2.Text = avgPoint.ToString("f2");
                    break;
            }
            
        }
        
        //近十場戰績
        public void getTenRecord(DataSet ds, string team1 ,string team2)
        {
            string[] record = { "", "", "", "" };
            int row = 0;
            int[] getCount = { 0, 0 };
            while (true)
            {
                if (ds.Tables[0].Rows[row][1].ToString().Equals(team1) && team1 != "")
                {
                    if (Convert.ToInt16(ds.Tables[0].Rows[row][2]) > Convert.ToInt16(ds.Tables[0].Rows[row][4]))
                    {
                        record[0] = "W";
                        if (record[1] == "") { record[1] = "W"; }
                    }
                    else
                    {
                        record[0] = "L";
                        if (record[1] == "") { record[1] = "L"; }
                    }
                    if(record[1]!= record[0]) { team1=""; } else { getCount[0]++; }
                }
                else if (ds.Tables[0].Rows[row][3].ToString().Equals(team1) && team1 != "")
                {
                    if (Convert.ToInt16(ds.Tables[0].Rows[row][2]) < Convert.ToInt16(ds.Tables[0].Rows[row][4]))
                    {
                        record[0] = "W";
                        if (record[1] == "") { record[1] = "W"; }
                    }
                    else
                    {
                        record[0] = "L";
                        if (record[1] == "") { record[1] = "L"; }
                    }
                    if (record[1] != record[0]) { team1=""; } else { getCount[0]++; }
                }
                if (ds.Tables[0].Rows[row][1].ToString().Equals(team2) && team2 != "")
                {
                    if (Convert.ToInt16(ds.Tables[0].Rows[row][2]) > Convert.ToInt16(ds.Tables[0].Rows[row][4]))
                    {
                        record[2] = "W";
                        if (record[3] == "") { record[3] = "W"; }
                    }
                    else
                    {
                        record[2] = "L";
                        if (record[3] == "") { record[3] = "L"; }
                    }
                    
                    if (record[3] != record[2]) { team2=""; } else { getCount[1]++; }
                }
                else if (ds.Tables[0].Rows[row][3].ToString().Equals(team2) && team2 != "")
                {
                    if (Convert.ToInt16(ds.Tables[0].Rows[row][2]) < Convert.ToInt16(ds.Tables[0].Rows[row][4]))
                    {
                        record[2] = "W";
                        if (record[3] == "") { record[3] = "W"; }
                    }
                    else
                    {
                        record[2] = "L";
                        if (record[3] == "") { record[3] = "L"; }
                    }
                    if (record[3] != record[2]) { team2 = ""; } else { getCount[1]++; }
                }
                if (team1 == "" && team2 == "") { break; }
                row++;
            }
            tenRecord.Text = record[1] + getCount[0];
            tenRecord2.Text = record[3] + getCount[1];
        }
        
        //變換表格隊伍顏色
        public void changeDataColor(DataGridView dataGridView, string team1,string team2)
        {

            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                string away = dataGridView.Rows[i].Cells[1].Value.ToString();
                string home = dataGridView.Rows[i].Cells[3].Value.ToString();
                if (away.Equals(team1))
                {
                    dataGridView.Rows[i].Cells[1].Style.BackColor = Color.LightGreen;
                }
                else if (home.Equals(team1))
                {
                    dataGridView.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                }
                if (away.Equals(team2))
                {
                    dataGridView.Rows[i].Cells[1].Style.BackColor = Color.Violet;
                }
                else if (home.Equals(team2))
                {
                    dataGridView.Rows[i].Cells[3].Style.BackColor = Color.Violet;
                }
            }
            dataGridView.Refresh();
        }
        
        //重新整理
        private void button1_Click(object sender, EventArgs e)
        {
            //建立網頁連結
            WebRequest request = WebRequest.Create(@"https://www.playsport.cc/livescore.php?aid=3");
            WebResponse response;
            StreamReader reader;
            request.Method = "GET";
            //取得網頁回應
            response = request.GetResponse();
            //放入StreamReader
            reader = new StreamReader(response.GetResponseStream());
            //將Stream讀入字串
            result = reader.ReadToEnd();
            reader.Close();
            response.Close();
            finalResult = "";
            //取得需要的資料放入finalResult
            getMatchList();
            //放入ListBox
            putInList(finalResult);
        }

        //取得DB清單 並判斷日期是否為最新
        public void listAll()
        {
            // DATE_FORMAT( 日期 , 返回(月份-日期) )
            string sqlSearch = "select DATE_FORMAT(matchdate,\'%y-%m-%d\') as 對戰日, away as 客隊,awaypoint as 客隊得分,home as 主隊,homepoint as 主隊得分 " +
            "from nbarecord.matchrecord order by matchdate desc";
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            dt = new DataTable();
            sqlAdapter.Fill(dt);
            dataShow.DataSource = dt;
            string compareDate = dataShow.Rows[0].Cells[0].Value.ToString();
            string DateNow = DateTime.Now.ToString("yy-MM-dd");
            isUpdate = compareDate.Equals(DateNow);
            clearAVG();
        }

        //清空新增畫面輸入框
        public void clearInput()
        {
            awayName.Text = "";
            awayPoint.Text = "";
            homeName.Text = "";
            homePoint.Text = "";
        }

        //清空查詢數據
        public void clearAVG()
        {
            homePointAVG.Text = "";
            homeLoseAVG.Text = "";
            awayPointAVG.Text = "";
            awayLoseAVG.Text = "";
            gameWin.Text = "";
            gameLose.Text = "";
            homeWin.Text = "";
            homeLose.Text = "";
            awayWin.Text = "";
            awayLose.Text = "";
            homeBig.Text = "";
            homeBigChance.Text = "";
            awayBig.Text = "";
            awayBigChance.Text = "";
            avgTotalPoint.Text = "";
            tenRecord.Text = "";
            homePointAVG2.Text = "";
            homeLoseAVG2.Text = "";
            awayPointAVG2.Text = "";
            awayLoseAVG2.Text = "";
            gameWin2.Text = "";
            gameLose2.Text = "";
            homeWin2.Text = "";
            homeLose2.Text = "";
            awayWin2.Text = "";
            awayLose2.Text = "";
            homeBig2.Text = "";
            homeBigChance2.Text = "";
            awayBig2.Text = "";
            awayBigChance2.Text = "";
            avgTotalPoint2.Text = "";
            tenRecord2.Text = "";
        }

        //ListAll
        private void allMatch_Click(object sender, EventArgs e)
        {
            listAll();
        }


        public void finalADD(string key, int get, string endSign)
        {
            int position = result.IndexOf(key);
            result = result.Remove(0, position + key.Length);
            finalResult += result.Substring(0, get) + endSign;
        }

        //取得網頁整理資料到finalResult
        public void getMatchList()
        {
            string dateTime = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
            string compare = "\"NBA_" + dateTime + "_";
            string timeFix1 = "", timeFix2 = "";
            string[] compareList = { compare, "_asr_big\">" , "_inning_big\">" , "_trm_big\">" , "_hsr_big\">" , "_as1\">" ,
            "_as2\">","_as3\">","_as4\">","_as5\">","_hs1\">","_hs2\">","_hs3\">","_hs4\">","_hs5\">"};
            int[] divide = new int[13];

            while (divide[0] != -1)
            {
                //取得對戰隊伍
                divide[0] = result.IndexOf(compareList[0]);
                if (divide[0] == -1) { break; }
                result = result.Remove(0, divide[0] + compareList[0].Length);
                finalResult += result.Substring(0, 7) + "\n";
                //取得客隊分數
                finalADD(compareList[1], 3, " : ");
                //取得比賽時間(節)
                divide[1] = result.IndexOf(compareList[2]);
                result = result.Remove(0, divide[1] + compareList[2].Length);
                timeFix1 = result.Substring(0, 75).Replace(" ", "");
                timeFix1 = timeFix1.Replace("\n", "");
                //取得比賽時間(分秒)
                divide[2] = result.IndexOf(compareList[3]);
                result = result.Remove(0, divide[2] + compareList[3].Length);
                timeFix2 = result.Substring(0, 80).Replace(" ", "");
                timeFix2 = timeFix2.Replace("\n", "");
                //取得主隊分數
                finalADD(compareList[4], 3, "\n");

                finalResult += timeFix1 + " " + timeFix2 + "\n";
                //取得客隊第一節
                divide[3] = result.IndexOf(compareList[5]);
                result = result.Remove(0, divide[3] + compareList[5].Length);
                if (result.Substring(0, 2).Contains("<")) { finalResult += "  " + result.Substring(0, 1) + "-"; }
                else
                {
                    finalResult += result.Substring(0, 2) + "-";
                }
                //取得客隊第二節
                divide[4] = result.IndexOf(compareList[6]);
                result = result.Remove(0, divide[4] + compareList[6].Length);
                if (result.Substring(0, 2).Contains("<")) { finalResult += "  " + result.Substring(0, 1) + "-"; }
                else
                {
                    finalResult += result.Substring(0, 2) + "-";
                }
                //取得客隊第三節
                divide[5] = result.IndexOf(compareList[7]);
                result = result.Remove(0, divide[5] + compareList[7].Length);
                if (result.Substring(0, 2).Contains("<")) { finalResult += "  " + result.Substring(0, 1) + "-"; }
                else
                {
                    finalResult += result.Substring(0, 2) + "-";
                }
                //取得客隊第四節
                divide[6] = result.IndexOf(compareList[8]);
                result = result.Remove(0, divide[6] + compareList[8].Length);
                if (result.Substring(0, 2).Contains("<")) { finalResult += "  " + result.Substring(0, 1) + "-"; }
                else
                {
                    finalResult += result.Substring(0, 2) + "-";
                }
                //取得客隊OT
                divide[7] = result.IndexOf(compareList[9]);
                result = result.Remove(0, divide[7] + compareList[9].Length);
                if (result.Substring(0, 2) != "</")
                {
                    if (result.Substring(0, 2).Contains("<")) { finalResult += "  " + result.Substring(0, 1) + "\n"; }
                    else
                    {
                        finalResult += result.Substring(0, 2) + "\n";
                    }
                }
                else
                {
                    finalResult = finalResult.Remove(finalResult.Length - 1, 1);
                    finalResult += "\n";
                }
                //取得主隊第一節
                divide[8] = result.IndexOf(compareList[10]);
                result = result.Remove(0, divide[8] + compareList[10].Length);
                if (result.Substring(0, 2).Contains("<")) { finalResult += "  " + result.Substring(0, 1) + "-"; }
                else
                {
                    finalResult += result.Substring(0, 2) + "-";
                }
                //取得主隊第二節
                divide[9] = result.IndexOf(compareList[11]);
                result = result.Remove(0, divide[9] + compareList[11].Length);
                if (result.Substring(0, 2).Contains("<")) { finalResult += "  " + result.Substring(0, 1) + "-"; }
                else
                {
                    finalResult += result.Substring(0, 2) + "-";
                }
                //取得主隊第三節
                divide[10] = result.IndexOf(compareList[12]);
                result = result.Remove(0, divide[10] + compareList[12].Length);
                if (result.Substring(0, 2).Contains("<")) { finalResult += "  " + result.Substring(0, 1) + "-"; }
                else
                {
                    finalResult += result.Substring(0, 2) + "-";
                }
                //取得主隊第四節
                divide[11] = result.IndexOf(compareList[13]);
                result = result.Remove(0, divide[11] + compareList[13].Length);
                if (result.Substring(0, 2).Contains("<")) { finalResult += "  " + result.Substring(0, 1) + "-"; }
                else
                {
                    finalResult += result.Substring(0, 2) + "-";
                }
                //取得主隊OT
                divide[12] = result.IndexOf(compareList[14]);
                result = result.Remove(0, divide[12] + compareList[14].Length);
                if (result.Substring(0, 2) != "</")
                {
                    if (result.Substring(0, 2).Contains("<")) { finalResult += "  " + result.Substring(0, 1) + "\n"; }
                    else
                    {
                        finalResult += result.Substring(0, 2) + "\n";
                    }
                }
                else
                {
                    finalResult = finalResult.Remove(finalResult.Length - 1, 1);
                    finalResult += "\n";
                }
            }
            finalResult = finalResult.Replace("\"", "");
            finalResult = finalResult.Replace("<", "");
        }

        //解字串 放置圖片.狀態.比數.單節得分
        public void putInList(string final)
        {
            int div1 = 0, div2 = 0;
            while (div1 != -1)
            {
                div1 = final.IndexOf("@");
                if (div1 == -1) { break; }
                string awayName = final.Substring(0, div1);
                pictures[gameCnt].Image = findBitmap(awayName);
                final = final.Remove(0, div1 + 1);

                div2 = final.IndexOf("\n");
                string homeName = final.Substring(0, div2);
                pictures[gameCnt + 20].Image = findBitmap(homeName);
                final = final.Remove(0, div2 + 1);

                div2 = final.IndexOf(" : ");
                string awayPoint = final.Substring(0, div2);
                final = final.Remove(0, div2 + 3);

                div2 = final.IndexOf("\n");
                string homePoint = final.Substring(0, div2);
                final = final.Remove(0, div2 + 1);

                div2 = final.IndexOf("\n");
                string stutes = final.Substring(0, div2).Replace("/span>", "");
                final = final.Remove(0, div2 + 1);

                div2 = final.IndexOf("\n");
                string awayQpoint = final.Substring(0, div2).Replace("/", " ");
                final = final.Remove(0, div2 + 1);

                div2 = final.IndexOf("\n");
                string homeQpoint = final.Substring(0, div2).Replace("/", " ");
                final = final.Remove(0, div2 + 1);

                statuss[gameCnt].Text = stutes;
                scores[gameCnt].Text = awayPoint + " : " + homePoint;
                qscores[gameCnt * 2].Text = awayQpoint;
                qscores[(gameCnt * 2) + 1].Text = homeQpoint;
                gameCnt++;

                gameRecords.Add(new GameRecord(changeENGtoCH(awayName), changeENGtoCH(homeName), stutes, awayPoint, homePoint, awayQpoint, homeQpoint));
            }
        }

        //元件加入List
        public void addList()
        {
            pictures.Add(pictureBox1); pictures.Add(pictureBox2); pictures.Add(pictureBox3); pictures.Add(pictureBox4); pictures.Add(pictureBox5);
            pictures.Add(pictureBox6); pictures.Add(pictureBox7); pictures.Add(pictureBox8); pictures.Add(pictureBox9); pictures.Add(pictureBox10);
            pictures.Add(pictureBox11); pictures.Add(pictureBox12); pictures.Add(pictureBox13); pictures.Add(pictureBox14); pictures.Add(pictureBox15);
            pictures.Add(pictureBox16); pictures.Add(pictureBox17); pictures.Add(pictureBox18); pictures.Add(pictureBox19); pictures.Add(pictureBox20);
            pictures.Add(pictureBox21); pictures.Add(pictureBox22); pictures.Add(pictureBox23); pictures.Add(pictureBox24); pictures.Add(pictureBox25);
            pictures.Add(pictureBox26); pictures.Add(pictureBox27); pictures.Add(pictureBox28); pictures.Add(pictureBox29); pictures.Add(pictureBox30);
            pictures.Add(pictureBox31); pictures.Add(pictureBox32); pictures.Add(pictureBox33); pictures.Add(pictureBox34); pictures.Add(pictureBox35);
            pictures.Add(pictureBox36); pictures.Add(pictureBox37); pictures.Add(pictureBox38); pictures.Add(pictureBox39); pictures.Add(pictureBox40);
            for(int i = 0; i < pictures.Count; i++) { pictures[i].Image = null;pictures[i].SizeMode = PictureBoxSizeMode.StretchImage; }
            scores.Add(score1); scores.Add(score2); scores.Add(score3); scores.Add(score4); scores.Add(score5);
            scores.Add(score6); scores.Add(score7); scores.Add(score8); scores.Add(score9); scores.Add(score10);
            scores.Add(score11); scores.Add(score12); scores.Add(score13); scores.Add(score14); scores.Add(score15);
            scores.Add(score16); scores.Add(score17); scores.Add(score18); scores.Add(score19); scores.Add(score20);
            for (int i = 0; i < scores.Count; i++) { scores[i].Text = ""; }
            qscores.Add(qs1); qscores.Add(qs2); qscores.Add(qs3); qscores.Add(qs4); qscores.Add(qs5); qscores.Add(qs6); qscores.Add(qs7); qscores.Add(qs8); qscores.Add(qs9); qscores.Add(qs10);
            qscores.Add(qs11); qscores.Add(qs12); qscores.Add(qs13); qscores.Add(qs14); qscores.Add(qs15); qscores.Add(qs16); qscores.Add(qs17); qscores.Add(qs18); qscores.Add(qs19); qscores.Add(qs20);
            qscores.Add(qs21); qscores.Add(qs22); qscores.Add(qs23); qscores.Add(qs24); qscores.Add(qs25); qscores.Add(qs26); qscores.Add(qs27); qscores.Add(qs28); qscores.Add(qs29); qscores.Add(qs30);
            qscores.Add(qs31); qscores.Add(qs32); qscores.Add(qs33); qscores.Add(qs34); qscores.Add(qs35); qscores.Add(qs36); qscores.Add(qs37); qscores.Add(qs38); qscores.Add(qs39); qscores.Add(qs40);
            for (int i = 0; i < qscores.Count; i++) { qscores[i].Text = ""; }
            statuss.Add(label_status1); statuss.Add(label_status2); statuss.Add(label_status3); statuss.Add(label_status4); statuss.Add(label_status5);
            statuss.Add(label_status6); statuss.Add(label_status7); statuss.Add(label_status8); statuss.Add(label_status9); statuss.Add(label_status10);
            statuss.Add(label_status11); statuss.Add(label_status12); statuss.Add(label_status13); statuss.Add(label_status14); statuss.Add(label_status15);
            statuss.Add(label_status16); statuss.Add(label_status17); statuss.Add(label_status18); statuss.Add(label_status19); statuss.Add(label_status20);
            for (int i = 0; i < statuss.Count; i++) { statuss[i].Text = ""; }
            images.Add(Properties.Resources.TOR); images.Add(Properties.Resources.MIL); images.Add(Properties.Resources.IND); images.Add(Properties.Resources.BOS); images.Add(Properties.Resources.PHI);
            images.Add(Properties.Resources.DET); images.Add(Properties.Resources.CHA); images.Add(Properties.Resources.ORL); images.Add(Properties.Resources.BKN); images.Add(Properties.Resources.MIA);
            images.Add(Properties.Resources.WAS); images.Add(Properties.Resources.CHI); images.Add(Properties.Resources.NY); images.Add(Properties.Resources.ATL); images.Add(Properties.Resources.CLE);
            images.Add(Properties.Resources.GS); images.Add(Properties.Resources.DEN); images.Add(Properties.Resources.POR); images.Add(Properties.Resources.MEM); images.Add(Properties.Resources.LAC);
            images.Add(Properties.Resources.OKC); images.Add(Properties.Resources.LAL); images.Add(Properties.Resources.NO); images.Add(Properties.Resources.SAC); images.Add(Properties.Resources.SA);
            images.Add(Properties.Resources.HOU); images.Add(Properties.Resources.UTA); images.Add(Properties.Resources.MIN); images.Add(Properties.Resources.DAL); images.Add(Properties.Resources.PHO);
        }

        //傳英隊名回傳圖片
        public Bitmap findBitmap(string teamName)
        {

            Bitmap ret = null;
            for (int i=0;i<30;i++)
            {
                if (teamName == teamNameE[i])
                {
                    ret = images[i];
                    break;
                }
            }
            return ret;
        }

        //傳英隊名回傳中隊名
        public string changeENGtoCH(string match)
        {
            for (int i = 0; i < teamNameC.Length; i++)
            {
                match = match.Replace(teamNameE[i], teamNameC[i]);
            }
            return match;
        }
    }
}

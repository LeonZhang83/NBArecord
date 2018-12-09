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
        String[] teamName = {"暴龍", "公鹿", "溜馬", "塞爾提克", "76人", "活塞", "黃蜂", "魔術", "籃網", "熱火", "巫師", "公牛", "尼克", "老鷹", "騎士",
            "勇士", "金塊", "拓荒者", "灰熊", "快艇", "雷霆", "湖人", "鵜鶘", "國王", "馬刺", "火箭", "爵士", "灰狼", "獨行俠", "太陽"};
        //日期比對
        DateTime dateTime;
        int totelGame, awayGameWin, homeGameWin, awayGameLose, homeGameLose, awayHigh, homeHigh, avgPoint;
        string finalResult = "";
        string result = "";
        string[] awayNameList = new string[20], homeNameList = new string[20], stutes = new string[20],
            awayPointList = new string[20], homePointList = new string[20], awayQpoint = new string[20], homeQpoint = new string[20];

        public MainForm()
        {
            InitializeComponent();
            //查詢所有紀錄
            listAll();
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
            //轉換中文及去除無效字元
            finalResult = changeENGtoCH(finalResult);
            //放入ListBox
            putInList(finalResult);

        }

        private void addRecord_Click(object sender, EventArgs e)
        {
            string sqlHomeName = "", sqlAwayName = "";
            for (int i = 0; i < teamName.Length; i++)
            {
                if (awayName.Text.Equals(teamName[i]))
                {
                    sqlAwayName = awayName.Text;
                }
                else if (homeName.Text.Equals(teamName[i]))
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
            else
            {
                string sqladd = "insert into nbarecord.matchrecord(matchdate,away,awaypoint,home,homepoint) values (date('" + matchDate.Text + "'),\"" + sqlAwayName + "\"," + awayPoint.Text + ",\"" + sqlHomeName + "\"," + homePoint.Text + ")";
                //建立 新增語法
                sqlcomm = sqlconn.CreateCommand();
                //傳入SQL新增語句
                sqlcomm.CommandText = sqladd;
                //開啟SQL
                sqlconn.Open();
                //執行語法
                sqlcomm.ExecuteNonQuery();
                //關閉SQL
                sqlconn.Close();
                //清除新增輸入框
                clearInput();
                awayName.Focus();
                listAll();
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            String sqlName = "";
            for (int i = 0; i < teamName.Length; i++)
            {
                if (searchName.Text.Equals(teamName[i]))
                {
                    sqlName = searchName.Text;
                }
            }
            if (!sqlName.Equals("")) { searchMethod(sqlName); }
        }

        public void searchMethod(string name)
        {
            string sqlSearch = "select DATE_FORMAT(matchdate,\'%y-%m-%d\') as 對戰日, away as 客隊,awaypoint as 客隊得分,home as 主隊,homepoint as 主隊得分 " +
            "from nbarecord.matchrecord where away = \"" + name + "\" or home =\"" + name + "\" order by matchdate desc;";
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

            homePointAVG.Text = homePointAvgMethod(name);
            homeLoseAVG.Text = homeLoseAvgMethod(name);
            awayPointAVG.Text = awayPointAvgMethod(name);
            awayLoseAVG.Text = awayLoseAvgMethod(name);
            win(name);
            bigPointMethod(name);
            getTenRecord(ds, name);
            changeDataColor(dataShow, name);
        }

        public void win(string name)
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

            gameWin.Text = (awayGameWin + homeGameWin).ToString();
            gameLose.Text = (totelGame - (awayGameWin + homeGameWin)).ToString();
            awayWin.Text = awayGameWin.ToString();
            homeWin.Text = homeGameWin.ToString();
            awayLose.Text = awayGameLose.ToString();
            homeLose.Text = homeGameLose.ToString();

        }

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

        public string homeLoseAvgMethod(string name)
        {
            string sqlSearch = "select round(avg(awaypoint),2) from nbarecord.matchrecord where home =\"" + name + "\";";
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        public string awayPointAvgMethod(string name)
        {
            string sqlSearch = "select round(avg(awaypoint),2) from nbarecord.matchrecord where away =\"" + name + "\";";
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        public string awayLoseAvgMethod(string name)
        {
            string sqlSearch = "select round(avg(homepoint),2) from nbarecord.matchrecord where away =\"" + name + "\";";
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

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
            //轉換中文及去除無效字元
            finalResult = changeENGtoCH(finalResult);
            //放入ListBox
            putInList(finalResult);
        }

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
            //dateGridViewChangeColor();
            clearAVG();
        }

        public void clearInput()
        {
            awayName.Text = "";
            awayPoint.Text = "";
            homeName.Text = "";
            homePoint.Text = "";
        }

        public void clearAVG()
        {
            searchName.Text = "";
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
        }

        public void bigPointMethod(string name)
        {
            string sqlSearch0 = "select count(\"awaypoint\") from nbarecord.matchrecord where away = \"" + name + "\" and awaypoint>100;";
            sqlcomm = new MySqlCommand(sqlSearch0, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            awayHigh = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();
            awayBig.Text = awayHigh.ToString();
            //  ( (轉成浮點術後計算) *100)轉成字串並四捨五入到第二位 + %
            awayBigChance.Text = (((float)awayHigh / (float)(awayGameWin + awayGameLose)) * 100).ToString("f2") + "%";

            string sqlSearch1 = "select count(\"homepoint\") from nbarecord.matchrecord where home = \"" + name + "\" and homepoint>100;";
            sqlcomm = new MySqlCommand(sqlSearch1, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            homeHigh = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();
            homeBig.Text = homeHigh.ToString();
            homeBigChance.Text = (((float)homeHigh / (float)(homeGameWin + homeGameLose)) * 100).ToString("f2") + "%";

            string sqlSearch2 = "select avg(awaypoint+homepoint) from nbarecord.matchrecord where home = \"" + name + "\" or away = \"" + name + "\"";
            sqlcomm = new MySqlCommand(sqlSearch2, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            avgPoint = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();
            avgTotalPoint.Text = avgPoint.ToString("f2");

        }

        private void allMatch_Click(object sender, EventArgs e)
        {
            listAll();
        }

        public void getTenRecord(DataSet ds, String name)
        {
            String record = "";
            for (int i = 0; i < 10; i++)
            {
                if (ds.Tables[0].Rows[i][1].ToString().Equals(name))
                {
                    if (Convert.ToInt16(ds.Tables[0].Rows[i][2]) > Convert.ToInt16(ds.Tables[0].Rows[i][4]))
                    {
                        record += "W ";
                    }
                    else
                    {
                        record += "L ";
                    }
                }
                else
                {
                    if (Convert.ToInt16(ds.Tables[0].Rows[i][2]) > Convert.ToInt16(ds.Tables[0].Rows[i][4]))
                    {
                        record += "L ";
                    }
                    else
                    {
                        record += "W ";
                    }
                }
            }
            tenRecord.Text = record;
        }

        public void changeDataColor(DataGridView dataGridView, string name)
        {

            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                String away = dataGridView.Rows[i].Cells[1].Value.ToString();
                String home = dataGridView.Rows[i].Cells[3].Value.ToString();
                if (away.Equals(name))
                {
                    dataGridView.Rows[i].Cells[1].Style.BackColor = Color.SteelBlue;
                }
                else if (home.Equals(name))
                {
                    dataGridView.Rows[i].Cells[3].Style.BackColor = Color.SteelBlue;
                }
            }
            dataGridView.Refresh();
        }

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

        public string changeENGtoCH(string match)
        {

            string[] teamNameE = {"TOR", "MIL", "IND", "BOS", "PHI", "DET", "CHA", "ORL", "BKN", "MIA", "WAS", "CHI", "NY", "ATL", "CLE",
            "GS", "DEN", "POR", "MEM", "LAC", "OKC", "LAL", "NO", "SAC", "SA", "HOU", "UTA", "MIN", "DAL", "PHO"};
            string[] teamNameC = {"暴龍", "公鹿", "溜馬", "塞爾提克", "76人", "活塞", "黃蜂", "魔術", "籃網", "熱火", "巫師", "公牛", "尼克", "老鷹", "騎士",
            "勇士", "金塊", "拓荒者", "灰熊", "快艇", "雷霆", "湖人", "鵜鶘", "國王", "馬刺", "火箭", "爵士", "灰狼", "獨行俠", "太陽"};
            for (int i = 0; i < teamNameC.Length; i++)
            {
                match = match.Replace(teamNameE[i], teamNameC[i]);
            }
            match = match.Replace("@", "(客)對(主)");
            return match;
        }

        public void putInList(string final)
        {
            string listName = final;
            gameToday.Items.Clear();
            int div1 = 0, div2 = 0;
            int gameCnt = 0;
            while (div1 != -1)
            {
                div1 = final.IndexOf("(客)對(主)");
                if (div1 == -1) { break; }
                awayNameList[gameCnt] = final.Substring(0, div1);
                final = final.Remove(0, div1 + 7);

                div2 = final.IndexOf("\n");
                homeNameList[gameCnt] = final.Substring(0, div2);
                final = final.Remove(0, div2 + 1);

                div2 = final.IndexOf(" : ");
                awayPointList[gameCnt] = final.Substring(0, div2);
                final = final.Remove(0, div2 + 3);

                div2 = final.IndexOf("\n");
                homePointList[gameCnt] = final.Substring(0, div2);
                final = final.Remove(0, div2 + 1);

                div2 = final.IndexOf("\n");
                stutes[gameCnt] = final.Substring(0, div2).Replace("/span>", "");
                final = final.Remove(0, div2 + 1);

                div2 = final.IndexOf("\n");
                awayQpoint[gameCnt] = final.Substring(0, div2).Replace("/", " ");
                final = final.Remove(0, div2 + 1);

                div2 = final.IndexOf("\n");
                homeQpoint[gameCnt] = final.Substring(0, div2).Replace("/", " ");
                final = final.Remove(0, div2 + 1);

                gameToday.Items.Add(stutes[gameCnt]);
                gameToday.Items.Add("(客) " + awayNameList[gameCnt] + " : " + homeNameList[gameCnt] + " (主)");
                gameToday.Items.Add("(客) " + awayPointList[gameCnt] + " : " + homePointList[gameCnt] + " (主)");
                gameToday.Items.Add("(客)" + awayQpoint[gameCnt]);
                gameToday.Items.Add("(主)" + homeQpoint[gameCnt]);
                gameToday.Items.Add(" ");
                gameCnt++;
            }
        }

        public void finalADD(string key, int get, string endSign)
        {
            int position = result.IndexOf(key);
            result = result.Remove(0, position + key.Length);
            finalResult += result.Substring(0, get) + endSign;
        }


    }
}

﻿using System;
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

        int totelGame, awayGameWin, homeGameWin, awayGameLose, homeGameLose, awayHigh, homeHigh,avgPoint;

        public MainForm()
        {
            InitializeComponent();
            //查詢所有紀錄
            listAll();
            
        }

        private void addRecord_Click(object sender, EventArgs e)
        {
            string sqladd = "insert into nbarecord.matchrecord(matchdate,away,awaypoint,home,homepoint) values (date('" + matchDate.Text + "'),\"" + awayName.Text + "\"," + awayPoint.Text + ",\"" + homeName.Text + "\"," + homePoint.Text + ")";
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

        private void search_Click(object sender, EventArgs e)
        {
            searchMethod(searchName.Text);
        }

        public void searchMethod(string name)
        {
            string sqlSearch = "select DATE_FORMAT(matchdate,\'%m-%d\') as 對戰日, away as 客隊,awaypoint as 客隊得分,home as 主隊,homepoint as 主隊得分 " +
            "from nbarecord.matchrecord where away = \"" +name + "\" or home =\"" + name + "\" order by matchdate desc;";
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
            //dateGridViewChangeColor();

            homePointAVG.Text = homePointAvgMethod(name);
            homeLoseAVG.Text = homeLoseAvgMethod(name);
            awayPointAVG.Text = awayPointAvgMethod(name);
            awayLoseAVG.Text = awayLoseAvgMethod(name);
            win(name);
            bigPointMethod(name);
        }

        public void win(string name)
        {

            string sqlSearch0 = "select count(\"id\") from nbarecord.matchrecord where away = \"" + name + "\" or home=\"" + name + "\";";
            sqlcomm = new MySqlCommand(sqlSearch0, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            //取得表格第一行第一列的值後轉成INT
            totelGame =Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();

            string sqlSearch1 = "select count(\"id\") from nbarecord.matchrecord where away = \""+name+"\" and awaypoint>homepoint;";
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

        public void listAll()
        {
            // DATE_FORMAT( 日期 , 返回(月份-日期) )
            string sqlSearch = "select DATE_FORMAT(matchdate,\'%m-%d\') as 對戰日, away as 客隊,awaypoint as 客隊得分,home as 主隊,homepoint as 主隊得分 " +
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
            awayBigChance.Text = (((float)awayHigh / (float)(awayGameWin + awayGameLose))*100).ToString("f2")+"%";

            string sqlSearch1 = "select count(\"homepoint\") from nbarecord.matchrecord where home = \"" + name + "\" and homepoint>100;";
            sqlcomm = new MySqlCommand(sqlSearch1, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            homeHigh = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();
            homeBig.Text = homeHigh.ToString();
            homeBigChance.Text = (((float)homeHigh / (float)(homeGameWin + homeGameLose))*100).ToString("f2") + "%";

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

 /*       public void dateGridViewChangeColor() {
            for (int i = dataShow.RowCount-2; i >=0 ; i--) {
                if (Convert.ToInt16(dataShow.Rows[i].Cells[2].Value) > Convert.ToInt16(dataShow.Rows[i].Cells[4].Value) )
                {
                    this.dataShow.Rows[i].Cells[2].Style.BackColor=Color.Red;
                }
                else
                {
                    this.dataShow.Rows[i].Cells[4].Style.BackColor = Color.Red;
                }
            }
        }
*/    }
}

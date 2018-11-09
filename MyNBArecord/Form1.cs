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

namespace MyNBArecord
{
    public partial class MainForm : Form
    {
        static string conn = "datasource=localhost;username=root;password=830814";
        MySqlConnection sqlconn = new MySqlConnection(conn);
        MySqlCommand sqlcomm;
        MySqlDataAdapter sqlAdapter;
        DataTable dt;
        public MainForm()
        {
            InitializeComponent();
            listAll();
            
        }

        private void addRecord_Click(object sender, EventArgs e)
        {
            string sqladd = "insert into nbarecord.matchrecord(matchdate,away,awaypoint,home,homepoint) values (date('" + matchDate.Text + "'),\"" + awayName.Text + "\"," + awayPoint.Text + ",\"" + homeName.Text + "\"," + homePoint.Text + ")";
            sqlcomm = sqlconn.CreateCommand();
            sqlcomm.CommandText = sqladd;
            sqlconn.Open();
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
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
            string sqlSearch = "select matchdate as 對戰日, away as 客隊,awaypoint as 客隊得分,home as 主隊,homepoint as 主隊得分 " +
            "from nbarecord.matchrecord where away = \"" +name + "\" or home =\"" + name +"\";" ;
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            dt = new DataTable();
            sqlAdapter.Fill(dt);
            dataShow.DataSource = dt;
            homePointAVG.Text = homePointAvgMethod(name);
            homeLoseAVG.Text = homeLoseAvgMethod(name);
            awayPointAVG.Text = awayPointAvgMethod(name);
            awayLoseAVG.Text = awayLoseAvgMethod(name);
            win(name);
        }

        public void win(string name)
        {
            string sqlSearch0 = "select count(\"id\") from nbarecord.matchrecord where away = \"" + name + "\" or home=\"" + name + "\";";
            sqlcomm = new MySqlCommand(sqlSearch0, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            int totelWin =Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();
            string sqlSearch1 = "select count(\"id\") from nbarecord.matchrecord where away = \""+name+"\" and awaypoint>homepoint;";
            sqlcomm = new MySqlCommand(sqlSearch1, sqlconn);
            sqlconn.Open();
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            int awayWin = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();
            string sqlSearch2 = "select count(\"id\") from nbarecord.matchrecord where home = \"" + name + "\" and homepoint>awaypoint;";
            sqlcomm = new MySqlCommand(sqlSearch2, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            sqlconn.Open();
            int homeWin = Convert.ToInt32(sqlcomm.ExecuteScalar());
            sqlconn.Close();

            gameWin.Text = (awayWin + homeWin).ToString();
            gameLose.Text = (totelWin - (awayWin + homeWin)).ToString();
        }

        public string homePointAvgMethod(string name)
        {
            string sqlSearch = "select round(avg(homepoint),2) from nbarecord.matchrecord where home =\"" + name + "\";";
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
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
            string sqlSearch = "select matchdate as 對戰日, away as 客隊,awaypoint as 客隊得分,home as 主隊,homepoint as 主隊得分 " +
            "from nbarecord.matchrecord order by matchdate desc";
            sqlcomm = new MySqlCommand(sqlSearch, sqlconn);
            sqlAdapter = new MySqlDataAdapter(sqlcomm);
            dt = new DataTable();
            sqlAdapter.Fill(dt);
            dataShow.DataSource = dt;
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
        }

        private void allMatch_Click(object sender, EventArgs e)
        {
            listAll();
        }
    }
}

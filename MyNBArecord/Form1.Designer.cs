namespace MyNBArecord
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addRecord = new System.Windows.Forms.Button();
            this.matchDate = new System.Windows.Forms.TextBox();
            this.awayName = new System.Windows.Forms.TextBox();
            this.awayPoint = new System.Windows.Forms.TextBox();
            this.homeName = new System.Windows.Forms.TextBox();
            this.dataShow = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.searchName = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.allMatch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.homePointAVG = new System.Windows.Forms.TextBox();
            this.awayPointAVG = new System.Windows.Forms.TextBox();
            this.homeLoseAVG = new System.Windows.Forms.TextBox();
            this.awayLoseAVG = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gameWin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gameLose = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.homeLose = new System.Windows.Forms.TextBox();
            this.homeWin = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.awayLose = new System.Windows.Forms.TextBox();
            this.awayWin = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.homeBig = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.awayBig = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.homeBigChance = new System.Windows.Forms.TextBox();
            this.awayBigChance = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.avgTotalPoint = new System.Windows.Forms.TextBox();
            this.tenRecord = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.homePoint = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gameToday = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataShow)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "客隊 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.label2.Location = new System.Drawing.Point(283, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "主隊 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(243, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "V.S.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F);
            this.label4.Location = new System.Drawing.Point(159, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "日期 :";
            // 
            // addRecord
            // 
            this.addRecord.Font = new System.Drawing.Font("微軟正黑體", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.addRecord.Location = new System.Drawing.Point(528, 7);
            this.addRecord.Name = "addRecord";
            this.addRecord.Size = new System.Drawing.Size(85, 76);
            this.addRecord.TabIndex = 6;
            this.addRecord.Text = "新增紀錄";
            this.addRecord.UseVisualStyleBackColor = true;
            this.addRecord.Click += new System.EventHandler(this.addRecord_Click);
            // 
            // matchDate
            // 
            this.matchDate.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.matchDate.Location = new System.Drawing.Point(225, 7);
            this.matchDate.Name = "matchDate";
            this.matchDate.Size = new System.Drawing.Size(135, 30);
            this.matchDate.TabIndex = 1;
            this.matchDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // awayName
            // 
            this.awayName.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.awayName.Location = new System.Drawing.Point(72, 45);
            this.awayName.Name = "awayName";
            this.awayName.Size = new System.Drawing.Size(100, 30);
            this.awayName.TabIndex = 2;
            // 
            // awayPoint
            // 
            this.awayPoint.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.awayPoint.Location = new System.Drawing.Point(180, 45);
            this.awayPoint.MaxLength = 3;
            this.awayPoint.Name = "awayPoint";
            this.awayPoint.Size = new System.Drawing.Size(54, 30);
            this.awayPoint.TabIndex = 3;
            // 
            // homeName
            // 
            this.homeName.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.homeName.Location = new System.Drawing.Point(349, 45);
            this.homeName.Name = "homeName";
            this.homeName.Size = new System.Drawing.Size(100, 30);
            this.homeName.TabIndex = 4;
            // 
            // dataShow
            // 
            this.dataShow.AllowUserToDeleteRows = false;
            this.dataShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataShow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataShow.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataShow.GridColor = System.Drawing.Color.Red;
            this.dataShow.Location = new System.Drawing.Point(12, 109);
            this.dataShow.Name = "dataShow";
            this.dataShow.RowHeadersVisible = false;
            this.dataShow.RowHeadersWidth = 25;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataShow.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataShow.RowTemplate.Height = 20;
            this.dataShow.RowTemplate.ReadOnly = true;
            this.dataShow.Size = new System.Drawing.Size(624, 375);
            this.dataShow.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label7.Location = new System.Drawing.Point(77, 495);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "隊伍 : ";
            // 
            // searchName
            // 
            this.searchName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.searchName.Location = new System.Drawing.Point(147, 490);
            this.searchName.Name = "searchName";
            this.searchName.Size = new System.Drawing.Size(100, 34);
            this.searchName.TabIndex = 7;
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.search.Location = new System.Drawing.Point(263, 489);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(126, 34);
            this.search.TabIndex = 8;
            this.search.Text = "查詢";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // allMatch
            // 
            this.allMatch.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.allMatch.Location = new System.Drawing.Point(472, 489);
            this.allMatch.Name = "allMatch";
            this.allMatch.Size = new System.Drawing.Size(144, 34);
            this.allMatch.TabIndex = 14;
            this.allMatch.Text = "ListALL";
            this.allMatch.UseVisualStyleBackColor = true;
            this.allMatch.Click += new System.EventHandler(this.allMatch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label9.Location = new System.Drawing.Point(5, 579);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "主場得失分 :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label10.Location = new System.Drawing.Point(334, 579);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 25);
            this.label10.TabIndex = 17;
            this.label10.Text = "客場得失分 :";
            // 
            // homePointAVG
            // 
            this.homePointAVG.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.homePointAVG.Location = new System.Drawing.Point(137, 575);
            this.homePointAVG.Name = "homePointAVG";
            this.homePointAVG.ReadOnly = true;
            this.homePointAVG.Size = new System.Drawing.Size(72, 34);
            this.homePointAVG.TabIndex = 19;
            // 
            // awayPointAVG
            // 
            this.awayPointAVG.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.awayPointAVG.Location = new System.Drawing.Point(468, 575);
            this.awayPointAVG.Name = "awayPointAVG";
            this.awayPointAVG.ReadOnly = true;
            this.awayPointAVG.Size = new System.Drawing.Size(72, 34);
            this.awayPointAVG.TabIndex = 20;
            // 
            // homeLoseAVG
            // 
            this.homeLoseAVG.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.homeLoseAVG.Location = new System.Drawing.Point(235, 575);
            this.homeLoseAVG.Name = "homeLoseAVG";
            this.homeLoseAVG.ReadOnly = true;
            this.homeLoseAVG.Size = new System.Drawing.Size(72, 34);
            this.homeLoseAVG.TabIndex = 21;
            // 
            // awayLoseAVG
            // 
            this.awayLoseAVG.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.awayLoseAVG.Location = new System.Drawing.Point(565, 575);
            this.awayLoseAVG.Name = "awayLoseAVG";
            this.awayLoseAVG.ReadOnly = true;
            this.awayLoseAVG.Size = new System.Drawing.Size(72, 34);
            this.awayLoseAVG.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label11.Location = new System.Drawing.Point(212, 580);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 25);
            this.label11.TabIndex = 23;
            this.label11.Text = "/";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label12.Location = new System.Drawing.Point(542, 580);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 25);
            this.label12.TabIndex = 24;
            this.label12.Text = "/";
            // 
            // gameWin
            // 
            this.gameWin.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.gameWin.Location = new System.Drawing.Point(99, 530);
            this.gameWin.Name = "gameWin";
            this.gameWin.ReadOnly = true;
            this.gameWin.Size = new System.Drawing.Size(72, 34);
            this.gameWin.TabIndex = 25;
            this.gameWin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label8.Location = new System.Drawing.Point(27, 535);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 25);
            this.label8.TabIndex = 26;
            this.label8.Text = "戰績 :";
            // 
            // gameLose
            // 
            this.gameLose.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.gameLose.Location = new System.Drawing.Point(197, 530);
            this.gameLose.Name = "gameLose";
            this.gameLose.ReadOnly = true;
            this.gameLose.Size = new System.Drawing.Size(72, 34);
            this.gameLose.TabIndex = 27;
            this.gameLose.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label13.Location = new System.Drawing.Point(174, 535);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 25);
            this.label13.TabIndex = 28;
            this.label13.Text = "/";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label14.Location = new System.Drawing.Point(277, 535);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 25);
            this.label14.TabIndex = 29;
            this.label14.Text = "主場 :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label15.Location = new System.Drawing.Point(392, 535);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 25);
            this.label15.TabIndex = 32;
            this.label15.Text = "/";
            // 
            // homeLose
            // 
            this.homeLose.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.homeLose.Location = new System.Drawing.Point(420, 530);
            this.homeLose.Name = "homeLose";
            this.homeLose.ReadOnly = true;
            this.homeLose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.homeLose.Size = new System.Drawing.Size(35, 34);
            this.homeLose.TabIndex = 31;
            this.homeLose.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // homeWin
            // 
            this.homeWin.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.homeWin.Location = new System.Drawing.Point(350, 530);
            this.homeWin.Name = "homeWin";
            this.homeWin.ReadOnly = true;
            this.homeWin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.homeWin.Size = new System.Drawing.Size(34, 34);
            this.homeWin.TabIndex = 30;
            this.homeWin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label16.Location = new System.Drawing.Point(572, 535);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 25);
            this.label16.TabIndex = 36;
            this.label16.Text = "/";
            // 
            // awayLose
            // 
            this.awayLose.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.awayLose.Location = new System.Drawing.Point(598, 530);
            this.awayLose.Name = "awayLose";
            this.awayLose.ReadOnly = true;
            this.awayLose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.awayLose.Size = new System.Drawing.Size(39, 34);
            this.awayLose.TabIndex = 35;
            this.awayLose.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // awayWin
            // 
            this.awayWin.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.awayWin.Location = new System.Drawing.Point(528, 530);
            this.awayWin.Name = "awayWin";
            this.awayWin.ReadOnly = true;
            this.awayWin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.awayWin.Size = new System.Drawing.Size(38, 34);
            this.awayWin.TabIndex = 34;
            this.awayWin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label17.Location = new System.Drawing.Point(460, 535);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 25);
            this.label17.TabIndex = 33;
            this.label17.Text = "客場 :";
            // 
            // homeBig
            // 
            this.homeBig.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.homeBig.Location = new System.Drawing.Point(115, 615);
            this.homeBig.Name = "homeBig";
            this.homeBig.ReadOnly = true;
            this.homeBig.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.homeBig.Size = new System.Drawing.Size(41, 34);
            this.homeBig.TabIndex = 38;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label18.Location = new System.Drawing.Point(16, 620);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 25);
            this.label18.TabIndex = 37;
            this.label18.Text = "主>100 :";
            // 
            // awayBig
            // 
            this.awayBig.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.awayBig.Location = new System.Drawing.Point(373, 615);
            this.awayBig.Name = "awayBig";
            this.awayBig.ReadOnly = true;
            this.awayBig.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.awayBig.Size = new System.Drawing.Size(45, 34);
            this.awayBig.TabIndex = 40;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label19.Location = new System.Drawing.Point(281, 619);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 25);
            this.label19.TabIndex = 39;
            this.label19.Text = "客>100 :";
            // 
            // homeBigChance
            // 
            this.homeBigChance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.homeBigChance.Location = new System.Drawing.Point(166, 615);
            this.homeBigChance.MaxLength = 5;
            this.homeBigChance.Name = "homeBigChance";
            this.homeBigChance.ReadOnly = true;
            this.homeBigChance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.homeBigChance.Size = new System.Drawing.Size(97, 34);
            this.homeBigChance.TabIndex = 41;
            // 
            // awayBigChance
            // 
            this.awayBigChance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.awayBigChance.Location = new System.Drawing.Point(424, 615);
            this.awayBigChance.MaxLength = 5;
            this.awayBigChance.Name = "awayBigChance";
            this.awayBigChance.ReadOnly = true;
            this.awayBigChance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.awayBigChance.Size = new System.Drawing.Size(98, 34);
            this.awayBigChance.TabIndex = 42;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label20.Location = new System.Drawing.Point(81, 659);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(102, 25);
            this.label20.TabIndex = 43;
            this.label20.Text = "平均總分 :";
            // 
            // avgTotalPoint
            // 
            this.avgTotalPoint.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.avgTotalPoint.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.avgTotalPoint.Location = new System.Drawing.Point(185, 655);
            this.avgTotalPoint.Name = "avgTotalPoint";
            this.avgTotalPoint.ReadOnly = true;
            this.avgTotalPoint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.avgTotalPoint.Size = new System.Drawing.Size(79, 34);
            this.avgTotalPoint.TabIndex = 44;
            // 
            // tenRecord
            // 
            this.tenRecord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tenRecord.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.tenRecord.Location = new System.Drawing.Point(349, 655);
            this.tenRecord.Name = "tenRecord";
            this.tenRecord.ReadOnly = true;
            this.tenRecord.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tenRecord.Size = new System.Drawing.Size(243, 32);
            this.tenRecord.TabIndex = 46;
            this.tenRecord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label21.Location = new System.Drawing.Point(267, 660);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 25);
            this.label21.TabIndex = 45;
            this.label21.Text = "近十場 :";
            // 
            // homePoint
            // 
            this.homePoint.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.homePoint.Location = new System.Drawing.Point(458, 45);
            this.homePoint.MaxLength = 3;
            this.homePoint.Name = "homePoint";
            this.homePoint.Size = new System.Drawing.Size(54, 30);
            this.homePoint.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.addRecord);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.matchDate);
            this.panel1.Controls.Add(this.awayName);
            this.panel1.Controls.Add(this.awayPoint);
            this.panel1.Controls.Add(this.homeName);
            this.panel1.Controls.Add(this.homePoint);
            this.panel1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 91);
            this.panel1.TabIndex = 47;
            // 
            // gameToday
            // 
            this.gameToday.Font = new System.Drawing.Font("新細明體", 12F);
            this.gameToday.FormattingEnabled = true;
            this.gameToday.ItemHeight = 20;
            this.gameToday.Location = new System.Drawing.Point(642, 12);
            this.gameToday.Name = "gameToday";
            this.gameToday.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.gameToday.Size = new System.Drawing.Size(248, 624);
            this.gameToday.TabIndex = 48;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(691, 648);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 47);
            this.button1.TabIndex = 49;
            this.button1.Text = "重新整理";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 709);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gameToday);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tenRecord);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.avgTotalPoint);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.awayBigChance);
            this.Controls.Add(this.homeBigChance);
            this.Controls.Add(this.awayBig);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.homeBig);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.awayLose);
            this.Controls.Add(this.awayWin);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.homeLose);
            this.Controls.Add(this.homeWin);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.gameLose);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gameWin);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.awayLoseAVG);
            this.Controls.Add(this.homeLoseAVG);
            this.Controls.Add(this.awayPointAVG);
            this.Controls.Add(this.homePointAVG);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.allMatch);
            this.Controls.Add(this.search);
            this.Controls.Add(this.searchName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataShow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(860, 515);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My NBA Record";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataShow)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addRecord;
        private System.Windows.Forms.TextBox matchDate;
        private System.Windows.Forms.TextBox awayName;
        private System.Windows.Forms.TextBox awayPoint;
        private System.Windows.Forms.TextBox homeName;
        private System.Windows.Forms.DataGridView dataShow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox searchName;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button allMatch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox homePointAVG;
        private System.Windows.Forms.TextBox awayPointAVG;
        private System.Windows.Forms.TextBox homeLoseAVG;
        private System.Windows.Forms.TextBox awayLoseAVG;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox gameWin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox gameLose;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox homeLose;
        private System.Windows.Forms.TextBox homeWin;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox awayLose;
        private System.Windows.Forms.TextBox awayWin;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox homeBig;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox awayBig;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox homeBigChance;
        private System.Windows.Forms.TextBox awayBigChance;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox avgTotalPoint;
        private System.Windows.Forms.TextBox tenRecord;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox homePoint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox gameToday;
        private System.Windows.Forms.Button button1;
    }
}


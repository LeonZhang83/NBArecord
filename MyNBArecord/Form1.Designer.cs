﻿namespace MyNBArecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.addRecord = new System.Windows.Forms.Button();
            this.matchDate = new System.Windows.Forms.TextBox();
            this.awayName = new System.Windows.Forms.TextBox();
            this.awayPoint = new System.Windows.Forms.TextBox();
            this.homeName = new System.Windows.Forms.TextBox();
            this.homePoint = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataShow)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(52, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "客隊 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.label2.Location = new System.Drawing.Point(52, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "主隊 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F);
            this.label3.Location = new System.Drawing.Point(119, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "V.S.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F);
            this.label4.Location = new System.Drawing.Point(52, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "日期 : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 12F);
            this.label5.Location = new System.Drawing.Point(12, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "客隊分數 : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 12F);
            this.label6.Location = new System.Drawing.Point(12, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "主隊分數 : ";
            // 
            // addRecord
            // 
            this.addRecord.Font = new System.Drawing.Font("新細明體", 13F);
            this.addRecord.Location = new System.Drawing.Point(64, 311);
            this.addRecord.Name = "addRecord";
            this.addRecord.Size = new System.Drawing.Size(126, 35);
            this.addRecord.TabIndex = 6;
            this.addRecord.Text = "新增紀錄";
            this.addRecord.UseVisualStyleBackColor = true;
            this.addRecord.Click += new System.EventHandler(this.addRecord_Click);
            // 
            // matchDate
            // 
            this.matchDate.Font = new System.Drawing.Font("新細明體", 11F);
            this.matchDate.Location = new System.Drawing.Point(120, 26);
            this.matchDate.Name = "matchDate";
            this.matchDate.Size = new System.Drawing.Size(100, 29);
            this.matchDate.TabIndex = 1;
            // 
            // awayName
            // 
            this.awayName.Font = new System.Drawing.Font("新細明體", 11F);
            this.awayName.Location = new System.Drawing.Point(119, 75);
            this.awayName.Name = "awayName";
            this.awayName.Size = new System.Drawing.Size(100, 29);
            this.awayName.TabIndex = 2;
            // 
            // awayPoint
            // 
            this.awayPoint.Font = new System.Drawing.Font("新細明體", 11F);
            this.awayPoint.Location = new System.Drawing.Point(120, 120);
            this.awayPoint.MaxLength = 3;
            this.awayPoint.Name = "awayPoint";
            this.awayPoint.Size = new System.Drawing.Size(100, 29);
            this.awayPoint.TabIndex = 3;
            // 
            // homeName
            // 
            this.homeName.Font = new System.Drawing.Font("新細明體", 11F);
            this.homeName.Location = new System.Drawing.Point(121, 206);
            this.homeName.Name = "homeName";
            this.homeName.Size = new System.Drawing.Size(100, 29);
            this.homeName.TabIndex = 4;
            // 
            // homePoint
            // 
            this.homePoint.Font = new System.Drawing.Font("新細明體", 11F);
            this.homePoint.Location = new System.Drawing.Point(120, 252);
            this.homePoint.MaxLength = 3;
            this.homePoint.Name = "homePoint";
            this.homePoint.Size = new System.Drawing.Size(100, 29);
            this.homePoint.TabIndex = 5;
            // 
            // dataShow
            // 
            this.dataShow.AllowUserToDeleteRows = false;
            this.dataShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataShow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataShow.GridColor = System.Drawing.Color.Red;
            this.dataShow.Location = new System.Drawing.Point(257, 24);
            this.dataShow.Name = "dataShow";
            this.dataShow.RowHeadersVisible = false;
            this.dataShow.RowHeadersWidth = 25;
            this.dataShow.RowTemplate.Height = 27;
            this.dataShow.Size = new System.Drawing.Size(655, 279);
            this.dataShow.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 12F);
            this.label7.Location = new System.Drawing.Point(458, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "隊伍 : ";
            // 
            // searchName
            // 
            this.searchName.Font = new System.Drawing.Font("新細明體", 11F);
            this.searchName.Location = new System.Drawing.Point(520, 327);
            this.searchName.Name = "searchName";
            this.searchName.Size = new System.Drawing.Size(100, 29);
            this.searchName.TabIndex = 7;
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("新細明體", 13F);
            this.search.Location = new System.Drawing.Point(630, 319);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(90, 42);
            this.search.TabIndex = 8;
            this.search.Text = "查詢";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // allMatch
            // 
            this.allMatch.Font = new System.Drawing.Font("新細明體", 10F);
            this.allMatch.Location = new System.Drawing.Point(822, 309);
            this.allMatch.Name = "allMatch";
            this.allMatch.Size = new System.Drawing.Size(90, 34);
            this.allMatch.TabIndex = 14;
            this.allMatch.Text = "ListALL";
            this.allMatch.UseVisualStyleBackColor = true;
            this.allMatch.Click += new System.EventHandler(this.allMatch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 12F);
            this.label9.Location = new System.Drawing.Point(88, 409);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "主場平均得失分 :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 12F);
            this.label10.Location = new System.Drawing.Point(87, 449);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "客場平均得失分 :";
            // 
            // homePointAVG
            // 
            this.homePointAVG.Font = new System.Drawing.Font("新細明體", 11F);
            this.homePointAVG.Location = new System.Drawing.Point(257, 405);
            this.homePointAVG.Name = "homePointAVG";
            this.homePointAVG.ReadOnly = true;
            this.homePointAVG.Size = new System.Drawing.Size(72, 29);
            this.homePointAVG.TabIndex = 19;
            // 
            // awayPointAVG
            // 
            this.awayPointAVG.Font = new System.Drawing.Font("新細明體", 11F);
            this.awayPointAVG.Location = new System.Drawing.Point(257, 445);
            this.awayPointAVG.Name = "awayPointAVG";
            this.awayPointAVG.ReadOnly = true;
            this.awayPointAVG.Size = new System.Drawing.Size(72, 29);
            this.awayPointAVG.TabIndex = 20;
            // 
            // homeLoseAVG
            // 
            this.homeLoseAVG.Font = new System.Drawing.Font("新細明體", 11F);
            this.homeLoseAVG.Location = new System.Drawing.Point(351, 405);
            this.homeLoseAVG.Name = "homeLoseAVG";
            this.homeLoseAVG.ReadOnly = true;
            this.homeLoseAVG.Size = new System.Drawing.Size(72, 29);
            this.homeLoseAVG.TabIndex = 21;
            // 
            // awayLoseAVG
            // 
            this.awayLoseAVG.Font = new System.Drawing.Font("新細明體", 11F);
            this.awayLoseAVG.Location = new System.Drawing.Point(351, 445);
            this.awayLoseAVG.Name = "awayLoseAVG";
            this.awayLoseAVG.ReadOnly = true;
            this.awayLoseAVG.Size = new System.Drawing.Size(72, 29);
            this.awayLoseAVG.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 12F);
            this.label11.Location = new System.Drawing.Point(334, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "/";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 12F);
            this.label12.Location = new System.Drawing.Point(334, 450);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "/";
            // 
            // gameWin
            // 
            this.gameWin.Font = new System.Drawing.Font("新細明體", 11F);
            this.gameWin.Location = new System.Drawing.Point(257, 366);
            this.gameWin.Name = "gameWin";
            this.gameWin.ReadOnly = true;
            this.gameWin.Size = new System.Drawing.Size(72, 29);
            this.gameWin.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 12F);
            this.label8.Location = new System.Drawing.Point(192, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "戰績 :";
            // 
            // gameLose
            // 
            this.gameLose.Font = new System.Drawing.Font("新細明體", 11F);
            this.gameLose.Location = new System.Drawing.Point(351, 366);
            this.gameLose.Name = "gameLose";
            this.gameLose.ReadOnly = true;
            this.gameLose.Size = new System.Drawing.Size(72, 29);
            this.gameLose.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("新細明體", 12F);
            this.label13.Location = new System.Drawing.Point(334, 371);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "/";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 511);
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
            this.Controls.Add(this.homePoint);
            this.Controls.Add(this.homeName);
            this.Controls.Add(this.awayPoint);
            this.Controls.Add(this.awayName);
            this.Controls.Add(this.matchDate);
            this.Controls.Add(this.addRecord);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My NBA Record";
            ((System.ComponentModel.ISupportInitialize)(this.dataShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addRecord;
        private System.Windows.Forms.TextBox matchDate;
        private System.Windows.Forms.TextBox awayName;
        private System.Windows.Forms.TextBox awayPoint;
        private System.Windows.Forms.TextBox homeName;
        private System.Windows.Forms.TextBox homePoint;
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
    }
}

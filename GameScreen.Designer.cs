
namespace GADE_POE
{
    partial class GameScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mapLabel = new System.Windows.Forms.Label();
            this.playerInfoGroup = new System.Windows.Forms.GroupBox();
            this.statsLabel = new System.Windows.Forms.Label();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.enemiesDropList = new System.Windows.Forms.ComboBox();
            this.AttackButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.playerInfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapLabel
            // 
            this.mapLabel.AutoSize = true;
            this.mapLabel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mapLabel.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapLabel.Location = new System.Drawing.Point(50, 48);
            this.mapLabel.Name = "mapLabel";
            this.mapLabel.Size = new System.Drawing.Size(166, 178);
            this.mapLabel.TabIndex = 0;
            this.mapLabel.Text = "XXXXXXXXXXXXXX\r\nX......G.....X\r\nX......G.....X\r\nX............X\r\nX....G.G.....X\r\nX" +
    ".....GH.....X\r\nX............X\r\nXXXXXXXXXXXXXX";
            // 
            // playerInfoGroup
            // 
            this.playerInfoGroup.Controls.Add(this.statsLabel);
            this.playerInfoGroup.Location = new System.Drawing.Point(671, 95);
            this.playerInfoGroup.Name = "playerInfoGroup";
            this.playerInfoGroup.Size = new System.Drawing.Size(286, 178);
            this.playerInfoGroup.TabIndex = 1;
            this.playerInfoGroup.TabStop = false;
            this.playerInfoGroup.Text = "Player Info";
            // 
            // statsLabel
            // 
            this.statsLabel.AutoSize = true;
            this.statsLabel.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsLabel.Location = new System.Drawing.Point(24, 30);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(158, 17);
            this.statsLabel.TabIndex = 0;
            this.statsLabel.Text = "[Player Stats:]";
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(746, 279);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(91, 29);
            this.UpButton.TabIndex = 2;
            this.UpButton.Text = "^";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Location = new System.Drawing.Point(746, 349);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(91, 29);
            this.DownButton.TabIndex = 3;
            this.DownButton.Text = "v";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // LeftButton
            // 
            this.LeftButton.Location = new System.Drawing.Point(655, 314);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(91, 29);
            this.LeftButton.TabIndex = 4;
            this.LeftButton.Text = "<";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.Location = new System.Drawing.Point(835, 314);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(91, 29);
            this.RightButton.TabIndex = 5;
            this.RightButton.Text = ">";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // enemiesDropList
            // 
            this.enemiesDropList.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.enemiesDropList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enemiesDropList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.enemiesDropList.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemiesDropList.FormattingEnabled = true;
            this.enemiesDropList.Location = new System.Drawing.Point(389, 104);
            this.enemiesDropList.Name = "enemiesDropList";
            this.enemiesDropList.Size = new System.Drawing.Size(276, 23);
            this.enemiesDropList.TabIndex = 6;
            this.enemiesDropList.SelectedIndexChanged += new System.EventHandler(this.enemiesDropList_SelectedIndexChanged);
            // 
            // AttackButton
            // 
            this.AttackButton.Enabled = false;
            this.AttackButton.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttackButton.Location = new System.Drawing.Point(453, 149);
            this.AttackButton.Name = "AttackButton";
            this.AttackButton.Size = new System.Drawing.Size(103, 36);
            this.AttackButton.TabIndex = 7;
            this.AttackButton.Text = "Attack";
            this.AttackButton.UseVisualStyleBackColor = true;
            this.AttackButton.Click += new System.EventHandler(this.AttackButton_Click);
            // 
            // logBox
            // 
            this.logBox.Font = new System.Drawing.Font("OCR A Extended", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBox.Location = new System.Drawing.Point(389, 212);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(276, 96);
            this.logBox.TabIndex = 8;
            this.logBox.Text = "Log:";
            this.logBox.TextChanged += new System.EventHandler(this.logBox_TextChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Consolas", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(444, 349);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(121, 40);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("Consolas", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.Location = new System.Drawing.Point(444, 405);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(121, 40);
            this.LoadButton.TabIndex = 10;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 523);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.AttackButton);
            this.Controls.Add(this.enemiesDropList);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.LeftButton);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.playerInfoGroup);
            this.Controls.Add(this.mapLabel);
            this.Name = "GameScreen";
            this.Text = "Game Screen";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.playerInfoGroup.ResumeLayout(false);
            this.playerInfoGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mapLabel;
        private System.Windows.Forms.GroupBox playerInfoGroup;
        private System.Windows.Forms.Label statsLabel;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.ComboBox enemiesDropList;
        private System.Windows.Forms.Button AttackButton;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05_OthelloUI
{
    public class FormGameSettings : Form
    {
        private const int k_MaxBoardSize = 12;
        private string k_boardSize = "Board size: {0} x {0} (click to increase)";
        private Button buttonComputer;
        private Button buttonFriend;
        private Button buttonIncrese;
        private int m_BoardSize = 6;

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }

        public FormGameSettings()
        {
            InitializeComponent();
            this.buttonIncrese.Text = string.Format(k_boardSize, BoardSize);
        }

        private void InitializeComponent()
        {
            this.buttonComputer = new System.Windows.Forms.Button();
            this.buttonFriend = new System.Windows.Forms.Button();
            this.buttonIncrese = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonComputer
            // 
            this.buttonComputer.Location = new System.Drawing.Point(28, 106);
            this.buttonComputer.Name = "buttonComputer";
            this.buttonComputer.Size = new System.Drawing.Size(176, 48);
            this.buttonComputer.TabIndex = 1;
            this.buttonComputer.Text = "Play against the computer";
            this.buttonComputer.UseVisualStyleBackColor = true;
            this.buttonComputer.Click += new System.EventHandler(this.buttonComputer_Click);
            // 
            // buttonFriend
            // 
            this.buttonFriend.Location = new System.Drawing.Point(230, 106);
            this.buttonFriend.Name = "buttonFriend";
            this.buttonFriend.Size = new System.Drawing.Size(176, 48);
            this.buttonFriend.TabIndex = 2;
            this.buttonFriend.Text = "Play against your friend";
            this.buttonFriend.UseVisualStyleBackColor = true;
            this.buttonFriend.Click += new System.EventHandler(this.buttonFriend_Click);
            // 
            // buttonIncrese
            // 
            this.buttonIncrese.Location = new System.Drawing.Point(28, 28);
            this.buttonIncrese.Name = "buttonIncrese";
            this.buttonIncrese.Size = new System.Drawing.Size(378, 48);
            this.buttonIncrese.TabIndex = 1;
            this.buttonIncrese.UseVisualStyleBackColor = true;
            this.buttonIncrese.Click += new System.EventHandler(this.buttonIncrese_Click);
            // 
            // FormGameSettings
            // 
            this.ClientSize = new System.Drawing.Size(435, 175);
            this.Controls.Add(this.buttonIncrese);
            this.Controls.Add(this.buttonComputer);
            this.Controls.Add(this.buttonFriend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello - Game Settings";
            this.ResumeLayout(false);

        }

        private void buttonIncrese_Click(object sender, EventArgs e)
        {
            if (m_BoardSize < k_MaxBoardSize)
            {
                m_BoardSize += 2;
            }
            else
            {
                m_BoardSize = 6;
            }

            buttonIncrese.Text = string.Format(k_boardSize, BoardSize);
        }

        private void buttonComputer_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void buttonFriend_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}

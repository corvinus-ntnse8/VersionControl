﻿
namespace ntnse8_week8
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.carbtn = new System.Windows.Forms.Button();
            this.ballbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.prsbtn = new System.Windows.Forms.Button();
            this.btncolorBox = new System.Windows.Forms.Button();
            this.btnclrRibbon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(12, 264);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(776, 174);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // carbtn
            // 
            this.carbtn.Location = new System.Drawing.Point(25, 12);
            this.carbtn.Name = "carbtn";
            this.carbtn.Size = new System.Drawing.Size(86, 62);
            this.carbtn.TabIndex = 1;
            this.carbtn.Text = "Car";
            this.carbtn.UseVisualStyleBackColor = true;
            this.carbtn.Click += new System.EventHandler(this.carbtn_Click);
            // 
            // ballbtn
            // 
            this.ballbtn.Location = new System.Drawing.Point(135, 12);
            this.ballbtn.Name = "ballbtn";
            this.ballbtn.Size = new System.Drawing.Size(98, 62);
            this.ballbtn.TabIndex = 2;
            this.ballbtn.Text = "Ball";
            this.ballbtn.UseVisualStyleBackColor = true;
            this.ballbtn.Click += new System.EventHandler(this.ballbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(417, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnColor.Location = new System.Drawing.Point(135, 80);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(98, 17);
            this.btnColor.TabIndex = 4;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // prsbtn
            // 
            this.prsbtn.Location = new System.Drawing.Point(260, 12);
            this.prsbtn.Name = "prsbtn";
            this.prsbtn.Size = new System.Drawing.Size(98, 62);
            this.prsbtn.TabIndex = 5;
            this.prsbtn.Text = "Present";
            this.prsbtn.UseVisualStyleBackColor = true;
            this.prsbtn.Click += new System.EventHandler(this.prsbtn_Click);
            // 
            // btncolorBox
            // 
            this.btncolorBox.BackColor = System.Drawing.Color.Gold;
            this.btncolorBox.Location = new System.Drawing.Point(260, 80);
            this.btncolorBox.Name = "btncolorBox";
            this.btncolorBox.Size = new System.Drawing.Size(98, 17);
            this.btncolorBox.TabIndex = 6;
            this.btncolorBox.UseVisualStyleBackColor = false;
            this.btncolorBox.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnclrRibbon
            // 
            this.btnclrRibbon.BackColor = System.Drawing.Color.DarkRed;
            this.btnclrRibbon.Location = new System.Drawing.Point(260, 103);
            this.btnclrRibbon.Name = "btnclrRibbon";
            this.btnclrRibbon.Size = new System.Drawing.Size(98, 17);
            this.btnclrRibbon.TabIndex = 7;
            this.btnclrRibbon.UseVisualStyleBackColor = false;
            this.btnclrRibbon.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnclrRibbon);
            this.Controls.Add(this.btncolorBox);
            this.Controls.Add(this.prsbtn);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ballbtn);
            this.Controls.Add(this.carbtn);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Button carbtn;
        private System.Windows.Forms.Button ballbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button prsbtn;
        private System.Windows.Forms.Button btncolorBox;
        private System.Windows.Forms.Button btnclrRibbon;
    }
}


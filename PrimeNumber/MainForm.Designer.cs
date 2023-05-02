
namespace PrimeNumber
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartValue = new System.Windows.Forms.TextBox();
            this.btnStartParallel = new System.Windows.Forms.Button();
            this.btnFillMax = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtSetCores = new System.Windows.Forms.TextBox();
            this.btnSetCores = new System.Windows.Forms.Button();
            this.lbMsg = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMax
            // 
            this.txtMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMax.Location = new System.Drawing.Point(72, 31);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(125, 21);
            this.txtMax.TabIndex = 1;
            this.txtMax.Text = "10000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "限制最大值";
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.Location = new System.Drawing.Point(3, 110);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(309, 21);
            this.txtMsg.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "穷举起始值";
            // 
            // txtStartValue
            // 
            this.txtStartValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartValue.Location = new System.Drawing.Point(72, 6);
            this.txtStartValue.Name = "txtStartValue";
            this.txtStartValue.Size = new System.Drawing.Size(125, 21);
            this.txtStartValue.TabIndex = 1;
            this.txtStartValue.Text = "0";
            // 
            // btnStartParallel
            // 
            this.btnStartParallel.Location = new System.Drawing.Point(3, 86);
            this.btnStartParallel.Name = "btnStartParallel";
            this.btnStartParallel.Size = new System.Drawing.Size(63, 23);
            this.btnStartParallel.TabIndex = 0;
            this.btnStartParallel.Text = "开始Parallel";
            this.btnStartParallel.UseVisualStyleBackColor = true;
            this.btnStartParallel.Click += new System.EventHandler(this.btnStartParallel_Click);
            // 
            // btnFillMax
            // 
            this.btnFillMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFillMax.Location = new System.Drawing.Point(203, 30);
            this.btnFillMax.Name = "btnFillMax";
            this.btnFillMax.Size = new System.Drawing.Size(109, 23);
            this.btnFillMax.TabIndex = 0;
            this.btnFillMax.Text = "填充long最大值";
            this.btnFillMax.UseVisualStyleBackColor = true;
            this.btnFillMax.Click += new System.EventHandler(this.btnFillMax_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(72, 86);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(63, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "终止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtSetCores
            // 
            this.txtSetCores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSetCores.Location = new System.Drawing.Point(72, 57);
            this.txtSetCores.Name = "txtSetCores";
            this.txtSetCores.Size = new System.Drawing.Size(125, 21);
            this.txtSetCores.TabIndex = 9;
            this.txtSetCores.Text = "4";
            // 
            // btnSetCores
            // 
            this.btnSetCores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetCores.Location = new System.Drawing.Point(203, 56);
            this.btnSetCores.Name = "btnSetCores";
            this.btnSetCores.Size = new System.Drawing.Size(109, 23);
            this.btnSetCores.TabIndex = 10;
            this.btnSetCores.Text = "工作内核数设置";
            this.btnSetCores.UseVisualStyleBackColor = true;
            this.btnSetCores.Click += new System.EventHandler(this.btnSetCores_Click);
            // 
            // lbMsg
            // 
            this.lbMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMsg.FormattingEnabled = true;
            this.lbMsg.ItemHeight = 12;
            this.lbMsg.Location = new System.Drawing.Point(3, 130);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(309, 64);
            this.lbMsg.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "启用内核数";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 202);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.btnSetCores);
            this.Controls.Add(this.txtSetCores);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStartValue);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.btnFillMax);
            this.Controls.Add(this.btnStartParallel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(330, 175);
            this.Name = "MainForm";
            this.Text = "穷举质数";
            this.Load += new System.EventHandler(this.PrimeNumberForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartValue;
        private System.Windows.Forms.Button btnStartParallel;
        private System.Windows.Forms.Button btnFillMax;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtSetCores;
        private System.Windows.Forms.Button btnSetCores;
        private System.Windows.Forms.ListBox lbMsg;
        private System.Windows.Forms.Label label3;
    }
}
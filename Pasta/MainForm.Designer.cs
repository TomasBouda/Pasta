namespace Pasta
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.txtLastResponse = new System.Windows.Forms.TextBox();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnToggleLock = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Api key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last paste response";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Enabled = false;
            this.txtApiKey.Location = new System.Drawing.Point(15, 25);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(193, 20);
            this.txtApiKey.TabIndex = 2;
            this.txtApiKey.TextChanged += new System.EventHandler(this.txtApiKey_TextChanged);
            // 
            // txtLastResponse
            // 
            this.txtLastResponse.Location = new System.Drawing.Point(15, 112);
            this.txtLastResponse.Name = "txtLastResponse";
            this.txtLastResponse.Size = new System.Drawing.Size(193, 20);
            this.txtLastResponse.TabIndex = 3;
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(15, 55);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(193, 33);
            this.btnPaste.TabIndex = 4;
            this.btnPaste.Text = "Paste From Clipboard";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            this.btnPaste.MouseEnter += new System.EventHandler(this.btnPaste_MouseEnter);
            // 
            // btnToggleLock
            // 
            this.btnToggleLock.BackgroundImage = global::Pasta.Properties.Resources.unlocked;
            this.btnToggleLock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToggleLock.Location = new System.Drawing.Point(211, 24);
            this.btnToggleLock.Name = "btnToggleLock";
            this.btnToggleLock.Size = new System.Drawing.Size(22, 21);
            this.btnToggleLock.TabIndex = 5;
            this.btnToggleLock.UseVisualStyleBackColor = true;
            this.btnToggleLock.Click += new System.EventHandler(this.btnToggleLock_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 145);
            this.Controls.Add(this.btnToggleLock);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.txtLastResponse);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pasta";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.TextBox txtLastResponse;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnToggleLock;
        private System.Windows.Forms.ToolTip toolTip;
    }
}


namespace GameMessageViewer
{
    partial class MessageFilter
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
            this.cmdOk = new System.Windows.Forms.Button();
            this.cmdAll = new System.Windows.Forms.Button();
            this.cmdNone = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(282, 187);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(54, 34);
            this.cmdOk.TabIndex = 0;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdAll
            // 
            this.cmdAll.Location = new System.Drawing.Point(282, 107);
            this.cmdAll.Name = "cmdAll";
            this.cmdAll.Size = new System.Drawing.Size(54, 34);
            this.cmdAll.TabIndex = 1;
            this.cmdAll.Text = "All";
            this.cmdAll.UseVisualStyleBackColor = true;
            this.cmdAll.Click += new System.EventHandler(this.cmdAll_Click);
            // 
            // cmdNone
            // 
            this.cmdNone.Location = new System.Drawing.Point(282, 147);
            this.cmdNone.Name = "cmdNone";
            this.cmdNone.Size = new System.Drawing.Size(54, 34);
            this.cmdNone.TabIndex = 2;
            this.cmdNone.Text = "None";
            this.cmdNone.UseVisualStyleBackColor = true;
            this.cmdNone.Click += new System.EventHandler(this.cmdNone_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(253, 389);
            this.checkedListBox1.TabIndex = 3;
            // 
            // MessageFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 389);
            this.ControlBox = false;
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.cmdNone);
            this.Controls.Add(this.cmdAll);
            this.Controls.Add(this.cmdOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageFilter";
            this.Text = "Message filter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Button cmdAll;
        private System.Windows.Forms.Button cmdNone;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}
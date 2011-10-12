namespace GameMessageViewer
{
    partial class MessageViewer
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
            this.input = new System.Windows.Forms.RichTextBox();
            this.tree = new System.Windows.Forms.TreeView();
            this.output = new System.Windows.Forms.RichTextBox();
            this.actors = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPreparsedDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCapPreparsedDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pcapDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawByteDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.findAllMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trySNOAliasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input.Location = new System.Drawing.Point(12, 36);
            this.input.Name = "input";
            this.input.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.input.Size = new System.Drawing.Size(384, 855);
            this.input.TabIndex = 1;
            this.input.Text = "";
            this.input.KeyUp += new System.Windows.Forms.KeyEventHandler(this.input_KeyUp);
            // 
            // tree
            // 
            this.tree.Location = new System.Drawing.Point(402, 36);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(446, 341);
            this.tree.TabIndex = 2;
            this.tree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterCollapse);
            this.tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeExpand);
            this.tree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterExpand);
            this.tree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeSelect);
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(402, 394);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(446, 497);
            this.output.TabIndex = 3;
            this.output.Text = "";
            this.output.MouseClick += new System.Windows.Forms.MouseEventHandler(this.output_MouseClick);
            this.output.MouseMove += new System.Windows.Forms.MouseEventHandler(this.output_MouseMove);
            // 
            // actors
            // 
            this.actors.Location = new System.Drawing.Point(854, 36);
            this.actors.Name = "actors";
            this.actors.Size = new System.Drawing.Size(500, 790);
            this.actors.TabIndex = 4;
            this.actors.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.actors_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(854, 833);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(499, 58);
            this.button1.TabIndex = 5;
            this.button1.Text = "Pull Actors (Warning, slow)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1374, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPreparsedDumpToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openPreparsedDumpToolStripMenuItem
            // 
            this.openPreparsedDumpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pCapPreparsedDumpToolStripMenuItem,
            this.pcapDumpToolStripMenuItem,
            this.rawByteDumpToolStripMenuItem});
            this.openPreparsedDumpToolStripMenuItem.Name = "openPreparsedDumpToolStripMenuItem";
            this.openPreparsedDumpToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.openPreparsedDumpToolStripMenuItem.Text = "Open...";
            // 
            // pCapPreparsedDumpToolStripMenuItem
            // 
            this.pCapPreparsedDumpToolStripMenuItem.Enabled = false;
            this.pCapPreparsedDumpToolStripMenuItem.Name = "pCapPreparsedDumpToolStripMenuItem";
            this.pCapPreparsedDumpToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.pCapPreparsedDumpToolStripMenuItem.Text = "Pcap preparsed txt...";
            this.pCapPreparsedDumpToolStripMenuItem.Click += new System.EventHandler(this.pCapPreparsedDumpToolStripMenuItem_Click);
            // 
            // pcapDumpToolStripMenuItem
            // 
            this.pcapDumpToolStripMenuItem.Name = "pcapDumpToolStripMenuItem";
            this.pcapDumpToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.pcapDumpToolStripMenuItem.Text = "Pcap dump...";
            this.pcapDumpToolStripMenuItem.Click += new System.EventHandler(this.pcapDumpToolStripMenuItem_Click);
            // 
            // rawByteDumpToolStripMenuItem
            // 
            this.rawByteDumpToolStripMenuItem.Name = "rawByteDumpToolStripMenuItem";
            this.rawByteDumpToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.rawByteDumpToolStripMenuItem.Text = "Mooege GS Dump...";
            this.rawByteDumpToolStripMenuItem.Click += new System.EventHandler(this.rawByteDumpToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(130, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageFilterToolStripMenuItem,
            this.findAllMessagesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.trySNOAliasesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // messageFilterToolStripMenuItem
            // 
            this.messageFilterToolStripMenuItem.Name = "messageFilterToolStripMenuItem";
            this.messageFilterToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.messageFilterToolStripMenuItem.Text = "Message filter...";
            this.messageFilterToolStripMenuItem.Click += new System.EventHandler(this.messageFilterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(170, 6);
            // 
            // findAllMessagesToolStripMenuItem
            // 
            this.findAllMessagesToolStripMenuItem.Name = "findAllMessagesToolStripMenuItem";
            this.findAllMessagesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.findAllMessagesToolStripMenuItem.Text = "Find all messages...";
            this.findAllMessagesToolStripMenuItem.Click += new System.EventHandler(this.findAllMessagesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.aboutToolStripMenuItem1.Text = "About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // trySNOAliasesToolStripMenuItem
            // 
            this.trySNOAliasesToolStripMenuItem.Checked = true;
            this.trySNOAliasesToolStripMenuItem.CheckOnClick = true;
            this.trySNOAliasesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trySNOAliasesToolStripMenuItem.Name = "trySNOAliasesToolStripMenuItem";
            this.trySNOAliasesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.trySNOAliasesToolStripMenuItem.Text = "Try SNO Aliases";
            // 
            // MessageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 903);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.actors);
            this.Controls.Add(this.output);
            this.Controls.Add(this.tree);
            this.Controls.Add(this.input);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MessageViewer";
            this.Text = "GS Message Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox input;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageFilterToolStripMenuItem;
        private System.Windows.Forms.TreeView actors;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem findAllMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPreparsedDumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pCapPreparsedDumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pcapDumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawByteDumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trySNOAliasesToolStripMenuItem;

    }
}


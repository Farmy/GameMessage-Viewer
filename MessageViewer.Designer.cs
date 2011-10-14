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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPreparsedDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAllMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.trySNOAliasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_mainframe = new System.Windows.Forms.Panel();
            this.panel_messages = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel_messages_header = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_messages_content = new System.Windows.Forms.Panel();
            this.tree = new System.Windows.Forms.TreeView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabActors = new System.Windows.Forms.TabPage();
            this.actors = new System.Windows.Forms.TreeView();
            this.tabQuests = new System.Windows.Forms.TabPage();
            this.questTree = new System.Windows.Forms.TreeView();
            this.tabRawData = new System.Windows.Forms.TabPage();
            this.input = new System.Windows.Forms.RichTextBox();
            this.panel_mdump = new System.Windows.Forms.Panel();
            this.panel_mdump_header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_mdump_content_ = new System.Windows.Forms.Panel();
            this.panel_mdump_subcontent = new System.Windows.Forms.Panel();
            this.output = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.panel_mainframe.SuspendLayout();
            this.panel_messages.SuspendLayout();
            this.panel_messages_header.SuspendLayout();
            this.panel_messages_content.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabActors.SuspendLayout();
            this.tabQuests.SuspendLayout();
            this.tabRawData.SuspendLayout();
            this.panel_mdump.SuspendLayout();
            this.panel_mdump_header.SuspendLayout();
            this.panel_mdump_content_.SuspendLayout();
            this.panel_mdump_subcontent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openPreparsedDumpToolStripMenuItem
            // 
            this.openPreparsedDumpToolStripMenuItem.Name = "openPreparsedDumpToolStripMenuItem";
            this.openPreparsedDumpToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.openPreparsedDumpToolStripMenuItem.Text = "Open...";
            this.openPreparsedDumpToolStripMenuItem.Click += new System.EventHandler(this.openPreparsedDumpToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(129, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
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
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // messageFilterToolStripMenuItem
            // 
            this.messageFilterToolStripMenuItem.Name = "messageFilterToolStripMenuItem";
            this.messageFilterToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.messageFilterToolStripMenuItem.Text = "Message filter...";
            this.messageFilterToolStripMenuItem.Click += new System.EventHandler(this.messageFilterToolStripMenuItem_Click);
            // 
            // findAllMessagesToolStripMenuItem
            // 
            this.findAllMessagesToolStripMenuItem.Name = "findAllMessagesToolStripMenuItem";
            this.findAllMessagesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.findAllMessagesToolStripMenuItem.Text = "Find all messages...";
            this.findAllMessagesToolStripMenuItem.Click += new System.EventHandler(this.findAllMessagesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 6);
            // 
            // trySNOAliasesToolStripMenuItem
            // 
            this.trySNOAliasesToolStripMenuItem.Checked = true;
            this.trySNOAliasesToolStripMenuItem.CheckOnClick = true;
            this.trySNOAliasesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trySNOAliasesToolStripMenuItem.Name = "trySNOAliasesToolStripMenuItem";
            this.trySNOAliasesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.trySNOAliasesToolStripMenuItem.Text = "Try SNO Aliases";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.aboutToolStripMenuItem1.Text = "About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // panel_mainframe
            // 
            this.panel_mainframe.AutoScroll = true;
            this.panel_mainframe.Controls.Add(this.tabControl1);
            this.panel_mainframe.Controls.Add(this.splitter2);
            this.panel_mainframe.Controls.Add(this.panel_mdump);
            this.panel_mainframe.Controls.Add(this.splitter1);
            this.panel_mainframe.Controls.Add(this.panel_messages);
            this.panel_mainframe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_mainframe.Location = new System.Drawing.Point(0, 24);
            this.panel_mainframe.Name = "panel_mainframe";
            this.panel_mainframe.Size = new System.Drawing.Size(1028, 521);
            this.panel_mainframe.TabIndex = 12;
            // 
            // panel_messages
            // 
            this.panel_messages.Controls.Add(this.panel_messages_content);
            this.panel_messages.Controls.Add(this.panel_messages_header);
            this.panel_messages.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_messages.Location = new System.Drawing.Point(0, 0);
            this.panel_messages.Name = "panel_messages";
            this.panel_messages.Size = new System.Drawing.Size(174, 521);
            this.panel_messages.TabIndex = 12;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlText;
            this.splitter1.Location = new System.Drawing.Point(174, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 521);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // panel_messages_header
            // 
            this.panel_messages_header.AutoSize = true;
            this.panel_messages_header.Controls.Add(this.label2);
            this.panel_messages_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_messages_header.Location = new System.Drawing.Point(0, 0);
            this.panel_messages_header.Name = "panel_messages_header";
            this.panel_messages_header.Size = new System.Drawing.Size(174, 13);
            this.panel_messages_header.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Message browser";
            // 
            // panel_messages_content
            // 
            this.panel_messages_content.Controls.Add(this.tree);
            this.panel_messages_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_messages_content.Location = new System.Drawing.Point(0, 13);
            this.panel_messages_content.Name = "panel_messages_content";
            this.panel_messages_content.Size = new System.Drawing.Size(174, 508);
            this.panel_messages_content.TabIndex = 16;
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(174, 508);
            this.tree.TabIndex = 5;
            this.tree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterCollapse);
            this.tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeExpand);
            this.tree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterExpand);
            this.tree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeSelect);
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ControlText;
            this.splitter2.Location = new System.Drawing.Point(448, 0);
            this.splitter2.MinExtra = 3;
            this.splitter2.MinSize = 3;
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 521);
            this.splitter2.TabIndex = 15;
            this.splitter2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabActors);
            this.tabControl1.Controls.Add(this.tabQuests);
            this.tabControl1.Controls.Add(this.tabRawData);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(453, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(575, 521);
            this.tabControl1.TabIndex = 18;
            // 
            // tabActors
            // 
            this.tabActors.Controls.Add(this.actors);
            this.tabActors.Location = new System.Drawing.Point(4, 22);
            this.tabActors.Name = "tabActors";
            this.tabActors.Padding = new System.Windows.Forms.Padding(3);
            this.tabActors.Size = new System.Drawing.Size(567, 495);
            this.tabActors.TabIndex = 0;
            this.tabActors.Text = "Actors";
            this.tabActors.UseVisualStyleBackColor = true;
            // 
            // actors
            // 
            this.actors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actors.Location = new System.Drawing.Point(3, 3);
            this.actors.Name = "actors";
            this.actors.Size = new System.Drawing.Size(561, 489);
            this.actors.TabIndex = 5;
            this.actors.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.groupedNode_AfterSelect);
            // 
            // tabQuests
            // 
            this.tabQuests.Controls.Add(this.questTree);
            this.tabQuests.Location = new System.Drawing.Point(4, 22);
            this.tabQuests.Name = "tabQuests";
            this.tabQuests.Size = new System.Drawing.Size(567, 495);
            this.tabQuests.TabIndex = 2;
            this.tabQuests.Text = "Quests";
            this.tabQuests.UseVisualStyleBackColor = true;
            // 
            // questTree
            // 
            this.questTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questTree.Location = new System.Drawing.Point(0, 0);
            this.questTree.Name = "questTree";
            this.questTree.Size = new System.Drawing.Size(567, 495);
            this.questTree.TabIndex = 0;
            this.questTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.groupedNode_AfterSelect);
            // 
            // tabRawData
            // 
            this.tabRawData.Controls.Add(this.input);
            this.tabRawData.Location = new System.Drawing.Point(4, 22);
            this.tabRawData.Name = "tabRawData";
            this.tabRawData.Padding = new System.Windows.Forms.Padding(3);
            this.tabRawData.Size = new System.Drawing.Size(567, 495);
            this.tabRawData.TabIndex = 1;
            this.tabRawData.Text = "Raw data view";
            this.tabRawData.UseVisualStyleBackColor = true;
            // 
            // input
            // 
            this.input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input.Location = new System.Drawing.Point(3, 3);
            this.input.Name = "input";
            this.input.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.input.Size = new System.Drawing.Size(561, 489);
            this.input.TabIndex = 3;
            this.input.Text = "";
            // 
            // panel_mdump
            // 
            this.panel_mdump.Controls.Add(this.panel_mdump_content_);
            this.panel_mdump.Controls.Add(this.panel_mdump_header);
            this.panel_mdump.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_mdump.Location = new System.Drawing.Point(179, 0);
            this.panel_mdump.Name = "panel_mdump";
            this.panel_mdump.Size = new System.Drawing.Size(269, 521);
            this.panel_mdump.TabIndex = 14;
            // 
            // panel_mdump_header
            // 
            this.panel_mdump_header.AutoSize = true;
            this.panel_mdump_header.Controls.Add(this.label1);
            this.panel_mdump_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_mdump_header.Location = new System.Drawing.Point(0, 0);
            this.panel_mdump_header.Name = "panel_mdump_header";
            this.panel_mdump_header.Size = new System.Drawing.Size(269, 13);
            this.panel_mdump_header.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Message dump";
            // 
            // panel_mdump_content_
            // 
            this.panel_mdump_content_.AutoSize = true;
            this.panel_mdump_content_.Controls.Add(this.panel_mdump_subcontent);
            this.panel_mdump_content_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_mdump_content_.Location = new System.Drawing.Point(0, 13);
            this.panel_mdump_content_.Name = "panel_mdump_content_";
            this.panel_mdump_content_.Size = new System.Drawing.Size(269, 508);
            this.panel_mdump_content_.TabIndex = 5;
            // 
            // panel_mdump_subcontent
            // 
            this.panel_mdump_subcontent.Controls.Add(this.output);
            this.panel_mdump_subcontent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_mdump_subcontent.Location = new System.Drawing.Point(0, 0);
            this.panel_mdump_subcontent.Name = "panel_mdump_subcontent";
            this.panel_mdump_subcontent.Size = new System.Drawing.Size(269, 508);
            this.panel_mdump_subcontent.TabIndex = 4;
            // 
            // output
            // 
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Location = new System.Drawing.Point(0, 0);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(269, 508);
            this.output.TabIndex = 5;
            this.output.Text = "";
            this.output.MouseClick += new System.Windows.Forms.MouseEventHandler(this.output_MouseClick);
            this.output.MouseMove += new System.Windows.Forms.MouseEventHandler(this.output_MouseMove);
            // 
            // MessageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 545);
            this.Controls.Add(this.panel_mainframe);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MessageViewer";
            this.Text = "GS Message Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_mainframe.ResumeLayout(false);
            this.panel_messages.ResumeLayout(false);
            this.panel_messages.PerformLayout();
            this.panel_messages_header.ResumeLayout(false);
            this.panel_messages_header.PerformLayout();
            this.panel_messages_content.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabActors.ResumeLayout(false);
            this.tabQuests.ResumeLayout(false);
            this.tabRawData.ResumeLayout(false);
            this.panel_mdump.ResumeLayout(false);
            this.panel_mdump.PerformLayout();
            this.panel_mdump_header.ResumeLayout(false);
            this.panel_mdump_header.PerformLayout();
            this.panel_mdump_content_.ResumeLayout(false);
            this.panel_mdump_subcontent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem findAllMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPreparsedDumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trySNOAliasesToolStripMenuItem;
        private System.Windows.Forms.Panel panel_mainframe;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel_messages;
        private System.Windows.Forms.Panel panel_messages_header;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_messages_content;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabActors;
        private System.Windows.Forms.TreeView actors;
        private System.Windows.Forms.TabPage tabQuests;
        private System.Windows.Forms.TreeView questTree;
        private System.Windows.Forms.TabPage tabRawData;
        private System.Windows.Forms.RichTextBox input;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel_mdump;
        private System.Windows.Forms.Panel panel_mdump_content_;
        private System.Windows.Forms.Panel panel_mdump_subcontent;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Panel panel_mdump_header;
        private System.Windows.Forms.Label label1;

    }
}


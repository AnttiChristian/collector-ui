
namespace Collector.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenRedumpDatFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTosecDatFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenNointroFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScannerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConverterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsoBinConverterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BinIsoConvertMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComapreCdromImagesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateToolButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.DatabaseTreeView = new System.Windows.Forms.TreeView();
            this.DumpsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.ScannerMenuItem,
            this.ConverterMenuItem,
            this.ToolsMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenRedumpDatFileMenuItem,
            this.OpenTosecDatFileMenuItem,
            this.OpenNointroFileMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileMenuItem.Text = "File";
            // 
            // OpenRedumpDatFileMenuItem
            // 
            this.OpenRedumpDatFileMenuItem.Name = "OpenRedumpDatFileMenuItem";
            this.OpenRedumpDatFileMenuItem.Size = new System.Drawing.Size(187, 22);
            this.OpenRedumpDatFileMenuItem.Text = "Open Redump datfile";
            this.OpenRedumpDatFileMenuItem.Click += new System.EventHandler(this.OpenDatFileMenuItem_Click);
            // 
            // OpenTosecDatFileMenuItem
            // 
            this.OpenTosecDatFileMenuItem.Name = "OpenTosecDatFileMenuItem";
            this.OpenTosecDatFileMenuItem.Size = new System.Drawing.Size(187, 22);
            this.OpenTosecDatFileMenuItem.Text = "Open TOSEC datfile";
            this.OpenTosecDatFileMenuItem.Click += new System.EventHandler(this.OpenTosecDatFileMenuItem_Click);
            // 
            // OpenNointroFileMenuItem
            // 
            this.OpenNointroFileMenuItem.Name = "OpenNointroFileMenuItem";
            this.OpenNointroFileMenuItem.Size = new System.Drawing.Size(187, 22);
            this.OpenNointroFileMenuItem.Text = "Open Nointro datfile";
            this.OpenNointroFileMenuItem.Click += new System.EventHandler(this.OpenNointroFileMenuItem_Click);
            // 
            // ScannerMenuItem
            // 
            this.ScannerMenuItem.Name = "ScannerMenuItem";
            this.ScannerMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ScannerMenuItem.Text = "Scanner";
            this.ScannerMenuItem.Click += new System.EventHandler(this.ScannerMenuItem_Click);
            // 
            // ConverterMenuItem
            // 
            this.ConverterMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IsoBinConverterMenuItem,
            this.BinIsoConvertMenuItem});
            this.ConverterMenuItem.Name = "ConverterMenuItem";
            this.ConverterMenuItem.Size = new System.Drawing.Size(71, 20);
            this.ConverterMenuItem.Text = "Converter";
            // 
            // IsoBinConverterMenuItem
            // 
            this.IsoBinConverterMenuItem.Name = "IsoBinConverterMenuItem";
            this.IsoBinConverterMenuItem.Size = new System.Drawing.Size(124, 22);
            this.IsoBinConverterMenuItem.Text = "ISO->BIN";
            this.IsoBinConverterMenuItem.Click += new System.EventHandler(this.IsoBinConverterMenuItem_Click);
            // 
            // BinIsoConvertMenuItem
            // 
            this.BinIsoConvertMenuItem.Name = "BinIsoConvertMenuItem";
            this.BinIsoConvertMenuItem.Size = new System.Drawing.Size(124, 22);
            this.BinIsoConvertMenuItem.Text = "BIN->ISO";
            this.BinIsoConvertMenuItem.Click += new System.EventHandler(this.BinIsoConvertMenuItem_Click);
            // 
            // ToolsMenuItem
            // 
            this.ToolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComapreCdromImagesMenuItem});
            this.ToolsMenuItem.Name = "ToolsMenuItem";
            this.ToolsMenuItem.Size = new System.Drawing.Size(46, 20);
            this.ToolsMenuItem.Text = "Tools";
            // 
            // ComapreCdromImagesMenuItem
            // 
            this.ComapreCdromImagesMenuItem.Name = "ComapreCdromImagesMenuItem";
            this.ComapreCdromImagesMenuItem.Size = new System.Drawing.Size(204, 22);
            this.ComapreCdromImagesMenuItem.Text = "Compare Cdrom Images";
            this.ComapreCdromImagesMenuItem.Click += new System.EventHandler(this.ComapreCdromImagesMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolButton,
            this.toolStripSeparator1,
            this.UpdateToolButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenToolButton
            // 
            this.OpenToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenToolButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolButton.Image")));
            this.OpenToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenToolButton.Name = "OpenToolButton";
            this.OpenToolButton.Size = new System.Drawing.Size(23, 22);
            this.OpenToolButton.Text = "DB";
            this.OpenToolButton.Click += new System.EventHandler(this.OpenToolButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // UpdateToolButton
            // 
            this.UpdateToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UpdateToolButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateToolButton.Image")));
            this.UpdateToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateToolButton.Name = "UpdateToolButton";
            this.UpdateToolButton.Size = new System.Drawing.Size(23, 22);
            this.UpdateToolButton.Text = "toolStripButton1";
            this.UpdateToolButton.Click += new System.EventHandler(this.UpdateToolButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 379);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.DatabaseTreeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.DumpsListView);
            this.splitContainer2.Size = new System.Drawing.Size(800, 266);
            this.splitContainer2.SplitterDistance = 266;
            this.splitContainer2.TabIndex = 0;
            // 
            // DatabaseTreeView
            // 
            this.DatabaseTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseTreeView.Location = new System.Drawing.Point(0, 0);
            this.DatabaseTreeView.Name = "DatabaseTreeView";
            this.DatabaseTreeView.Size = new System.Drawing.Size(266, 266);
            this.DatabaseTreeView.TabIndex = 0;
            this.DatabaseTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DatabaseTreeView_AfterSelect);
            // 
            // DumpsListView
            // 
            this.DumpsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.DumpsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DumpsListView.GridLines = true;
            this.DumpsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.DumpsListView.HideSelection = false;
            this.DumpsListView.Location = new System.Drawing.Point(0, 0);
            this.DumpsListView.Name = "DumpsListView";
            this.DumpsListView.Size = new System.Drawing.Size(530, 266);
            this.DumpsListView.TabIndex = 0;
            this.DumpsListView.UseCompatibleStateImageBehavior = false;
            this.DumpsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 360;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Collector TT";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenRedumpDatFileMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView DumpsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripMenuItem ScannerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConverterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IsoBinConverterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BinIsoConvertMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenTosecDatFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComapreCdromImagesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenNointroFileMenuItem;
        private System.Windows.Forms.TreeView DatabaseTreeView;
        private System.Windows.Forms.ToolStripButton OpenToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton UpdateToolButton;
    }
}


namespace PBS2
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.data0csvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.data1csvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.data2csvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.data3csvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.framecsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.backloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backclearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PosCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.PosStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.FixedPos = new System.Windows.Forms.ToolStripStatusLabel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.IntervalBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RepeatBox = new System.Windows.Forms.TextBox();
            this.LSRbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.OffsetBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.EditToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadStripMenuItem2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadStripMenuItem2
            // 
            this.loadStripMenuItem2.Name = "loadStripMenuItem2";
            resources.ApplyResources(this.loadStripMenuItem2, "loadStripMenuItem2");
            this.loadStripMenuItem2.Click += new System.EventHandler(this.loadStripMenuItem2_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.data0csvToolStripMenuItem,
            this.data1csvToolStripMenuItem,
            this.data2csvToolStripMenuItem,
            this.data3csvToolStripMenuItem,
            this.framecsvToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // data0csvToolStripMenuItem
            // 
            this.data0csvToolStripMenuItem.Name = "data0csvToolStripMenuItem";
            resources.ApplyResources(this.data0csvToolStripMenuItem, "data0csvToolStripMenuItem");
            this.data0csvToolStripMenuItem.Click += new System.EventHandler(this.data0csvToolStripMenuItem_Click);
            // 
            // data1csvToolStripMenuItem
            // 
            this.data1csvToolStripMenuItem.Name = "data1csvToolStripMenuItem";
            resources.ApplyResources(this.data1csvToolStripMenuItem, "data1csvToolStripMenuItem");
            this.data1csvToolStripMenuItem.Click += new System.EventHandler(this.data1csvToolStripMenuItem_Click);
            // 
            // data2csvToolStripMenuItem
            // 
            this.data2csvToolStripMenuItem.Name = "data2csvToolStripMenuItem";
            resources.ApplyResources(this.data2csvToolStripMenuItem, "data2csvToolStripMenuItem");
            this.data2csvToolStripMenuItem.Click += new System.EventHandler(this.data2csvToolStripMenuItem_Click);
            // 
            // data3csvToolStripMenuItem
            // 
            this.data3csvToolStripMenuItem.Name = "data3csvToolStripMenuItem";
            resources.ApplyResources(this.data3csvToolStripMenuItem, "data3csvToolStripMenuItem");
            this.data3csvToolStripMenuItem.Click += new System.EventHandler(this.data3csvToolStripMenuItem_Click);
            // 
            // framecsvToolStripMenuItem
            // 
            this.framecsvToolStripMenuItem.Name = "framecsvToolStripMenuItem";
            resources.ApplyResources(this.framecsvToolStripMenuItem, "framecsvToolStripMenuItem");
            this.framecsvToolStripMenuItem.Click += new System.EventHandler(this.framecsvToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.backloadToolStripMenuItem,
            this.backclearToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            resources.ApplyResources(this.EditToolStripMenuItem, "EditToolStripMenuItem");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // backloadToolStripMenuItem
            // 
            this.backloadToolStripMenuItem.Name = "backloadToolStripMenuItem";
            resources.ApplyResources(this.backloadToolStripMenuItem, "backloadToolStripMenuItem");
            this.backloadToolStripMenuItem.Click += new System.EventHandler(this.backloadToolStripMenuItem_Click);
            // 
            // backclearToolStripMenuItem
            // 
            this.backclearToolStripMenuItem.Name = "backclearToolStripMenuItem";
            resources.ApplyResources(this.backclearToolStripMenuItem, "backclearToolStripMenuItem");
            this.backclearToolStripMenuItem.Click += new System.EventHandler(this.backclearToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PosCount,
            this.PosStatus,
            this.FixedPos});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            // 
            // PosCount
            // 
            this.PosCount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PosCount.Name = "PosCount";
            resources.ApplyResources(this.PosCount, "PosCount");
            // 
            // PosStatus
            // 
            this.PosStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PosStatus.Name = "PosStatus";
            resources.ApplyResources(this.PosStatus, "PosStatus");
            // 
            // FixedPos
            // 
            this.FixedPos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.FixedPos.Name = "FixedPos";
            resources.ApplyResources(this.FixedPos, "FixedPos");
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pic, "pic");
            this.pic.Name = "pic";
            this.pic.TabStop = false;
            // 
            // IntervalBox
            // 
            resources.ApplyResources(this.IntervalBox, "IntervalBox");
            this.IntervalBox.Name = "IntervalBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Name = "label2";
            // 
            // RepeatBox
            // 
            resources.ApplyResources(this.RepeatBox, "RepeatBox");
            this.RepeatBox.Name = "RepeatBox";
            // 
            // LSRbtn
            // 
            this.LSRbtn.BackColor = System.Drawing.Color.Transparent;
            this.LSRbtn.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.LSRbtn, "LSRbtn");
            this.LSRbtn.ForeColor = System.Drawing.Color.Black;
            this.LSRbtn.Name = "LSRbtn";
            this.LSRbtn.UseVisualStyleBackColor = false;
            this.LSRbtn.Click += new System.EventHandler(this.LSRbtn_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Name = "label3";
            // 
            // OffsetBox
            // 
            resources.ApplyResources(this.OffsetBox, "OffsetBox");
            this.OffsetBox.Name = "OffsetBox";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.OffsetBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LSRbtn);
            this.Controls.Add(this.RepeatBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IntervalBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel PosStatus;
        private System.Windows.Forms.ToolStripStatusLabel FixedPos;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.ToolStripStatusLabel PosCount;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.TextBox IntervalBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RepeatBox;
        private System.Windows.Forms.Button LSRbtn;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backclearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem data0csvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem data1csvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem data2csvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem data3csvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem framecsvToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OffsetBox;
    }
}


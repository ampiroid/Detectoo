namespace Detectoo
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reoGridControl1 = new unvell.ReoGrid.ReoGridControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkCumul = new System.Windows.Forms.CheckBox();
            this.cmbLog2 = new System.Windows.Forms.ComboBox();
            this.cmbLog1 = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlAx = new System.Windows.Forms.Panel();
            this.pnlCh = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCoor = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlAx.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(496, 404);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reoGridControl1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(488, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reoGridControl1
            // 
            this.reoGridControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.reoGridControl1.CellContextMenuStrip = null;
            this.reoGridControl1.ColCount = 100;
            this.reoGridControl1.ColHeadContextMenuStrip = null;
            this.reoGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reoGridControl1.Location = new System.Drawing.Point(2, 31);
            this.reoGridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.reoGridControl1.Name = "reoGridControl1";
            this.reoGridControl1.RowCount = 4000;
            this.reoGridControl1.RowHeadContextMenuStrip = null;
            this.reoGridControl1.Script = null;
            this.reoGridControl1.Size = new System.Drawing.Size(484, 345);
            this.reoGridControl1.TabIndex = 1;
            this.reoGridControl1.Text = "reoGridControl1";
            this.reoGridControl1.Click += new System.EventHandler(this.reoGridControl1_Click);
            this.reoGridControl1.DoubleClick += new System.EventHandler(this.reoGridControl1_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkCumul);
            this.panel1.Controls.Add(this.cmbLog2);
            this.panel1.Controls.Add(this.cmbLog1);
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 29);
            this.panel1.TabIndex = 3;
            // 
            // chkCumul
            // 
            this.chkCumul.AutoSize = true;
            this.chkCumul.Checked = true;
            this.chkCumul.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCumul.Location = new System.Drawing.Point(284, 7);
            this.chkCumul.Name = "chkCumul";
            this.chkCumul.Size = new System.Drawing.Size(78, 17);
            this.chkCumul.TabIndex = 8;
            this.chkCumul.Text = "Cumulative";
            this.chkCumul.UseVisualStyleBackColor = true;
            // 
            // cmbLog2
            // 
            this.cmbLog2.FormattingEnabled = true;
            this.cmbLog2.Location = new System.Drawing.Point(118, 5);
            this.cmbLog2.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLog2.Name = "cmbLog2";
            this.cmbLog2.Size = new System.Drawing.Size(67, 21);
            this.cmbLog2.TabIndex = 7;
            // 
            // cmbLog1
            // 
            this.cmbLog1.FormattingEnabled = true;
            this.cmbLog1.Location = new System.Drawing.Point(26, 5);
            this.cmbLog1.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLog1.Name = "cmbLog1";
            this.cmbLog1.Size = new System.Drawing.Size(68, 21);
            this.cmbLog1.TabIndex = 6;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(417, 3);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(56, 21);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "vs";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pnlAx);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(488, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chart";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlAx
            // 
            this.pnlAx.BackColor = System.Drawing.Color.White;
            this.pnlAx.Controls.Add(this.pnlCh);
            this.pnlAx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAx.Location = new System.Drawing.Point(2, 2);
            this.pnlAx.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAx.Name = "pnlAx";
            this.pnlAx.Size = new System.Drawing.Size(484, 347);
            this.pnlAx.TabIndex = 0;
            this.pnlAx.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAx_Paint);
            this.pnlAx.Resize += new System.EventHandler(this.pnlAx_Resize);
            // 
            // pnlCh
            // 
            this.pnlCh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCh.Location = new System.Drawing.Point(40, 2);
            this.pnlCh.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCh.Name = "pnlCh";
            this.pnlCh.Size = new System.Drawing.Size(444, 307);
            this.pnlCh.TabIndex = 0;
            this.pnlCh.Tag = "1.0";
            this.pnlCh.Click += new System.EventHandler(this.pnlCh_Click);
            this.pnlCh.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCh_Paint);
            this.pnlCh.DoubleClick += new System.EventHandler(this.pnlCh_DoubleClick);
            this.pnlCh.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCh_MouseDown);
            this.pnlCh.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlCh_MouseMove);
            this.pnlCh.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlCh_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lblCoor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 349);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 27);
            this.panel2.TabIndex = 1;
            // 
            // lblCoor
            // 
            this.lblCoor.AutoSize = true;
            this.lblCoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCoor.ForeColor = System.Drawing.Color.Maroon;
            this.lblCoor.Location = new System.Drawing.Point(6, 7);
            this.lblCoor.Name = "lblCoor";
            this.lblCoor.Size = new System.Drawing.Size(25, 13);
            this.lblCoor.TabIndex = 0;
            this.lblCoor.Text = "l; p";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.zedGraphControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(488, 378);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F10)));
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(488, 378);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 404);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.pnlAx.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private unvell.ReoGrid.ReoGridControl reoGridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlAx;
        private System.Windows.Forms.Panel pnlCh;
        private System.Windows.Forms.ComboBox cmbLog2;
        private System.Windows.Forms.ComboBox cmbLog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCoor;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkCumul;
        private ZedGraph.ZedGraphControl zedGraphControl1;
       
    }
}


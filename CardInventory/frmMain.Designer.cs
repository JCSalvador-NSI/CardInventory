
namespace CardInventory
{
    partial class frmMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCardList = new System.Windows.Forms.TabPage();
            this.tableLayoutControls = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWikiURL = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.tableLayoutCardList = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCardList = new System.Windows.Forms.DataGridView();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabCardList.SuspendLayout();
            this.tableLayoutControls.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutCardList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCardList);
            this.tabControl1.Controls.Add(this.tabInventory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1148, 539);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCardList
            // 
            this.tabCardList.Controls.Add(this.tableLayoutCardList);
            this.tabCardList.Controls.Add(this.tableLayoutControls);
            this.tabCardList.Location = new System.Drawing.Point(4, 34);
            this.tabCardList.Name = "tabCardList";
            this.tabCardList.Padding = new System.Windows.Forms.Padding(3);
            this.tabCardList.Size = new System.Drawing.Size(1140, 501);
            this.tabCardList.TabIndex = 0;
            this.tabCardList.Text = "Card List";
            this.tabCardList.UseVisualStyleBackColor = true;
            // 
            // tableLayoutControls
            // 
            this.tableLayoutControls.ColumnCount = 1;
            this.tableLayoutControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutControls.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutControls.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutControls.Name = "tableLayoutControls";
            this.tableLayoutControls.RowCount = 2;
            this.tableLayoutControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutControls.Size = new System.Drawing.Size(1134, 93);
            this.tableLayoutControls.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtWikiURL);
            this.flowLayoutPanel1.Controls.Add(this.btnProcess);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1128, 40);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Wiki URL :";
            // 
            // txtWikiURL
            // 
            this.txtWikiURL.Location = new System.Drawing.Point(128, 3);
            this.txtWikiURL.Name = "txtWikiURL";
            this.txtWikiURL.Size = new System.Drawing.Size(824, 31);
            this.txtWikiURL.TabIndex = 10;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(958, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(149, 31);
            this.btnProcess.TabIndex = 11;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // tableLayoutCardList
            // 
            this.tableLayoutCardList.ColumnCount = 1;
            this.tableLayoutCardList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCardList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCardList.Controls.Add(this.dgvCardList, 0, 0);
            this.tableLayoutCardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCardList.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutCardList.Name = "tableLayoutCardList";
            this.tableLayoutCardList.RowCount = 1;
            this.tableLayoutCardList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCardList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCardList.Size = new System.Drawing.Size(1134, 495);
            this.tableLayoutCardList.TabIndex = 1;
            // 
            // dgvCardList
            // 
            this.dgvCardList.AllowUserToAddRows = false;
            this.dgvCardList.AllowUserToDeleteRows = false;
            this.dgvCardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardList.Location = new System.Drawing.Point(3, 3);
            this.dgvCardList.Name = "dgvCardList";
            this.dgvCardList.RowHeadersVisible = false;
            this.dgvCardList.Size = new System.Drawing.Size(1128, 489);
            this.dgvCardList.TabIndex = 1;
            this.dgvCardList.VirtualMode = true;
            this.dgvCardList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCardList_CellContentClick);
            this.dgvCardList.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvCardList_RowPrePaint);
            // 
            // tabInventory
            // 
            this.tabInventory.Location = new System.Drawing.Point(4, 34);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tabInventory.Size = new System.Drawing.Size(1140, 501);
            this.tabInventory.TabIndex = 1;
            this.tabInventory.Text = "Inventory";
            this.tabInventory.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 539);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabCardList.ResumeLayout(false);
            this.tableLayoutControls.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutCardList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCardList;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCardList;
        private System.Windows.Forms.DataGridView dgvCardList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutControls;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtWikiURL;
    }
}
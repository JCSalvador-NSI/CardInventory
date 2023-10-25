
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutCardList = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCardList = new System.Windows.Forms.DataGridView();
            this.flowWikiURL = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWikiURL = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutCardList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).BeginInit();
            this.flowWikiURL.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1148, 539);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutCardList);
            this.tabPage1.Controls.Add(this.flowWikiURL);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1140, 501);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutCardList
            // 
            this.tableLayoutCardList.ColumnCount = 1;
            this.tableLayoutCardList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCardList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCardList.Controls.Add(this.dgvCardList, 0, 0);
            this.tableLayoutCardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCardList.Location = new System.Drawing.Point(3, 54);
            this.tableLayoutCardList.Name = "tableLayoutCardList";
            this.tableLayoutCardList.RowCount = 1;
            this.tableLayoutCardList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCardList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCardList.Size = new System.Drawing.Size(1134, 444);
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
            this.dgvCardList.Size = new System.Drawing.Size(1128, 438);
            this.dgvCardList.TabIndex = 1;
            this.dgvCardList.VirtualMode = true;
            this.dgvCardList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCardList_CellContentClick);
            this.dgvCardList.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvCardList_RowPrePaint);
            // 
            // flowWikiURL
            // 
            this.flowWikiURL.Controls.Add(this.label1);
            this.flowWikiURL.Controls.Add(this.txtWikiURL);
            this.flowWikiURL.Controls.Add(this.btnProcess);
            this.flowWikiURL.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowWikiURL.Location = new System.Drawing.Point(3, 3);
            this.flowWikiURL.Name = "flowWikiURL";
            this.flowWikiURL.Size = new System.Drawing.Size(1134, 51);
            this.flowWikiURL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wiki URL :";
            // 
            // txtWikiURL
            // 
            this.txtWikiURL.Location = new System.Drawing.Point(128, 3);
            this.txtWikiURL.Name = "txtWikiURL";
            this.txtWikiURL.Size = new System.Drawing.Size(779, 31);
            this.txtWikiURL.TabIndex = 4;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(913, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(149, 31);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1001, 501);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutCardList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).EndInit();
            this.flowWikiURL.ResumeLayout(false);
            this.flowWikiURL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowWikiURL;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtWikiURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCardList;
        private System.Windows.Forms.DataGridView dgvCardList;
    }
}
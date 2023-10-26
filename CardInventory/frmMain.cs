using CardInventory.API;
using CardInventory.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardInventory
{
    public partial class frmMain : Form
    {
        // Constants
        private const string INDEX_QTY_ADD = "colQtyAdd";
        private const string INDEX_QTY_REMOVE = "colQtyRemove";
        private const string INDEX_QTY_SAVE = "colQtySave";

        // Local scope variables
        private BindingList<Card> cardList = new BindingList<Card>();

        public frmMain()
        {
            InitializeComponent();
            this.Text = @"TCG Card Inventory";
        }

        private void ResizeDgvCardList()
        {
            bool isFull = this.WindowState == FormWindowState.Maximized;
            int dgv_width = dgvCardList.ClientRectangle.Width;
            dgvCardList.Columns[nameof(Card.SetCode)].Width = Convert.ToInt32(dgv_width * (isFull ? 0.08 : 0.14));
            dgvCardList.Columns[nameof(Card.Name)].Width = Convert.ToInt32(dgv_width * (isFull ? 0.23 : 0.21));
            dgvCardList.Columns[nameof(Card.JapaneseName)].Width = Convert.ToInt32(dgv_width * (isFull ? 0.17 : 0.15));
            dgvCardList.Columns[nameof(Card.Rarity)].Width = Convert.ToInt32(dgv_width * (isFull ? 0.125 : 0.11));
            dgvCardList.Columns[nameof(Card.Category)].Width = Convert.ToInt32(dgv_width * (isFull ? 0.125 : 0.1));
            dgvCardList.Columns[nameof(Card.Quantity)].Width = Convert.ToInt32(dgv_width * (isFull ? 0.05 : 0.05));
            dgvCardList.Columns[nameof(Card.QtyModifier)].Width = Convert.ToInt32(dgv_width * (isFull ? 0.05 : 0.05));
            dgvCardList.Columns[INDEX_QTY_ADD].Width = Convert.ToInt32(dgv_width * (isFull ? 0.04 : 0.05));
            dgvCardList.Columns[INDEX_QTY_REMOVE].Width = Convert.ToInt32(dgv_width * (isFull ? 0.04 : 0.05));
            dgvCardList.Columns[INDEX_QTY_SAVE].Width = Convert.ToInt32(dgv_width * (isFull ? 0.08 : 0.08));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtWikiURL.Text = @"https://yugipedia.com/wiki/Burst_of_Destiny";//TODO: Remove
            //txtWikiURL.Text = YugipediaHelper.SanitizeUrl(@"https://yugipedia.com/wiki/Set_Card_Lists:Burst_of_Destiny_(OCG-JP)");//TODO: Remove
            //txtWikiURL.Text = YugipediaHelper.SanitizeUrl(@"https://yugipedia.com/wiki/Set_Card_Lists:Structure_Deck:_Forest_of_the_Traptrix_(OCG-JP)");//TODO: Remove
            dgvCardList.DataSource = new BindingSource() { DataSource = cardList };

            // Add 'quantity' modifier columns
            var dictQtyModifier = new List<Tuple<string, string, string>>()
            {
                Tuple.Create(INDEX_QTY_ADD, "", "+"),
                Tuple.Create(INDEX_QTY_REMOVE, "", "-"),
                Tuple.Create(INDEX_QTY_SAVE, "", "SAVE"),
            };
            
            foreach (var pair in dictQtyModifier)
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn()
                {
                    Name = pair.Item1,
                    HeaderText = pair.Item2,
                    Text = pair.Item3,
                    Visible = true,
                    UseColumnTextForButtonValue = true,
                };
                dgvCardList.Columns.Add(btnColumn);
            }

            // Change header text and alignments
            dgvCardList.Columns[nameof(Card.Quantity)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCardList.Columns[nameof(Card.QtyModifier)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCardList.Columns[nameof(Card.Quantity)].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCardList.Columns[nameof(Card.QtyModifier)].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCardList.Columns[nameof(Card.SetCode)].HeaderText = "Code";
            dgvCardList.Columns[nameof(Card.Quantity)].HeaderText = "#";
            dgvCardList.Columns[nameof(Card.QtyModifier)].HeaderText = "±";
            dgvCardList.Columns[nameof(Card.JapaneseName)].HeaderText = "OCG Name";

            // Increase row height
            dgvCardList.RowTemplate.Height += 10;

            //cardList.Add(new Card("SET-001", "Sample Name", "Jap", "Common", "None"));
            ResizeDgvCardList();
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            string url = YugipediaHelper.SanitizeUrl(txtWikiURL.Text);
            var list = await YugipediaHelper.FetchList(url);
            if (list != null && list.Count > 0)
            {
                foreach (Card item in list)
                {
                    cardList.Add(item);
                }
                MessageBox.Show("loaded!");
            }
        }

        private void dgvCardList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var sender_grid = (DataGridView)sender;

            if (sender_grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var card_data = (Card)dgvCardList.Rows[e.RowIndex].DataBoundItem;
                var col_qty_add = dgvCardList.Columns[INDEX_QTY_ADD];
                var col_qty_remove = dgvCardList.Columns[INDEX_QTY_REMOVE];
                var col_qty_save = dgvCardList.Columns[INDEX_QTY_SAVE];

                if (card_data != null)
                {
                    string card_name = card_data.Name;

                    if (col_qty_add != null && e.ColumnIndex == col_qty_add.Index)
                    {
                        card_data.QtyModifier += 1;
                        sender_grid.Refresh();
                        MessageBox.Show($"Add qty to { card_name }");
                    }
                    if (col_qty_remove != null && e.ColumnIndex == col_qty_remove.Index)
                    {
                        card_data.QtyModifier -= 1;
                        sender_grid.Refresh();
                        MessageBox.Show($"Removed qty to { card_name }");
                    }
                    if (col_qty_save != null && e.ColumnIndex == col_qty_save.Index)
                    {
                        card_data.Quantity += card_data.QtyModifier;
                        card_data.QtyModifier = 0;
                        sender_grid.Refresh();
                        MessageBox.Show($"New quantity saved for { card_name }");
                    }
                }
            }   
        }

        private void dgvCardList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //UI: Change row color depending on Card type.
            if (e.RowIndex >= 0)
            {
                var card = (Card)dgvCardList.Rows[e.RowIndex].DataBoundItem;
                if (card != null)
                {
                    Color col_fore = dgvCardList.Rows[e.RowIndex].DefaultCellStyle.ForeColor;
                    Color col_back = dgvCardList.Rows[e.RowIndex].DefaultCellStyle.BackColor;
                    string card_cat = card.Category.Trim().ToUpper();
                    
                    if (card_cat.Contains("MONSTER"))
                    {
                        if (card_cat.Contains("PENDULUM"))
                        {
                            col_back = Color.ForestGreen;
                        }
                        else if (card_cat.Contains("XYZ"))
                        {
                            col_back = Color.Black;
                            col_fore = Color.WhiteSmoke;
                        }
                        else if (card_cat.Contains("LINK"))
                        {
                            col_back = Color.Blue;
                            col_fore = Color.WhiteSmoke;
                        }
                        else if (card_cat.Contains("SYNCHRO"))
                        {
                            col_back = Color.FloralWhite;
                            col_fore = Color.Black;
                        }
                        else if (card_cat.Contains("FUSION"))
                        {
                            col_back = Color.MediumVioletRed;
                        }
                        else if (card_cat.Contains("RITUAL"))
                        {
                            col_back = Color.DeepSkyBlue;
                        }
                        else if (card_cat.Contains("EFFECT") || card_cat.Contains("FLIP") || card_cat.Contains("SPIRIT") || card_cat.Contains("GEMINI"))
                        {
                            col_back = Color.Coral;
                        }
                        else if (card_cat.Contains("NORMAL"))
                        {
                            col_back = Color.Khaki;
                        }
                    }
                    else if (card_cat.Contains("SPELL"))
                    {
                        col_back = Color.LimeGreen;
                    }
                    else if (card_cat.Contains("TRAP"))
                    {
                        col_back = Color.IndianRed;
                    }

                    dgvCardList.Rows[e.RowIndex].DefaultCellStyle.BackColor = col_back;
                    dgvCardList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = col_fore;
                }
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            ResizeDgvCardList();
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            ExportFormats.ExportCSV(cardList.ToList());
        }
    }
}

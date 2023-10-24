﻿using CardInventory.API;
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
        private const string INDEX_QTY_ADD = "colAdd";
        private const string INDEX_QTY_REMOVE = "colRemove";
        private const string INDEX_QTY_MODIFIER = nameof(Card.QtyModifier);
        private const string INDEX_QTY = nameof(Card.Quantity);
        // Local scope variables
        private BindingList<Card> cardList = new BindingList<Card>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtWikiURL.Text = @"https://yugipedia.com/wiki/Set_Card_Lists:Burst_of_Destiny_(OCG-JP)";//TODO: Remove
            dgvCardList.DataSource = new BindingSource() { DataSource = cardList };

            // Add 'quantity' modifier columns
            var dictQtyModifier = new List<Tuple<string, string, string>>()
            {
                Tuple.Create(INDEX_QTY_ADD, "Add", "+"),
                Tuple.Create(INDEX_QTY_REMOVE, "Remove", "-"),
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
            dgvCardList.Columns[INDEX_QTY_MODIFIER].HeaderText = "Modifier";
            dgvCardList.Columns[INDEX_QTY_MODIFIER].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCardList.Columns[INDEX_QTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            cardList.Add(new Card("SET-001", "Sample Name", "Jap", "Common", "None"));
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            var list = await YugipediaHelper.FetchList(txtWikiURL.Text);
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
                string card_name = "";

                if (card_data != null)
                    card_name = card_data.Name;

                if (col_qty_add != null && e.ColumnIndex == col_qty_add.Index)
                    MessageBox.Show($"Add qty to { card_name }");

                if (col_qty_remove != null && e.ColumnIndex == col_qty_remove.Index)
                    MessageBox.Show($"Removed qty to { card_name }");
            }   
        }
    }
}

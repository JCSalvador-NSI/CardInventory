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

            cardList.Add(new Card("SET-001", "Sample Name", "Jap", "Common", "None"));
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            await YugipediaHelper.FetchList(txtWikiURL.Text);
        }
    }
}

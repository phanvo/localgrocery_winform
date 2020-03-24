using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PV_Assign2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            Grocery a = new Grocery();
            a.ItemName = "asdasaf";
            a.ItemCode = "778237-32423-2";
            a.UnitPrice = 33.7;
            a.StartingQty = 11;
            a.QtyMinForRestock = 5;
            a.QtySold = 0;
            a.QtyRestocked = 8;

            groceryListBox.Items.Add(a);
        }
    }
}

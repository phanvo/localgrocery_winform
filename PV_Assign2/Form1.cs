using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PV_Assign2
{
    public partial class Form1 : Form
    {
        private List<Grocery> groceryList = new List<Grocery>();

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            //Read from file method using file name
            ReadFromFile("localgrocery.csv");
        }

        private void ReadFromFile(string fileName)
        {
            try
            {
                //remove all elements of groceryList and groceryListBox 
                groceryList.Clear();
                groceryListBox.Items.Clear();

                using (StreamReader myInputStream = new StreamReader(fileName))
                {
                    if (!myInputStream.EndOfStream)
                    {
                        //Header Line or first line of file typically has column names or header names (no numeric data), 
                        //so it must be treated different 
                        //than other lines in the file
                        string headerLine = myInputStream.ReadLine();
                        string[] fieldsArray = headerLine.Split(',');
                        headerLine = String.Format("{0, -25}{1, -15}{2, -15}{3, -15}{4, -20}{5, -15}{6, -15}{7, -15}{8, -15}",
                                                    fieldsArray[0], fieldsArray[1], fieldsArray[2], fieldsArray[3],
                                                    fieldsArray[4], fieldsArray[5], fieldsArray[6], "QtyHand", "Sales");

                        groceryListBox.Items.Add(headerLine);
                    }
                    
                    while (!myInputStream.EndOfStream)
                    {
                        string eachLine = myInputStream.ReadLine();
                        string[] fieldsArray = eachLine.Split(',');
                        string itemName = fieldsArray[0].Trim();
                        string itemCode = fieldsArray[1].Trim();
                        double.TryParse(fieldsArray[2], out double unitPrice);
                        int.TryParse(fieldsArray[3], out int startingQty);
                        int.TryParse(fieldsArray[4], out int qtyMinForRestock);
                        int.TryParse(fieldsArray[5], out int qtySold);
                        int.TryParse(fieldsArray[6], out int qtyRestocked);

                        Grocery item = new Grocery(itemName, itemCode, unitPrice, startingQty,
                                                             qtyMinForRestock, qtySold, qtyRestocked);

                        groceryListBox.Items.Add(item);

                        groceryList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

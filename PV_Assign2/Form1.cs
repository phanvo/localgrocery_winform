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
        private string headerLine;

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
                //remove all elements of groceryList 
                groceryList.Clear();
                //groceryListBox.Items.Clear();

                using (StreamReader myInputStream = new StreamReader(fileName))
                {
                    if (!myInputStream.EndOfStream)
                    {
                        //Header Line or first line of file typically has column names or header names (no numeric data), 
                        //so it must be treated different 
                        //than other lines in the file
                        headerLine = myInputStream.ReadLine();
                        string[] fieldsArray = headerLine.Split(',');
                        headerLine = String.Format("{0, -25}{1, -15}{2, -15}{3, -15}{4, -20}{5, -15}{6, -15}{7, -15}{8, -15}",
                                                    fieldsArray[0], fieldsArray[1], fieldsArray[2], fieldsArray[3],
                                                    fieldsArray[4], fieldsArray[5], fieldsArray[6], "QtyHand", "Sales");

                        //groceryListBox.Items.Add(headerLine);
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

                        //Grocery item = new Grocery(itemName, itemCode, unitPrice, startingQty,
                        //                                     qtyMinForRestock, qtySold, qtyRestocked);

                        //groceryListBox.Items.Add(item);

                        groceryList.Add(new Grocery(itemName, itemCode, unitPrice, startingQty,
                                                             qtyMinForRestock, qtySold, qtyRestocked));
                    }
                }

                LoadToGroceryListBox();

                statusLabel.Text = $"Loaded {groceryList.Count} items from the input file";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadToGroceryListBox(int oldSelectedIndex = 0)
        {
            //clear listbox and then load all shoal objects 
            //from shoal list to list box 

            //After clearing output list box, load all shoal objects from ShoalList list to output list box, 
            //ListBox contains a list of items, each item corresponds to one object coverted to String using
            //ToString() method defined in the class, and then add the string to the listbox
            //Make sure you understand the purpose of listbox and list of shoal objects, and the difference between
            //ShoalList and outputListBox here. outputListBox is just for viewing the data
            //ShoalList is the actual data

            groceryListBox.Items.Clear();

            groceryListBox.Items.Add(headerLine);

            foreach (Grocery item in groceryList)
            {
                groceryListBox.Items.Add(item);
            }

            if (oldSelectedIndex > 0)
            {
                groceryListBox.SelectedIndex = oldSelectedIndex;
            }
        }

        private void UpdateSoldQtyForSelectedItemButton_Click(object sender, EventArgs e)
        {
            UpdateSoldQtyForSelectedItem();
        }

        private void UpdateSoldQtyForSelectedItem()
        {
            if (groceryListBox.Items.Count == 0)
            {
                statusLabel.Text = "The grocery items list is empty!";
            }
            else if (groceryListBox.SelectedIndex == -1 || groceryListBox.SelectedIndex == 0)
            {
                statusLabel.Text = "Please select a grocery item to increment sold qty";
            }
            else
            {
                //MessageBox.Show(String.Format("{0}  -  {1}", groceryListBox.SelectedIndex, groceryList[groceryListBox.SelectedIndex - 1]));

                Grocery selectedItem = groceryList[groceryListBox.SelectedIndex - 1];
                
                int.TryParse(qtySoldTextBox.Text, out int qtySoldInput);
                if (qtySoldInput <= 0 || qtySoldInput > selectedItem.QtyHand)
                {
                    statusLabel.Text = "Invalid Quantity Sold input!";
                }
                else
                {
                    selectedItem.QtySold += qtySoldInput;

                    LoadToGroceryListBox(groceryListBox.SelectedIndex);

                    statusLabel.Text = $"Incremented Qty Sold for the item with Item Code {selectedItem.ItemCode}";
                }
            }
        }
    }
}

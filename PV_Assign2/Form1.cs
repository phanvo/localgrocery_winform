/* CSIS-1175-004_15063_202010 - Introduction to Programming
 * Student name: Vo, Phan Thu Nhat
 * Student ID: 300320809
 */

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

        private bool isValidGroceryItemToSelect(string funcStr)
        {
            if (groceryListBox.Items.Count == 0)
            {
                statusLabel.Text = "The grocery items list is empty!";
                return false;
            }
            else if (groceryListBox.SelectedIndex == -1 || groceryListBox.SelectedIndex == 0)
            {
                statusLabel.Text = "Please select a grocery item to " + funcStr;
                return false;
            }

            return true;
        }

        private void UpdateSoldQtyForSelectedItemButton_Click(object sender, EventArgs e)
        {
            UpdateSoldQtyForSelectedItem();
        }

        private void UpdateSoldQtyForSelectedItem()
        {
            if (!isValidGroceryItemToSelect("increment sold qty"))
                return;

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

        private void UpdateRestockedQtyForSelectedItemButton_Click(object sender, EventArgs e)
        {
            UpdateRestockedQtyForSelectedItem();
        }

        private void UpdateRestockedQtyForSelectedItem()
        {
            if (!isValidGroceryItemToSelect("increment restocked qty"))
                return;

            //MessageBox.Show(String.Format("{0}  -  {1}", groceryListBox.SelectedIndex, groceryList[groceryListBox.SelectedIndex - 1]));

            Grocery selectedItem = groceryList[groceryListBox.SelectedIndex - 1];

            int.TryParse(qtyRestockedTextBox.Text, out int qtyRestockedInput);
            if (qtyRestockedInput <= 0)
            {
                statusLabel.Text = "Invalid Quantity Restocked input!";
            }
            else
            {
                selectedItem.QtyRestocked += qtyRestockedInput;

                LoadToGroceryListBox(groceryListBox.SelectedIndex);

                statusLabel.Text = $"Incremented Restocked Qty for the item with Item Code {selectedItem.ItemCode}";
            }
        }

        private void DeleteSelectedItemButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedItem();
        }

        private void DeleteSelectedItem()
        {
            if (!isValidGroceryItemToSelect("delete"))
                return;

            //MessageBox.Show(String.Format("{0}  -  {1}", groceryListBox.SelectedIndex, groceryList[groceryListBox.SelectedIndex - 1]));

            string selectedItemCode = groceryList[groceryListBox.SelectedIndex - 1].ItemCode;

            groceryList.RemoveAt(groceryListBox.SelectedIndex - 1);
            groceryListBox.Items.RemoveAt(groceryListBox.SelectedIndex);

            statusLabel.Text = $"Deleted record for item with Item Code {selectedItemCode}";
        }

        private void WriteToFile(string fileName, int type = 1)
        {
            try
            {
                using (StreamWriter myOutputStream = new StreamWriter(fileName))
                {
                    //string headerLine = "Location\tState\tMileMarker" +
                    //    "\tLT1-LT2-LT3-LT4\tHT1-HT2-HT3";

                    //headerLine = System.Text.RegularExpressions.Regex.Replace(headerLine, @"\s+", ",");

                    string firstRow = "";
                    switch (type)
                    {
                        case 1:
                            firstRow = "ItemName,ItemCode,UnitPrice,StartingQty,QtyMinForRestock,QtySold,QtyRestocked";
                            break;
                        case 2:
                            firstRow = "ItemName,ItemCode,UnitPrice,QtySold,Sales";
                            break;
                        case 3:
                            firstRow = "ItemName,ItemCode,QtyHand,QtyMinForRestock";
                            break;
                    }

                    if (firstRow.Length > 0)
                        myOutputStream.WriteLine(firstRow);

                    int recordCount = 0;
                    foreach (Grocery item in groceryList)
                    {
                        string nextRow = "";

                        if (type == 1)
                        {
                            nextRow = item.ToString(1);
                        }
                        else if (type == 2 && item.QtySold > 0)
                        {
                            nextRow = item.ToString(2);
                        }
                        else if (type == 3 && item.QtyHand < item.QtyMinForRestock)
                        {
                            nextRow = item.ToString(3);
                        }

                        if (nextRow.Length > 0)
                        {
                            myOutputStream.WriteLine(nextRow);
                            recordCount++;
                        }
                    }

                    string fileInfo = "";
                    switch (type)
                    {
                        case 1:
                            fileInfo = "output inventory file";
                            break;
                        case 2:
                            fileInfo = "output sales file";
                            break;
                        case 3:
                            fileInfo = "restocks needed output file";
                            break;
                    }

                    if (fileInfo.Length > 0)
                        statusLabel.Text = $"Saved {recordCount} records into the " + fileInfo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveGroceryDataButton_Click(object sender, EventArgs e)
        {
            WriteToFile("updatedgrocery.csv", 1);
        }

        private void SaveSalesButton_Click(object sender, EventArgs e)
        {
            WriteToFile("grocerysales.csv", 2);
        }

        private void SaveRestockNeedsButton_Click(object sender, EventArgs e)
        {
            WriteToFile("groceryrestocks.csv", 3);
        }
    }
}

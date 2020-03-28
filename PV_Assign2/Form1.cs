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
        // list of grocery items to manipulate in the app
        private List<Grocery> groceryList = new List<Grocery>();

        public Form1()
        {
            // init UI components
            InitializeComponent();
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            // load grocery data from input file
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            try
            {
                //remove all elements of groceryList (for actual data) and groceryListBox items (for data to display on UI)
                groceryList.Clear();
                groceryListBox.Items.Clear();

                // open a file dialog box for user to select input file
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "CSV file|*.csv",          // CSV file only
                    Title = "Open a CSV File"           // dialog title
                };

                // if user selects a file and clicks Open, load that input file;
                // else, if user clicks Cancel, load the file "localgrocery.csv" by default
                string fileName = (openFileDialog.ShowDialog() == DialogResult.OK) ? openFileDialog.FileName : "localgrocery.csv";

                // start to process input file
                using (StreamReader myInputStream = new StreamReader(fileName))
                {
                    // check if the current stream position is end of stream
                    if (!myInputStream.EndOfStream)
                    {
                        // if not, process the first line, normally it is the header line
                        string headerLine = myInputStream.ReadLine();
                        string[] fieldsArray = headerLine.Split(',');       // split string into substrings with separator

                        // format string based on the default case of ToString() in Grocery class 
                        headerLine = $"{fieldsArray[0], -25}{fieldsArray[1], -15}{fieldsArray[2], -15}{fieldsArray[3], -15}" +
                                        $"{fieldsArray[4], -20}{fieldsArray[5], -15}{fieldsArray[6], -15}{"QtyHand", -15}{"Sales", -15}";

                        groceryListBox.Items.Add(headerLine);       // add it to groceryListBox items
                    }

                    // continue to check if the next line is end of stream
                    while (!myInputStream.EndOfStream)
                    {
                        // if not, process it
                        string eachLine = myInputStream.ReadLine();
                        string[] fieldsArray = eachLine.Split(',');     // split string into substrings with separator
                        string itemName = fieldsArray[0].Trim();        // remove leading and trailing white-space characters
                        string itemCode = fieldsArray[1].Trim();
                        double.TryParse(fieldsArray[2], out double unitPrice);         // try parse into corresponding data types
                        int.TryParse(fieldsArray[3], out int startingQty);
                        int.TryParse(fieldsArray[4], out int qtyMinForRestock);
                        int.TryParse(fieldsArray[5], out int qtySold);
                        int.TryParse(fieldsArray[6], out int qtyRestocked);

                        // init a grocery item from data above
                        Grocery item = new Grocery(itemName, itemCode, unitPrice, startingQty,
                                                                qtyMinForRestock, qtySold, qtyRestocked);

                        groceryList.Add(item);              // add it to groceryList
                        groceryListBox.Items.Add(item);     // add it to groceryListBox items
                    }
                }

                // update status label accordingly
                statusLabel.Text = $"Loaded {groceryList.Count} items from the input file";
            }
            catch (Exception ex)
            {
                // pop up exception messages if any
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsValidGroceryItemToSelect(string funcStr)
        {
            // check if grocery items list in UI is empty
            if (groceryListBox.Items.Count == 0)
            {
                statusLabel.Text = "The grocery items list is empty!";
                return false;
            }
            // check if no grocery item is selected or header line is selected
            else if (groceryListBox.SelectedIndex == -1 || groceryListBox.SelectedIndex == 0)
            {
                // display status based on function name given
                statusLabel.Text = "Please select a grocery item to " + funcStr;
                return false;
            }

            return true;
        }

        private void UpdateSoldQtyForSelectedItemButton_Click(object sender, EventArgs e)
        {
            // update sold quantity for selected grocery item
            UpdateSoldQtyForSelectedItem();
        }

        private void UpdateSoldQtyForSelectedItem()
        {
            try
            {
                // check if certain conditions are met before proceeding
                // if not valid, display error message and skip the rest of this method
                if (!IsValidGroceryItemToSelect("increment sold qty"))
                    return;

                // retrieve selected item based on index (not header line)
                Grocery selectedItem = groceryList[groceryListBox.SelectedIndex - 1];

                int.TryParse(qtySoldTextBox.Text, out int qtySoldInput);        // try parse sold input

                // check if sold input is less than or equal to 0, or greater than quantity on hand of selected item
                if (qtySoldInput <= 0 || qtySoldInput > selectedItem.QtyHand)
                {
                    statusLabel.Text = "Invalid Quantity Sold input!";      // display error message
                }
                else
                {
                    selectedItem.QtySold += qtySoldInput;       // else, increment quantity sold accordingly

                    groceryListBox.Items[groceryListBox.SelectedIndex] = selectedItem;  // update groceryListBox items accordingly

                    // update status label accordingly
                    statusLabel.Text = $"Incremented Qty Sold for item with Item Code {selectedItem.ItemCode}";
                }
            }
            catch (Exception ex)
            {
                // pop up exception messages if any
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateRestockedQtyForSelectedItemButton_Click(object sender, EventArgs e)
        {
            // update restocked quantity for selected grocery item
            UpdateRestockedQtyForSelectedItem();
        }

        private void UpdateRestockedQtyForSelectedItem()
        {
            try
            {
                // check if certain conditions are met before proceeding
                // if not valid, display error message and skip the rest of this method
                if (!IsValidGroceryItemToSelect("increment restocked qty"))
                    return;

                // retrieve selected item based on index (not header line)
                Grocery selectedItem = groceryList[groceryListBox.SelectedIndex - 1];

                int.TryParse(qtyRestockedTextBox.Text, out int qtyRestockedInput);  // try parse restocked input

                // check if restocked input is less than or equal to 0
                if (qtyRestockedInput <= 0)
                {
                    statusLabel.Text = "Invalid Quantity Restocked input!";     // display error message
                }
                else
                {
                    selectedItem.QtyRestocked += qtyRestockedInput;     // else, increment quantity restocked accordingly

                    groceryListBox.Items[groceryListBox.SelectedIndex] = selectedItem;  // update groceryListBox items accordingly

                    // update status label accordingly
                    statusLabel.Text = $"Incremented Restocked Qty for item with Item Code {selectedItem.ItemCode}";
                }
            }
            catch (Exception ex)
            {
                // pop up exception messages if any
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteSelectedItemButton_Click(object sender, EventArgs e)
        {
            // delete selected grocery item
            DeleteSelectedItem();
        }

        private void DeleteSelectedItem()
        {
            try
            {
                // check if certain conditions are met before proceeding
                // if not valid, display error message and skip the rest of this method
                if (!IsValidGroceryItemToSelect("delete"))
                    return;

                // retrieve item code from selected item (not header line) for status label
                string selectedItemCode = groceryList[groceryListBox.SelectedIndex - 1].ItemCode;

                groceryList.RemoveAt(groceryListBox.SelectedIndex - 1);         // remove selected item from groceryList
                groceryListBox.Items.RemoveAt(groceryListBox.SelectedIndex);    // remove selected item from groceryListBox items

                // update status label accordingly
                statusLabel.Text = $"Deleted record for item with Item Code {selectedItemCode}";
            }
            catch (Exception ex)
            {
                // pop up exception messages if any
                MessageBox.Show(ex.Message);
            }
        }

        private void WriteToFile(string fileName, int type = 1)
        {
            /* method to handle different cases of saving grocery items to file, based on type number
             * case 1: used for the function "Save Grocery Data (updatedgrocery.csv)"
             * case 2: used for the function "Save Sales Report (grocerysales.csv)"
             * case 3: used for the function "Save Restock Needs Report (groceryrestocks.csv)"
             */

            try
            {
                // open a file dialog for user to choose where to save output file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV file|*.csv",      // CSV file only
                    Title = "Save a CSV File",      // dialog title
                    FileName = fileName             // default file name, based on corresponding function
                };

                // check if user selects Save, then continue to process saving grocery items to file
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // start to process output file
                    using (StreamWriter myOutputStream = new StreamWriter(saveFileDialog.FileName))
                    {
                        // write header line based on each case
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

                        int recordCount = 0;    // keep track of number of grocery items written

                        // iterate each item over groceryList
                        foreach (Grocery item in groceryList)
                        {
                            string nextRow = "";

                            // write item to file based on each case
                            if (type == 1)                                              // current grocery items in list
                            {
                                nextRow = item.ToString(1);
                            }
                            else if (type == 2 && item.QtySold > 0)                     // if QtySold greater than 0
                            {
                                nextRow = item.ToString(2);
                            }
                            else if (type == 3 && item.QtyHand < item.QtyMinForRestock) // if QtyHand lesser than QtyMinForRestock
                            {
                                nextRow = item.ToString(3);
                            }

                            if (nextRow.Length > 0)
                            {
                                myOutputStream.WriteLine(nextRow);
                                recordCount++;
                            }
                        }

                        // update status label based on each case
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
                else
                {
                    // else, display message accordingly
                    statusLabel.Text = $"Save operation cancelled";
                }
            }
            catch (Exception ex)
            {
                // pop up exception messages if any
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveGroceryDataButton_Click(object sender, EventArgs e)
        {
            // save updated grocery data to file
            WriteToFile("updatedgrocery.csv", 1);
        }

        private void SaveSalesButton_Click(object sender, EventArgs e)
        {
            // save sales report data to file
            WriteToFile("grocerysales.csv", 2);
        }

        private void SaveRestockNeedsButton_Click(object sender, EventArgs e)
        {
            // save restock needs report data to file
            WriteToFile("groceryrestocks.csv", 3);
        }
    }
}

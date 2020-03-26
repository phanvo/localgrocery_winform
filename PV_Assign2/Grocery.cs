/* CSIS-1175-004_15063_202010 - Introduction to Programming
 * Student name: Vo, Phan Thu Nhat
 * Student ID: 300320809
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Assign2
{
    class Grocery
    {
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public double UnitPrice { get; set; }
        public int StartingQty { get; set; }
        public int QtyMinForRestock { get; set; }
        public int QtySold { get; set; }
        public int QtyRestocked { get; set; }

        public int QtyHand
        {
            get
            {
                return StartingQty - QtySold + QtyRestocked;
            }
        }

        public double TotalSales
        {
            get
            {
                return QtySold * UnitPrice;
            }
        }

        public Grocery(string anyItemName, string anyItemCode, double anyUnitPrice, int anyStartingQty,
                       int anyQtyMinForRestock, int anyQtySold, int anyQtyRestocked)
        {
            ItemName = anyItemName;
            ItemCode = anyItemCode;
            UnitPrice = anyUnitPrice;
            StartingQty = anyStartingQty;
            QtyMinForRestock = anyQtyMinForRestock;
            QtySold = anyQtySold;
            QtyRestocked = anyQtyRestocked;
        }

        public override string ToString()
        {
            return ToString();
        }

        public string ToString(int type = 0)
        {
            string outputStr = "";

            switch (type)
            {
                case 1:
                    outputStr = $"{ItemName},{ItemCode},{UnitPrice},{StartingQty},{QtyMinForRestock},{QtySold},{QtyRestocked}";
                    break;
                case 2:
                    outputStr = $"{ItemName},{ItemCode},{UnitPrice:C},{QtySold},{TotalSales:C}";
                    break;
                case 3:
                    outputStr = $"{ItemName},{ItemCode},{QtyHand},{QtyMinForRestock}";
                    break;
                default:
                    outputStr = "{0, -25}{1, -15}{2, -15:C2}{3, -15}{4, -20}{5, -15}{6, -15}{7, -15}{8, -15:C2}";
                    outputStr = String.Format(outputStr, ItemName, ItemCode, UnitPrice, StartingQty, QtyMinForRestock,
                                            QtySold, QtyRestocked, QtyHand, TotalSales);
                    break;
            }

            return outputStr;
        }
    }
}

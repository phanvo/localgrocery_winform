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

        public override string ToString()
        {
            string outputStr = "{0, -20}{1, -10}{2, -10}{3, -10}{4, -10}{5, -10}{6, -10}{7, -10}{8, -10}";
            return String.Format(outputStr, ItemName, ItemCode, UnitPrice, StartingQty, QtyMinForRestock,
                                            QtySold, QtyRestocked, QtyHand, TotalSales);
        }

    }
}

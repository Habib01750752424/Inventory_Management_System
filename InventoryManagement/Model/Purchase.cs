using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model
{
    public class Purchase
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductQty { get; set; }
        public string ProductUnit { get; set; }
        public double ProductPrice { get; set; }
        public double ProductTotal { get; set; }
        public string PurchaseDate { get; set; }
        public string PurchasePartyName { get; set; }
        public string PurchaseType { get; set; }
        public string ExpireDate { get; set; }
        public double Profit { get; set; }
    }
}

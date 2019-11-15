using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Model;
using InventoryManagement.Repository;

namespace InventoryManagement.BLL
{
     public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();
        Purchase purchase = new Purchase();

        public DataTable FillDD()
        {
            return _purchaseRepository.FillDD();
        }

        public DataTable FillLabel(string selectedProduct)
        {
            return _purchaseRepository.FillLabel(selectedProduct);
        }

        public DataTable FillDealerName()
        {
            return _purchaseRepository.FillDealerName();
        }

        public bool Add(Purchase purchase)
        {
            return _purchaseRepository.Add(purchase);
        }

        public bool IsStock(string product)
        {
            return _purchaseRepository.IsStock(product);
        }

        public bool AddStock(Purchase purchase)
        {
            return _purchaseRepository.AddStock(purchase);
        }

        public bool UpdateStock(Purchase purchase)
        {
            return _purchaseRepository.UpdateStock(purchase);
        }

        public DataTable Search(Purchase purchase)
        {
            return _purchaseRepository.Search(purchase);
        }

        public DataTable PriceSelect(Purchase purchase)
        {
            return _purchaseRepository.PriceSelect(purchase);
        }

        public DataTable SelectQuantity(Purchase purchase)
        {
            return _purchaseRepository.SelectQuantity(purchase);
        }

        public bool AddOrderUser(OrderUser orderUser)
        {
            return _purchaseRepository.AddOrderUser(orderUser);
        }

        public DataTable OUserId()
        {
            return _purchaseRepository.OUserId();
        }

        public bool AddOrderItem(OrderItem orderItem, int OrderUserId)
        {
            return _purchaseRepository.AddOrderItem(orderItem,OrderUserId);
        }

        public bool UpdateStockQty(OrderItem orderItem)
        {
            return _purchaseRepository.UpdateStockQty(orderItem);
        }
    }
}

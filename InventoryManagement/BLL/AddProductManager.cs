using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Model;
using InventoryManagement.Repository;
using System.Data;

namespace InventoryManagement.BLL
{
    public class AddProductManager
    {
        AddProductRepository _addProductRepository = new AddProductRepository();
        public List<_Unit> LoadUnit()
        {
            return _addProductRepository.LoadUnit();
        }

        public DataTable FillDD()
        {
            return _addProductRepository.FillDD();
        }

        public bool Add(string productName, string unit)
        {
            return _addProductRepository.Add(productName,unit);
        }

        public List<Product> Display()
        {
            return _addProductRepository.Display();
        }

        public DataTable SelectedUnit(int id)
        {
            return _addProductRepository.SelectedUnit(id);
        }

        public bool Update(string productName, string unit, int id)
        {
            return _addProductRepository.Update(productName,unit,id);
        }
    }
}

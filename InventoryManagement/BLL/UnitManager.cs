using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Model;
using InventoryManagement.Repository;

namespace InventoryManagement.BLL
{
    public class UnitManager
    {
        UnitRepository _unitRepository = new UnitRepository();
        public bool Add(_Unit unit)
        {
            return _unitRepository.Add(unit);
        }

        public List<_Unit> Display()
        {
           return _unitRepository.Display();
        }

        public bool Delete(int id)
        {
            return _unitRepository.Delete(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Model;
using InventoryManagement.Repository;

namespace InventoryManagement.BLL
{
    public class DealerManager
    {
        DealerRepository _dealerRepository = new DealerRepository();
        Dealer dealer = new Dealer();

        public bool Add(Dealer dealer)
        {
            return _dealerRepository.Add(dealer);
        }

        public List<Dealer> Display()
        {
            return _dealerRepository.Display();
        }

        public bool Update(Dealer dealer, int id)
        {
            return _dealerRepository.Update(dealer,id);
        }

        public bool Delete(int id)
        {
            return _dealerRepository.Delete(id);
        }
    }
}

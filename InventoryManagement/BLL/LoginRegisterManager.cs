using InventoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Repository;

namespace InventoryManagement.BLL
{
    public class LoginRegisterManager
    {
        LoginRegisterRepository _loginRegisterRepository = new LoginRegisterRepository();

        public bool Login(Register register)
        {
            return _loginRegisterRepository.Login(register);
        }

        public bool Add(Register register)
        {
            return _loginRegisterRepository.Add(register);
        }

        public List<Register> Display()
        {
            return _loginRegisterRepository.Display();
        }

        public bool IsCustomerExist(Register register)
        {
            return _loginRegisterRepository.IsCustomerExist(register);
        }

        public bool Delete(int id)
        {
            return _loginRegisterRepository.Delete(id);
        }
    }
}

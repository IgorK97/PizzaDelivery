using DTO;
using Interfaces.Services;
using Interfaces.Services.AuthenticationServices;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PizzaDelivery.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Accounts
{
    public class AccountStore : IAccountStore
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public bool IsClient {
            get
            {
                return _currentAccount is ClientDTO;
            }
        }
        public bool IsCourier {
            get
            {
                return _currentAccount is CouriersDto;
            }
        }
        public bool IsManager {
            get
            {
                return _currentAccount is ManagerDto;
            }
        }
        private UserDTO _currentAccount;
        public UserDTO CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            }
        }

        //private readonly IAccountService _accountService;

        //public AccountStore(IAccountService accountService)
        //{
        //    _accountService = accountService;
        //}

        

        public event Action StateChanged;
    }
}

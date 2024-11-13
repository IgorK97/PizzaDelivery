using DTO;
using Interfaces.Services;
using Interfaces.Services.AuthenticationServices;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

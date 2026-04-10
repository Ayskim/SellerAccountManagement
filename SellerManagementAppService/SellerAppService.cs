using System;
using System.Collections.Generic;
using SellerManagementDataService;
using SellerManagementModels;

namespace SellerManagementAppService
{
    public class SellerAppService
    {
        SellerDataService sellerDataService = new SellerDataService(new SellersDBData());
        public bool CreateAccount(SellerModels data)
        {
            if(data == null) return false;
            if (string.IsNullOrWhiteSpace(data.Username)) return false;
            if (string.IsNullOrWhiteSpace(data.SellerName)) return false;
            if (string.IsNullOrWhiteSpace(data.EmailAddress)) return false;
            if (string.IsNullOrWhiteSpace(data.PhoneNumber)) return false;
            if (sellerDataService.GetAccounts().Exists(x => x.Username == data.Username))return false;

            sellerDataService.Added(data);
            return true;
        }

        public SellerModels? SearchAccount(string username)
        {
            if(string.IsNullOrWhiteSpace(username)) return null; 
            return sellerDataService.Search(username);
        }

        public bool UpdateAccount(SellerModels data)
        {
            if (data == null) return false;
            if(string.IsNullOrWhiteSpace(data.Username)) return false;
            if(string.IsNullOrWhiteSpace(data.SellerName)) return false;
            if(string.IsNullOrWhiteSpace(data.EmailAddress)) return false;
            if(string.IsNullOrWhiteSpace(data.PhoneNumber)) return false;

            var existing = sellerDataService.Search(data.Username);

            if (existing == null)
                return false;

            sellerDataService.Update(data);
            return true;
        }

        public bool DeleteAccount(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;

            var existing = sellerDataService.Search(username);

            if (existing == null)
                return false;

            sellerDataService.Delete(username);
            return true;
        }
        public List<SellerModels> GetAccounts()
        {
            return sellerDataService.GetAccounts();
        }

         public List<SellerModels> ViewAccounts()
        {
            return sellerDataService.GetAccounts();
        }
    }
}
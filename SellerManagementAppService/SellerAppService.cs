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
            if (data == null) return false;
            if (string.IsNullOrWhiteSpace(data.Username)) return false;
            if (string.IsNullOrWhiteSpace(data.SellerName)) return false;

            if (sellerDataService.GetAccounts()
                .Exists(x => x.Username == data.Username))
                return false;

            sellerDataService.Added(data);
            return true;
        }

        public SellerModels? SearchAccount(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;
            return sellerDataService.Search(username);
        }

        public bool UpdateAccount(string originalUsername, SellerModels data)
        {
            if (data == null) return false;

            var existing = sellerDataService.Search(originalUsername);

            if (existing == null)
                return false;

            return sellerDataService.Update(originalUsername, data);
        }

        public bool DeleteAccount(string username)
        {
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
    }
}
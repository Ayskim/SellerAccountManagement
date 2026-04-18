using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SellerManagementModels;

namespace SellerManagementDataService
{
    public class SellerInMemoryData : ISellerDataService
    {
        public List<SellerModels> sellerAccounts = new List<SellerModels>();

        public void Added(SellerModels seller)
        {
            var list  = GetAccounts();
            if (!list.Exists(s => s.Username == seller.Username))
            {
                sellerAccounts.Add(seller);
            }
        }

        public SellerModels? Search(string username)
        {
            return sellerAccounts.Find(s => s.Username == username);
        }

        public void Update(string originalUsername, SellerModels seller)
        {
            var existingSeller = sellerAccounts.Find(s => s.Username == originalUsername);

            if (existingSeller != null)
            {
                existingSeller.Username = seller.Username;
                existingSeller.SellerName = seller.SellerName;
                existingSeller.Birthday = seller.Birthday;
                existingSeller.EmailAddress = seller.EmailAddress;
                existingSeller.PhoneNumber = seller.PhoneNumber;
                existingSeller.PresentAddress = seller.PresentAddress;
                existingSeller.Bio = seller.Bio;
            }
        }

        public void Delete(string username)
        {
            var sellerToRemove = sellerAccounts.Find(s => s.Username == username);
            if (sellerToRemove != null)
            {
                sellerAccounts.Remove(sellerToRemove);
            }
        }
        public List<SellerModels> GetAccounts()
        {
            return new List<SellerModels>(sellerAccounts);
        }

        public List<SellerModels> ViewAccounts()
        {
            return new List<SellerModels>(sellerAccounts);
        }
    }
}
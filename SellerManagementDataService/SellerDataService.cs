using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

using SellerManagementModels;

namespace SellerManagementDataService
{
    public class SellerDataService
    {
        ISellerDataService _dataService;  

        public SellerDataService(ISellerDataService dataService)
        {
            _dataService = dataService;
        }

        public void Added(SellerModels seller)
        {
            _dataService.Added(seller);
        }

        public SellerModels? Search(string username)
        {
            return _dataService.Search(username);
        }

        public bool Update(string originalUsername, SellerModels seller)
        {
            _dataService.Update(originalUsername, seller);
            return true;
        }

        public void Delete(string username)
        {
            _dataService.Delete(username);
        }

        public List<SellerModels> GetAccounts()
        {
            return _dataService.GetAccounts();
        }
    }
}

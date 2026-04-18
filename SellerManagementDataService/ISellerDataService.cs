using System;
using System.Collections.Generic;
using System.Text;
using SellerManagementModels;

namespace SellerManagementDataService
{
    public interface ISellerDataService
    {
        void Added(SellerModels seller);
        SellerModels? Search(string username);
        void Update(string originalUsername, SellerModels seller);
        void Delete(string username);
        List<SellerModels> GetAccounts();
        List<SellerModels> ViewAccounts();
    }
}

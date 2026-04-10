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
        void Update(SellerModels seller);
        void Delete(string username);
        List<SellerModels> GetAccounts();
        List<SellerModels> ViewAccounts();
    }
}

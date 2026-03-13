using System;
using System.Collections.Generic;
using System.Text;
using SellerManagementDataService;
using SellerManagementModels;

namespace SellerManagementAppService
{
    public class SellerAppService
    {
        SellerDataService dataLogic = new SellerDataService();

        public void CreateAccount(SellerModels data)
        {
            if (string.IsNullOrEmpty(data.SellerName))
                return;

            dataLogic.Create(data);
        }

        public SellerModels SearchAccount(string name)
        {
            return dataLogic.Search(name);
        }

        public void UpdateAccount(SellerModels data)
        {
            dataLogic.Update(data);
        }

        public void DeleteAccount()
        {
            dataLogic.Delete();
        }

        public SellerModels GetAccount()
        {
            return dataLogic.Get();
        }
    }
}


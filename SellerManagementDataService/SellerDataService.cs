using System;
using System.Collections.Generic;
using System.Text;
using SellerManagementModels;

namespace SellerManagementDataService
{
    public class SellerDataService
    {
        private SellerModels seller = new SellerModels();

        public void Create(SellerModels data)
        {
            seller = data;
        }

        public SellerModels Get()
        {
            return seller;
        }

        public SellerModels Search(string name)
        {
            if (seller != null && seller.SellerName != null &&
                seller.SellerName.Trim().ToLower() == name.Trim().ToLower())
            {
                return seller;
            }

            return null; 
        }

        public void Update(SellerModels data)
        {
            seller = data;
        }

        public void Delete()
        {
            seller = new SellerModels();
        }
    }
}

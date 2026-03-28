using System.Collections.Generic;
using SellerManagementDataService;
using SellerManagementModels;

namespace SellerManagementAppService
{
    public class SellerAppService
    {
        private SellerJsonData jsonDataService = new SellerJsonData();
        private SellersDBData dbDataService = new SellersDBData();

        public bool CreateAccount(SellerModels data)
        {
            if (string.IsNullOrEmpty(data.SellerName))
                return false;

            if (jsonDataService.GetAccounts().Exists(x => x.Username == data.Username))
                return false;

            jsonDataService.Add(data);
            dbDataService.Add(data);

            return true;
        }

        public SellerModels? SearchAccount(string input)
        {
            var seller = jsonDataService.Search(input);
            if (seller == null)
                seller = dbDataService.Search(input);

            return seller;
        }

        public void UpdateAccount(SellerModels data)
        {
            jsonDataService.Update(data);
            dbDataService.Update(data);
        }

        public void Delete(string username)
        {
            jsonDataService.Delete(username);
            dbDataService.Delete(username);
        }

        public List<SellerModels> GetAccounts()
        {
            var list = jsonDataService.GetAccounts();
            var dbList = dbDataService.GetAccounts();

            foreach (var s in dbList)
            {
                if (!list.Exists(x => x.Username == s.Username))
                    list.Add(s);
            }

            return list;
        }
    }
}
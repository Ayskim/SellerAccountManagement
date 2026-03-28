using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SellerManagementModels;

namespace SellerManagementDataService
{
    public class SellerJsonData
    {
        private string filePath = "sellers.json";
        private SellersDBData db = new SellersDBData();

        public void Added(SellerModels seller)
        {
            var list = GetAll();
            if (!list.Exists(x => x.Username == seller.Username))
            {
                list.Add(seller);
                Save(list);
            }
            db.Add(seller);
        }

        public SellerModels? Search(string username)
        {
            var list = GetAll();
            var seller = list.Find(x => x.Username == username);
            if (seller == null)
                seller = db.Search(username);
            return seller;
        }

        public void Update(SellerModels seller)
        {
            var list = GetAll();
            var index = list.FindIndex(x => x.Username == seller.Username);
            if (index != -1)
            {
                list[index] = seller;
                Save(list);
            }
            db.Update(seller);
        }

        public void Delete(string username)
        {
            var list = GetAll();
            list.RemoveAll(x => x.Username == username);
            Save(list);
            db.Delete(username);
        }

        public List<SellerModels> GetAccounts()
        {
            var jsonList = GetAll();
            var dbList = db.GetAccounts();
            foreach (var s in dbList)
            {
                if (!jsonList.Exists(x => x.Username == s.Username))
                    jsonList.Add(s);
            }
            return jsonList;
        }

        private List<SellerModels> GetAll()
        {
            if (!File.Exists(filePath))
                return new List<SellerModels>();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<SellerModels>>(json) ?? new List<SellerModels>();
        }

        private void Save(List<SellerModels> list)
        {
            var json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SellerManagementDataService;
using SellerManagementModels;

    public class SellerJsonData
    {
        private List<SellerModels> sellerAccounts = new List<SellerModels>();
        private string _jsonFileName;
        private SellersDBData db = new SellersDBData();

        public SellerJsonData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Sellers.json";
            if (!File.Exists(_jsonFileName))
                File.WriteAllText(_jsonFileName, "[]");
            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();
            if (sellerAccounts.Count == 0)
            {
                sellerAccounts.Add(new SellerModels
                {
                    SellerName = "AyskimSeller",
                    Birthday = "May 24, 2006",
                    EmailAddress = "homboy@gmail.com",
                    PhoneNumber = "09635121578",
                    PresentAddress = "Ganado",
                    Username = "Kimmy",
                    Bio = "Happy Shopping!"
                });
                SaveDataToJsonFile();
                db.Added(sellerAccounts[0]);
            }
        }

        private void SaveDataToJsonFile()
        {
            var json = JsonSerializer.Serialize(sellerAccounts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFileName, json);
        }

        private void RetrieveDataFromJsonFile()
        {
            if (!File.Exists(_jsonFileName))
            {
                sellerAccounts = new List<SellerModels>();
                return;
            }
            var json = File.ReadAllText(_jsonFileName);
            sellerAccounts = JsonSerializer.Deserialize<List<SellerModels>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SellerModels>();
        }

        public void Add(SellerModels seller)
        {
            RetrieveDataFromJsonFile();
            if (!sellerAccounts.Exists(x => x.Username.Equals(seller.Username, StringComparison.OrdinalIgnoreCase)))
            {
                sellerAccounts.Add(seller);
                SaveDataToJsonFile();
            }
            db.Added(seller);
        }

    public List<SellerModels> GetAccounts()
    {
        RetrieveDataFromJsonFile();

        var dbList = db.GetAccounts();

        foreach (var s in dbList)
        {
            if (!sellerAccounts.Exists(x =>
                x.Username.Equals(s.Username, StringComparison.OrdinalIgnoreCase)))
            {
                sellerAccounts.Add(s);
            }
        }

        return sellerAccounts;
    }

    public SellerModels? Search(string input)
        {
            RetrieveDataFromJsonFile();
            var seller = sellerAccounts.FirstOrDefault(x =>
                (!string.IsNullOrEmpty(x.Username) && x.Username.Equals(input, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(x.SellerName) && x.SellerName.Equals(input, StringComparison.OrdinalIgnoreCase)));
            if (seller == null)
                seller = db.Search(input);
            return seller;
        }

        public void Update(SellerModels seller)
        {
            if (string.IsNullOrWhiteSpace(seller.Username))
                return;

            RetrieveDataFromJsonFile();
            var existingSeller = sellerAccounts.FirstOrDefault(x =>
                !string.IsNullOrEmpty(x.Username) && x.Username.Equals(seller.Username, StringComparison.OrdinalIgnoreCase));
            if (existingSeller != null)
            {
                existingSeller.SellerName = seller.SellerName;
                existingSeller.Birthday = seller.Birthday;
                existingSeller.EmailAddress = seller.EmailAddress;
                existingSeller.PhoneNumber = seller.PhoneNumber;
                existingSeller.PresentAddress = seller.PresentAddress;
                existingSeller.Bio = seller.Bio;
                SaveDataToJsonFile();
            }
            db.Update(seller);
        }

        public void Delete(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return;

            RetrieveDataFromJsonFile();
            var seller = sellerAccounts.FirstOrDefault(x =>
                !string.IsNullOrEmpty(x.Username) && x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (seller != null)
            {
                sellerAccounts.Remove(seller);
                SaveDataToJsonFile();
            }
            db.Delete(username);
        }


    }

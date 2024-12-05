using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Stationery.Models;

namespace Stationery.Service
{
    public class CsvDataService
    {
        private readonly string _goodsFile = "C:\\VS\\StationeryCSV\\Stationery\\Goods.csv";
        private readonly string _suppliersFile = "Suppliers.csv";
        private readonly string _deliveriesFile = "Deliveries.csv";

        public List<Goods> LoadGoods()
        {
            using var reader = new StreamReader(_goodsFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return new List<Goods>(csv.GetRecords<Goods>());
        }

        public List<Supplier> LoadSuppliers()
        {
            using var reader = new StreamReader(_suppliersFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return new List<Supplier>(csv.GetRecords<Supplier>());
        }

        public List<Delivery> LoadDeliveries()
        {
            using var reader = new StreamReader(_deliveriesFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return new List<Delivery>(csv.GetRecords<Delivery>());
        }

        public void SaveDeliveries(List<Delivery> deliveries)
        {
            using var writer = new StreamWriter(_deliveriesFile);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(deliveries);
        }

        public void SaveGoods(List<Goods> goods)
        {
            using var writer = new StreamWriter(_goodsFile);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(goods);
        }
    }

}

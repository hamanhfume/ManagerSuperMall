using Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Controllers
{
    public class IOController : IIOControllers
    {
        public static string ITEM_FILE_NAME = "item.json";
        public static string CUSTOMER_FILE_NAME = "customer.json";
        public static string DISCOUNT_FILE_NAME = "discount.json";
        public static string BILLDETAIL_FILE_NAME = "billDetail.json";
        public static string STATISTIC_FILE_NAME = "statistic.json";

        public List<T> ReadDataJson<T>(string fileName, string root)
        {
            string data = File.ReadAllText(fileName);
            JObject jObject = JObject.Parse(data);
            JToken jToken = jObject[root];
            List<T> listData = new List<T>();
            foreach (JToken item in jToken)
            {
                listData.Add(item.ToObject<T>());
            }
            return listData;

        }
        public void LoadDataListJson(List<Items> listItems, List<Customers> listCustomers, List<Discounts> listDiscounts, List<BillDetails> listBillDetails)
        {
            try
            {
                listItems.AddRange(ReadDataJson<Items>(ITEM_FILE_NAME, "items"));
                listCustomers.AddRange(ReadDataJson<Customers>(CUSTOMER_FILE_NAME, "customers"));
                listDiscounts.AddRange(ReadDataJson<Discounts>(DISCOUNT_FILE_NAME, "discounts"));
                listBillDetails.AddRange(ReadDataJson<BillDetails>(BILLDETAIL_FILE_NAME, "billDetails"));
            }
            catch (JsonException eJson)
            {
                File.AppendAllText("logExcetion.text", eJson.Message);
                File.AppendAllText("logExcetion.text", eJson.StackTrace);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
        public void WriteDataJson(object obj, string fileName)
        {
            string writerJsonDataStr = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(fileName,writerJsonDataStr);
        }

        public bool SaveDataListJson(List<Items> listItems, List<Customers> listCustomers, List<Discounts> listDiscounts, List<BillDetails> listBillDetails)
        {
            var itemObj = new
            {
                items = listItems
            };
            var customerObj = new
            {
                customers = listCustomers
            };
            var discountObj = new
            {
                discounts = listDiscounts
            };
            var billDetailsObj = new
            {
                billDetails = listBillDetails
            };
            WriteDataJson(itemObj, ITEM_FILE_NAME);
            WriteDataJson(customerObj, CUSTOMER_FILE_NAME);
            WriteDataJson(discountObj, DISCOUNT_FILE_NAME);
            WriteDataJson(billDetailsObj, BILLDETAIL_FILE_NAME);
            return true;
        }
    }
}

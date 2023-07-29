using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Models
{
    // Thực thể Họ và tên khách hàng
    // Association: 1 - 1(Persons)
    //              1 - 1(Customers)
    public class FullName 
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("midName")]
        public string MidName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        public FullName()
        {

        }
        public FullName(string firstName, string midName, string lastName)
        {
            FirstName = firstName;
            MidName = midName;
            LastName = lastName;
        }

        public FullName(string fullName)
        {
            // If fullName is Null  -> Không thực hiện tách chuỗi
            var data = fullName?.Split(' ');
            FirstName = data[0];
            LastName = data[data.Length - 1];
            string midN = "";
            for (int i = 1; i < data.Length - 1; i++)
            {
                midN += data[i] + " ";
            }
            midN = midN.TrimEnd(' ');
            MidName = midN;
        }


        public override string ToString()
        {
            return $"{FirstName} {MidName} {LastName}";
        }

    }
}

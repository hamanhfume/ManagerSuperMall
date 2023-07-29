using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Models
{
    // Thực thể Khách hàng
    // Association: 1 - 1 (Persons)
    //              1 - 1 (Carts)
    public class Customers : Persons, IComparable<Customers>
    {
        [JsonProperty("typeCustomer")]
        public string TypeCustomer { get; set; }
        [JsonProperty("pointCustomer")]
        public int PointCustomer { get; set; }
        [JsonProperty("createTimeAccountCustomer")]
        public DateTime CreateTimeAccountCustomer { get; set; }
        [JsonProperty("emailCustomer")]
        public string EmailCustomer { get; set; }

        public Customers() : base()
        {

        }

        public Customers(string typeCustomer, int pointCustomer, DateTime createTimeAccountCustomer, string emailCustomer) : base()
        {
            TypeCustomer = typeCustomer;
            PointCustomer = pointCustomer;
            CreateTimeAccountCustomer = createTimeAccountCustomer;
            EmailCustomer = emailCustomer;
        }

        public Customers(string typeCustomer, int pointCustomer, DateTime createTimeAccountCustomer, string emailCustomer,
                        string idPerson, string fullNamePerson, DateTime birtDatePerson, string address, string phoneNumber)
                        : base(idPerson, fullNamePerson, birtDatePerson, address, phoneNumber)
        {
            TypeCustomer = typeCustomer;
            PointCustomer = pointCustomer;
            CreateTimeAccountCustomer = createTimeAccountCustomer;
            EmailCustomer = emailCustomer;
        }

        public override bool Equals(object obj)
        {
            return obj is Customers customers &&
                   base.Equals(obj) &&
                   IdPerson == customers.IdPerson;
        }

        public override int GetHashCode()
        {
            int hashCode = -772687493;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IdPerson);
            return hashCode;
        }

        // So sánh object Customers này với Customers kia qua id.
        public int CompareTo(Customers other)
        {
            return IdPerson.CompareTo(other.IdPerson);
        }

        public object[] ObjectCustomerToArray()
        {
            return new object[] { IdPerson, FullNamePerson.ToString(), BirtDatePerson.ToString("dd/MM/yyyy"), Address, PhoneNumber, EmailCustomer, TypeCustomer, PointCustomer, CreateTimeAccountCustomer.ToString("yyyy/MM/dd HH:mm:ss") };
        }

        public object[] ObjectCustomerToArrayAddBill()
        {
            return new object[] { IdPerson, FullNamePerson.ToString() };
        }

    }
}

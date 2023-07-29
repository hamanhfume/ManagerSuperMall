using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace Models
{
    // Thực thể Người
    // Association: 1 - 1 (FullName)
    //              1 - n (Customers)
    public class Persons : IComparable<Persons>
    {
        // Dùng cccd làm mã Person luôn.
        [JsonProperty("idPerson")]
        public string IdPerson { get; set; }
        [JsonProperty("fullNamePerson")]
        public FullName FullNamePerson { get; set; }
        [JsonProperty("birthDatePerson")]
        public DateTime BirtDatePerson { get; set; }
        [JsonProperty("addressPerson")]
        public string Address { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        public Persons()
        {

        }

        public Persons(string id)
        {
            IdPerson = id;
        }

        public Persons(string idPerson, string fullNamePerson, DateTime birtDatePerson,
                       string address, string phoneNumber) : this(idPerson)
        {
            FullNamePerson = new FullName(fullNamePerson);

            BirtDatePerson = birtDatePerson;
            Address = address;
            PhoneNumber = phoneNumber;
        }



        // Kiểm tra xem object Person có tồn tại không?
        public override bool Equals(object obj)
        {
            return obj is Persons persons &&
                   IdPerson == persons.IdPerson;
        }

        public override int GetHashCode()
        {
            return -1519451219 + EqualityComparer<string>.Default.GetHashCode(IdPerson);
        }

        // So sánh 2 đối tượng Person theo id
        public int CompareTo(Persons other)
        {
            return IdPerson.CompareTo(other.IdPerson);
        }

        
    }
}

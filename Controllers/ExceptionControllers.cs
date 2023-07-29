using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    // Xử lí ngoại lệ.

    public class InvalidIdItemException : Exception
    {
        private string _idItemInvalid;
        public InvalidIdItemException() : base() { }
        public InvalidIdItemException(string message) : base(message) { }
        public InvalidIdItemException(string message, Exception innerException) : base(message, innerException) { }
        public InvalidIdItemException(string idItemInvalid, string message, Exception innerException) : base(message, innerException)
        {
            _idItemInvalid = idItemInvalid;
        }
        public InvalidIdItemException(string message, string idItemInvalid) : base(message)
        {
            _idItemInvalid = idItemInvalid;
        }

        public override string ToString()
        {
            return
                    $"Id Item Invalid: {_idItemInvalid}\n" +
                    $"Id Example Valid: Number Integer > 0!";
        }

    }


    public class InvalidNameItemException : Exception
    {
        private string _nameItemInvalid;
        public InvalidNameItemException() { }
        public InvalidNameItemException(string message) : base(message) { }
        public InvalidNameItemException(string message, Exception exception) : base(message, exception) { }
        public InvalidNameItemException(string message, string nameItemInvalid) : base(message)
        {
            _nameItemInvalid = nameItemInvalid;
        }
        public override string ToString()
        {
            return
                    $"Name Item Invalid: {_nameItemInvalid}\n" +
                    $"Name Example Valid: Mì Cay, Phở ... !\n" +
                    $"Or Items name cannot be blank!";
        }
    }

    public class InvalidCCCDCustomerException : Exception
    {
        private string _cccdCustomerInvalid;
        public InvalidCCCDCustomerException()
        {

        }
        public InvalidCCCDCustomerException(string message) : base(message) { }

        public InvalidCCCDCustomerException(string message, Exception innerException) : base(message, innerException) { }
        public InvalidCCCDCustomerException(string message, string cccdInvalid) : base(message)
        {
            _cccdCustomerInvalid = cccdInvalid;
        }
        public override string ToString()
        {
            return
                    $"CCCD Customer Invalid: {_cccdCustomerInvalid}\n" +
                    $"CCCD Customer Valid: 001202035227... !\n" +
                    $"Or CCCD Customer cannot be blank!";
        }
    }
    public class InvalidFullNameCustommerException : Exception
    {
        private string _fullNameCustommerInvalid = "";
        public InvalidFullNameCustommerException()
        {

        }
        public InvalidFullNameCustommerException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public InvalidFullNameCustommerException(string message) : base(message)
        {

        }
        public InvalidFullNameCustommerException(string message, string fullNameInvalid) : base(message)
        {
            fullNameInvalid = _fullNameCustommerInvalid;
        }
        public override string ToString()
        {
            return
                $"Full Name InValid: {_fullNameCustommerInvalid}\n" +
                $"Full Name Valid: Hà Văn Mạnh...!" +
                $"Or Customer name cannot be blank!";
        }
    }
    public class InvalidEmailException : Exception
    {
        string _emailItemInvalid;

        public InvalidEmailException()
        {

        }

        public InvalidEmailException(string message, Exception inner) : base(message, inner) { }
        public InvalidEmailException(string message, string invalidEmail) : base(message)
        {
            _emailItemInvalid = invalidEmail;
        }
        public override string ToString()
        {
            return
                $"Email InValid: {_emailItemInvalid}\n" +
                $"Email Valid: hamanhfu.me@gmail.com...!" +
                $"Or email cannot be blank!";
        }
    }

    public class InvalidPhoneNumberException : Exception
    {
        private string _invalidPhoneNumber;
        public InvalidPhoneNumberException()
        {

        }
        public InvalidPhoneNumberException(string message) : base(message)
        {

        }
        public InvalidPhoneNumberException(string message, Exception inner) : base(message, inner) { }
        public InvalidPhoneNumberException(string message, string invalidPhoneNumber) : base(message)
        {
            _invalidPhoneNumber = invalidPhoneNumber;
        }
        public override string ToString()
        {
            return
                $"Phone Number InValid: {_invalidPhoneNumber}\n" +
                $"Phone Number Valid: 0987209593...!" +
                $"Or Phone Number cannot be blank!";
        }

        public class InvalidIdDiscountExction : Exception
        {
            private string _invalidIdDiscount;
            public InvalidIdDiscountExction()
            {
                
            }
            public InvalidIdDiscountExction(string message) : base(message)
            {
                
            }
            public InvalidIdDiscountExction(string message, Exception inner) : base(message,inner)
            {
                
            }
            public InvalidIdDiscountExction(string message, string invalidIdDiscount)
            {
                _invalidIdDiscount = invalidIdDiscount;
            }

            public override string ToString()
            {
                return
                        $"Id Discount Invalid: {_invalidIdDiscount}\n" +
                        $"Id Example Valid: Number Integer > 0!";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Customer
{
    public class Customer : ICloneable, IComparable
    {

        //first name, middle name and last name, ID (EGN), permanent address, mobile phone, e-mail, list of payments and customer type. 
        private List<IPayment> payments;

        public Customer(string fName, string mName, string lName, long egn, string address, string mPhone, string email, CustomerType type)
        {
           this.FName = fName;
           this.MName = mName;
           this.LName = lName;
           this.EGN = egn;
           this.Address = address;
           this.MPhone = mPhone;
           this.Email = email;
           this.Type = type;
           this.payments = new List<IPayment>();
        }

        public string FName { get; }
        public string MName { get; }
        public string LName { get; }
        public long EGN { get; }
        public string Address { get; }
        public string MPhone { get; }
        public string Email { get; }
        public CustomerType Type { get; }

        public  List<IPayment> Payments
        {
            get { return this.payments; }
        }

        public void AddPayment(IPayment newPayment )
        {
            this.payments.Add(newPayment);
        }
        
        public object Clone()
        {
            Customer clone = new Customer(this.FName,this.MName,this.LName, this.EGN, this.Address, this.MName, this.Email,this.Type);
            this.Payments.ForEach(x => clone.AddPayment(x));
            return clone;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (payments != null ? payments.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FName != null ? FName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MName != null ? MName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LName != null ? LName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EGN != null ? EGN.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Address != null ? Address.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MPhone != null ? MPhone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Type;
                return hashCode;
            }
        }

        public int CompareTo(object obj)
        {
            var other = obj as Customer;
            string firstFullName = this.FName + this.MName + this.LName;
            string otherFullName = other.FName + other.MName + other.LName;
            if (firstFullName == otherFullName)
            {
                return this.EGN.CompareTo(other.EGN);
            }
            return String.Compare(firstFullName, otherFullName);
        }

        protected bool Equals(Customer other)
        {
            return string.Equals(FName, other.FName) &&
                string.Equals(MName, other.MName) &&
                string.Equals(LName, other.LName) &&
                this.EGN == other.EGN &&
                string.Equals(Address, other.Address) &&
                string.Equals(MPhone, other.MPhone) &&
                string.Equals(Email, other.Email) &&
                Type == other.Type;
        }

        public static bool operator ==(Customer left, Customer right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Customer left, Customer right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("{0} {1} {2}",this.FName,this.MName,this.LName));
            sb.AppendLine(string.Format("{0}", this.Email));
            this.Payments.ForEach(x => sb.AppendLine(string.Format("{0} - {1}",x.Name,x.Price)));

            return sb.ToString();
        }
    }
}
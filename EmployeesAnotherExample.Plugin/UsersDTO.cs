using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesLoaderAnotherExample.Plugin
{
    public class UsersJson
    {
        public List<UserData> Users { get; set; }
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }

    public class UserData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }
        public string BloodGroup { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string EyeColor { get; set; }
        public Hair Hair { get; set; }
        public string Domain { get; set; }
        public string Ip { get; set; }
        public AddressDTO Address { get; set; }
        public string MacAddress { get; set; }
        public string University { get; set; }
        public Bank Bank { get; set; }
        public Company Company { get; set; }
        public string Ein { get; set; }
        public string Ssn { get; set; }
        public string UserAgent { get; set; }
    }

    public class Hair
    {
        public string Color { get; set; }
        public string Type { get; set; }
    }

    public class AddressDTO
    {
        public string Address { get; set; }
        public string City { get; set; }
        public Coordinates Coordinates { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
    }

    public class Coordinates
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
    }

    public class Bank
    {
        public string CardExpire { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string Currency { get; set; }
        public string Iban { get; set; }
    }

    public class Company
    {
        public AddressDTO Address { get; set; }
        public string Department { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}

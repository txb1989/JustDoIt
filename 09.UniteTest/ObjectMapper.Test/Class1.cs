using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectMapper.Test
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Sex { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NewName { get; set; }

    }

    public class PersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Sex { get; set; }

        public string FullName { get; set; }

        public string OldName { get; set; }
    }

    public class Address
    {

        public string Province { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Street { get; set; }
    }

    public class AddressDto
    {
        public string Province { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Street { get; set; }
    }

    public enum Gender
    {
        Male=0,
        Female=1,
        Unknow = 99999
    }
}

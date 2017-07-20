using Jst.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Test.Entities
{
    [Table("Customer")]
    public class Customer : EntityBase<int>
    {
        /// <summary>
		/// CustomerName
        /// </summary>		
		private string _customername;
        public string CustomerName
        {
            get { return _customername; }
            set { _customername = value; }
        }
        /// <summary>
        /// Gendar
        /// </summary>		
        private int _gendar;
        public int Gendar
        {
            get { return _gendar; }
            set { _gendar = value; }
        }
        /// <summary>
        /// Age
        /// </summary>		
        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        /// <summary>
        /// Phone
        /// </summary>		
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// Email
        /// </summary>		
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}

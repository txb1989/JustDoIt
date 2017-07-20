using Jst.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Test.Entities
{
    [Table("OpenUserTB")]
    public class OpenUser : EntityBase<int>
    {
        // <summary>
        /// openUserId
        /// </summary>		
        private string _openuserid;
        public string openUserId
        {
            get { return _openuserid; }
            set { _openuserid = value; }
        }
        /// <summary>
        /// openUserName
        /// </summary>		
        private string _openusername;
        public string openUserName
        {
            get { return _openusername; }
            set { _openusername = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>		
        private string _userid;
        public string UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// CreateDate
        /// </summary>		
        private DateTime _createdate;
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// LastUpdateDate
        /// </summary>		
        private DateTime _lastupdatedate;
        public DateTime LastUpdateDate
        {
            get { return _lastupdatedate; }
            set { _lastupdatedate = value; }
        }		
       
        /// <summary>
        /// status
        /// </summary>		
        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// paltform
        /// </summary>		
        private string _paltform;
        public string paltform
        {
            get { return _paltform; }
            set { _paltform = value; }
        }
        /// <summary>
        /// AppId
        /// </summary>		
        private string _appid;
        public string AppId
        {
            get { return _appid; }
            set { _appid = value; }
        }
        /// <summary>
        /// UnionId
        /// </summary>		
        private string _unionid;
        public string UnionId
        {
            get { return _unionid; }
            set { _unionid = value; }
        }
        /// <summary>
        /// AppDesc
        /// </summary>		
        private string _appdesc;
        public string AppDesc
        {
            get { return _appdesc; }
            set { _appdesc = value; }
        }
    }
}

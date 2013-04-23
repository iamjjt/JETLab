using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mall.Models
{
    public class Users
    {
        public int UsersID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birtheay { get; set; }
        /// <summary>
        /// 账户可用资金
        /// </summary>
        public decimal UserMoney { get; set; }
        /// <summary>
        /// 冻结资金
        /// </summary>
        public decimal FrozenMoney { get; set; }
        /// <summary>
        /// 消费积分
        /// </summary>
        public int PayPoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RankPoints { get; set; }

    }

    public class UserAddress
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Consignee { get; set; }
        public string Email { get; set; }
        public string country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string ReciveTime { get; set; }
        public virtual Users User{get;set;}
    }
}
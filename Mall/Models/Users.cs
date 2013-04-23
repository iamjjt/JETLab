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
        public int RankPoints { get; set; }


    }
}
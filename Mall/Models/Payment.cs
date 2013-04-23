using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace Mall.Models
{
    public class Payment
    {
        public int ID { get; set; }
        [Display(Name = "支付名称")]
        public string Name { get; set; }
        [Display(Name = "支付方式")]
        public string Code { get; set; }
        [Display(Name = "父类")]
        public int Fee { get; set; }
        [Display(Name = "支付费用")]
        public string Summary { get; set; }
        [Display(Name = "配置信息")]
        public int Config { get; set; }
        [Display(Name = "是否可用")]
        public string Enabled { get; set; }
        [Display(Name = "显示顺序")]
        public int Sort { get; set; }
        [Display(Name = "货到付款")]
        public bool IsCod { get; set; }
        [Display(Name = "在线支付")]
        public bool IsOnline { get; set; }
    }

    /// <summary>
    /// 配送方式
    /// </summary>
    public class Shipping
    {
        public int ID { get; set; }
        [Display(Name = "配送名称")]
        public string Name { get; set; }
        [Display(Name = "配送代号")]
        public string Code { get; set; }
        [Display(Name = "描述")]
        public string Summary { get; set; }
        [Display(Name = "保价费用")]
        public int Insure { get; set; }
        [Display(Name = "是否支持货到付款")]
        public bool supportCod { get; set; }
        [Display(Name = "启用/禁用")]
        public bool Enabled { get; set; }
    }
}
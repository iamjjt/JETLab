using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mall.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int NO { get; set; }
        public int GoodId { get; set; }
        public Goods Good { get; set; }
        public int GoodNum { get; set; }
        public string GoodsAttr { get; set; }
        public int Status { get; set; }
        public int ShippingStatus { get; set; }
        public int PayStatus { get; set; }
        public string Consignee { get; set; }
        public int CountryId { get; set; }
        public int Province { get; set; }
        public int District { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string BestTime { get; set; }
        public string PostScript { get; set; }
        public int ShippingId { get; set; }
        public Shipping ChosenShipping { get; set; }
        public int PaymentId { get; set; }
        public Payment ChosenPayment { get; set; }
        public bool IsInvoice { get; set; }
        public string InvoicePayee { get; set; }
        public string InvoiceContent { get; set; }
        public decimal GoodsAmount { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal PayFee { get; set; }
        public decimal MoneyPaid { get; set; }
        public decimal Integral { get; set; }
        public decimal IntegralMoney { get; set; }
        public decimal OrderAmount { get; set; }
        public string Referer { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime ConfirmTime { get; set; }
        public DateTime PayTime { get; set; }
        public DateTime ShippingTime { get; set; }
        public string InvoiceNo { get; set; }
        public string ExtensionCode { get; set; }
        public int ExtensionId { get; set; }
        public string ToBuyer { get; set; }
        public string PayNote { get; set; }
        //public int AgencyId { get; set; }
        ////TODO：这里留办事处
    }
}
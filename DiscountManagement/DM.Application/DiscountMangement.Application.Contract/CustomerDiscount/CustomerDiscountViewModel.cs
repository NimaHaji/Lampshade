namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountViewModel:DefineCustomerDiscount{
        public long Id { get; set; }
        public string Product { get; set; }
        public DateTime StartDateGr { get; set; }
        public DateTime EndDateGr { get; set; }
        public string Reason { get; set; }
        public string CreationDate { get; set; }
    }
}


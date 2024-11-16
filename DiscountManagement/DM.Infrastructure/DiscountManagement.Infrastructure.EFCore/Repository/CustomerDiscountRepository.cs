using _0_Framwork.Infrastructure;
using _0_Framework.Application;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Application.Contract.CustomerDiscount;
using ShopManagment.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _Context;
        private readonly ShopContext _ShopContext;

        public CustomerDiscountRepository(DiscountContext context) : base(context)
        {
            _Context = context;
        }

        public EditCustomerDiscount GetDetails(long Id)
        {
            return _Context.Discounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToString(),
                EndDate = x.EndDate.ToString(),
                Reason = x.Reason
            }).FirstOrDefault(x => x.Id == Id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products=_ShopContext.Products.Select(x=>new {x.Id,x.Name}).ToList();
            var query = _Context.Discounts.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDateGr = x.EndDate,
                StartDate = x.StartDate.ToFarsi(),
                EndDateGr = x.EndDate,
                EndDate = x.EndDate.ToFarsi(),
                Reason = x.Reason
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (string.IsNullOrEmpty(searchModel.StartDate))
            {
                query = query.Where(x => x.StartDateGr < searchModel.StartDate.ToGeorgianDateTime());
            }
            if (string.IsNullOrEmpty(searchModel.EndDate))
            {
                query = query.Where(x => x.EndDateGr < searchModel.EndDate.ToGeorgianDateTime());
            }

            var discounts=query.OrderByDescending(x=>x.Id).ToList();

            discounts.ForEach(n=>n.Product=products.FirstOrDefault(x=>x.Id==n.ProductId)?.Name);
            
            return discounts;
        }
    }
}


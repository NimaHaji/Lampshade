using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using _0_Framwork.Infrastructure;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountMangement.Application.Contract.ColleagueDiscount;
using ShopManagment.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;
        public ColleagueDiscountRepository(DiscountContext context):base(context)
        {
            _context = context;
        }

        public EditColleagueDiscount GetDeatils(long id)
        {
            return _context.ColleagueDiscounts.Select(x => new EditColleagueDiscount
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueSearchModel searchModel)
        {
            var Products=_shopContext.Products.Select(x=>new {x.Id,x.Name}).ToList();
            var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {
                ProductId = x.ProductId,
                CreationDate = x.CreationDate.ToFarsi(),
                Id = x.Id,
                DiscountRate = x.DiscountRate,
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            var discount=query.OrderByDescending(x=>x.Id).ToList();
            discount.ForEach(discount=>discount.Product=Products.FirstOrDefault(x=>x.Id==discount.ProductId)?.Name);
            return discount;
        }

    }

}


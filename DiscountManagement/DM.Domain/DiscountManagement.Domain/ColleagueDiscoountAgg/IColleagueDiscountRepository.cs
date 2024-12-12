using _0_Framwork.Domain;
using DiscountMangement.Application.Contract.ColleagueDiscount;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository : IRepository<long, ColleagueDiscount>
    {
        EditColleagueDiscount GetDeatils(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueSearchModel searchModel);
    }

}


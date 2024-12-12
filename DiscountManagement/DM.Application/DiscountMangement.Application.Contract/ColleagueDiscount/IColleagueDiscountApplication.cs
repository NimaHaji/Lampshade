using _0_Framwork.Application;

namespace DiscountMangement.Application.Contract.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Define(DefineColleagueDiscount command);
        OperationResult Edit(EditColleagueDiscount command);
        OperationResult Restore(long Id);
        OperationResult Remove(long Id);
        EditColleagueDiscount GetDetails(long Id);
        List<ColleagueDiscountViewModel> Search(ColleagueSearchModel searchModel);
    }

}


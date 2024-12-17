using _0_Framwork;
using _0_Framwork.Application;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Application.Contract.ColleagueDiscount;
namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;
        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }
        public OperationResult Define(DefineColleagueDiscount command)
        {
            var OperationResult = new OperationResult();
            if (_colleagueDiscountRepository.IsExist(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var ColleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Create(ColleagueDiscount);
            _colleagueDiscountRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var OperationResult = new OperationResult();
            var ColleagueDiscount = _colleagueDiscountRepository.Get(command.Id);
            if (ColleagueDiscount == null)
                return OperationResult.Failed(ApplicationMessages.RecordNotFound);

            if (_colleagueDiscountRepository.IsExist(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id == command.Id))
                return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);
            ColleagueDiscount.Edit(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public EditColleagueDiscount GetDetails(long Id)
        {
            return _colleagueDiscountRepository.GetDeatils(Id);
        }

        public OperationResult Remove(long Id)
        {
            var OperationResult = new OperationResult();
            var ColleagueDiscount = _colleagueDiscountRepository.Get(Id);
            if (ColleagueDiscount == null)
                return OperationResult.Failed(ApplicationMessages.RecordNotFound);

            ColleagueDiscount.Remove();
            _colleagueDiscountRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public OperationResult Restore(long Id)
        {
            var OperationResult = new OperationResult();
            var ColleagueDiscount = _colleagueDiscountRepository.Get(Id);
            if (ColleagueDiscount == null)
                return OperationResult.Failed(ApplicationMessages.RecordNotFound);

            ColleagueDiscount.Restore();
            _colleagueDiscountRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}


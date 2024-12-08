using _0_Framwork.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using _0_Framwork;
using _0_Framework.Application;
namespace DiscountManagement.Application.CustomerDiscounts
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var OperationResult = new OperationResult();
            if (_customerDiscountRepository.IsExist(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var startdate = command.StartDate.ToGeorgianDateTime();
            var enddate = command.EndDate.ToGeorgianDateTime();

            CustomerDiscount customerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate, startdate, enddate, command.Reason);

            _customerDiscountRepository.Create(customerDiscount);
            _customerDiscountRepository.SaveChanges();

            return OperationResult.Succedded();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var OperationResult = new OperationResult();
            var Discount = _customerDiscountRepository.Get(command.Id);

            if (_customerDiscountRepository.IsExist(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id == command.Id))
                return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);

            if (Discount == null)
                return OperationResult.Failed(ApplicationMessages.RecordNotFound);

            var startdate = command.StartDate.ToGeorgianDateTime();
            var enddate = command.EndDate.ToGeorgianDateTime();
            Discount.Edit(command.ProductId, command.DiscountRate, startdate, enddate, command.Reason);
            _customerDiscountRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public EditCustomerDiscount GetDetails(long Id)
        {
            return _customerDiscountRepository.GetDetails(Id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }

}


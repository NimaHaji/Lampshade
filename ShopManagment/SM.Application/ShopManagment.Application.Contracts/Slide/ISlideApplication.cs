using System.Collections.Generic;
using _0_Framwork.Application;

namespace ShopManagment.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlider command);
        OperationResult Edit(EditSlider command);
        OperationResult Remove(long Id);
        OperationResult Restore(long Id);
        EditSlider GetDetails(long Id);
        List<SlideViewModel> GetList();
    }
}


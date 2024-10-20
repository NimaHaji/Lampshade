using System.Collections.Generic;
using _0_Freamwork.Application;
using _0_Freamwork.Domain;
using ShopManagment.Application.Contracts;

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


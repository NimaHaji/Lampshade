using System.Collections.Generic;
using _0_Framwork.Domain;
using ShopManagment.Application.Contracts.Slide;

namespace ShopManagment.Domain
{
    public interface ISlideRepository:IRepository<long,Slide>
    {
        EditSlider GetDetails(long Id);
        List<SlideViewModel> GetList();
    }
}



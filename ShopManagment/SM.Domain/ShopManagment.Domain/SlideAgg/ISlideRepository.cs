using System.Collections.Generic;
using _0_Freamwork.Domain;
using _0_Freamwork.Infrastructure;
using ShopManagment.Application.Contracts;
using ShopManagment.Application.Contracts.Slide;

namespace ShopManagment.Domain
{
    public interface ISlideRepository:IRepository<long,Slide>
    {
        EditSlider GetDetails(long Id);
        List<SlideViewModel> GetList();
    }
}



using System.Collections.Generic;
using System.Linq;
using _0_Freamwork.Domain;
using _0_Freamwork.Infrastructure;
using ShopManagment.Application.Contracts.Slide;
using ShopManagment.Domain;

namespace ShopManagment.Infrastructure.EFCore
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _ShopContext;

        public SlideRepository(ShopContext shopContext):base(shopContext)
        {
            _ShopContext = shopContext;
        }

        public EditSlider GetDetails(long Id)
        {
            return _ShopContext.Slides.Select(x=> new EditSlider
            {
                Id=x.Id,
                BtnText=x.BtnText,
                Heading=x.Heading,
                Picture=x.Picture,
                PictureTitle=x.PictureTitle,
                PictureAlt=x.PictureTitle,
                Text=x.Text,
                Link=x.Link,
                Title=x.Title
            }).FirstOrDefault(x=>x.Id==Id);
        }

        public List<SlideViewModel> GetList()
        {
            return _ShopContext.Slides.Select(x=>new SlideViewModel{
                Id=x.Id,
                Picture=x.Picture,
                Heading=x.Heading,
                Title=x.Title,
                CreationDate=x.CreationDate.ToString()
            }).OrderByDescending(x=>x.Id).ToList();
        }
    }

}


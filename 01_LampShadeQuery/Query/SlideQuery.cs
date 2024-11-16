
using _01_LampShadeQuery.Contracts.Slide;
using ShopManagment.Infrastructure.EFCore;

namespace _01_LampShadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _context;

        public SlideQuery(ShopContext context)
        {
            _context = context;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _context.Slides
            .Where(x=>x.IsRemoved==false)
            .Select(x=>new SlideQueryModel{
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Title=x.Title,
                BtnText=x.BtnText,
                Link=x.Link,
                Text=x.Text,
                Heading=x.Heading
            })
            .ToList();
        }
    }

}

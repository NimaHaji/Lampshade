using System.Collections.Generic;
using _0_Freamwork;
using _0_Freamwork.Application;
using ShopManagment.Application.Contracts;
using ShopManagment.Application.Contracts.Slide;
using ShopManagment.Domain;

namespace ShopManagment.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlider command)
        {
            var OperationResult=new OperationResult();
            if(_slideRepository.IsExist(x=>x.Picture==command.Picture))
            return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var Slide=new Slide(command.Picture,command.PictureAlt,command.PictureTitle,command.Heading,command.Title,command.Text,command.BtnText,command.Link);
            _slideRepository.Create(Slide);
            _slideRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public OperationResult Edit(EditSlider command)
        {
            var OperationResult=new OperationResult();
            var slide=_slideRepository.Get(command.Id);

            if(slide==null)
            return OperationResult.Failed(ApplicationMessages.RecordNotFound);

            slide.Edit(command.Picture,command.PictureAlt,command.PictureTitle,command.Heading,command.Title,command.Text,command.BtnText,command.Link);
            
            _slideRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public EditSlider GetDetails(long Id)
        {
            return _slideRepository.GetDetails(Id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OperationResult Remove(long Id)
        {
            var operationResult=new OperationResult();
            var slide=_slideRepository.Get(Id);

            if(slide==null)
            return operationResult.Failed(ApplicationMessages.RecordNotFound);

            slide.Remove();
            _slideRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Restore(long Id)
        {
            var operationResult=new OperationResult();
            var slide=_slideRepository.Get(Id);

            if(slide==null)
            return operationResult.Failed(ApplicationMessages.RecordNotFound);

            slide.Restore();
            _slideRepository.SaveChanges();
            return operationResult.Succedded();
        }
    }
}



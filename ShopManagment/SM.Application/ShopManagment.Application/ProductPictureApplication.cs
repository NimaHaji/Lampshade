using System.Collections.Generic;
using _0_Freamwork;
using _0_Freamwork.Application;
using ShopManagment.Application.Contracts.ProductPicture;
using ShopManagment.Domain;

namespace ShopManagment.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var OperationResult = new OperationResult();
            if (_productPictureRepository.IsExist(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
                return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var ProductPicture = new ProductPicture(command.ProductId, command.Picture, command.PictureTitle, command.PictureAlt);

            _productPictureRepository.Create(ProductPicture);
            _productPictureRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var OperationResult = new OperationResult();
            var ProductPicture = _productPictureRepository.Get(command.Id);
            if (ProductPicture == null)
                return OperationResult.Failed(ApplicationMessages.RecordNotFound);

            if (_productPictureRepository.IsExist(x => x.Picture == command.Picture && x.ProductId == command.ProductId && x.Id != command.Id))
                return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);

            ProductPicture.Edit(command.ProductId, command.Picture, command.PictureTitle, command.PictureAlt);
            _productPictureRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var OperationResult = new OperationResult();
            var ProductPicture = _productPictureRepository.Get(id);
            if(ProductPicture == null)
            return OperationResult.Failed(ApplicationMessages.RecordNotFound);
            ProductPicture.Remove();

            _productPictureRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var OperationResult = new OperationResult();
            var ProductPicture = _productPictureRepository.Get(id);
            if(ProductPicture == null)
            return OperationResult.Failed(ApplicationMessages.RecordNotFound);
            ProductPicture.Restore();

            _productPictureRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}



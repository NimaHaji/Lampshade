﻿using _0_Freamwork.Domain;

namespace ShopManagment.Domain
{

    public class ProductPicture:EntityBase
    {
        public long ProductId { get; private set; }
        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public bool IsRemoved { get; private set; }
        public Product Product { get;private set; }
        public ProductPicture(long productId, string picture,string pictureTitle,string pictureAlt)
        {
            ProductId=productId;
            Picture=picture;
            PictureTitle=pictureTitle;
            PictureAlt=pictureAlt;
            IsRemoved=false;
        }
        public void Edit(long productId, string picture,string pictureTitle,string pictureAlt)
        {
            ProductId=productId;
            Picture=picture;
            PictureTitle=pictureTitle;
            PictureAlt=pictureAlt;
        }
        public void Remove(){
            IsRemoved=true;
        }
        public void Restore(){
            IsRemoved=false;
        }
    }

}

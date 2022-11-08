using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageCategoryManager : IImageCategoryService
    {
        IImageCategoryDal _imageCategoryDal;

        public ImageCategoryManager(IImageCategoryDal imageCategoryDal)
        {
            _imageCategoryDal = imageCategoryDal;
        }

        public void TAdd(ImageCategory t)
        {
            _imageCategoryDal.Insert(t);
        }

        public void TDelete(ImageCategory t)
        {
            _imageCategoryDal.Delete(t);
        }

        public ImageCategory TGetById(int id)
        {
            return _imageCategoryDal.GetById(id);
        }

        public List<ImageCategory> TGetList()
        {
            return _imageCategoryDal.GetList();
        }

        public void TUpdate(ImageCategory t)
        {
            _imageCategoryDal.Update(t);
        }
    }
}

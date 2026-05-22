using System.Collections.Generic;
using System.Threading.Tasks;
using Vsky.Models;

namespace Vsky.Services.Common
{
    public interface ICommonService
    {
        Task<IList<Country>> GetAllCountries();

        Task<IList<StateProvince>> GetAllStateProvinces(string countryId);

        Task<Picture> GetByPictureId(string pitureId);

        Task<PictureBinary> GetBinaryPictureByPictureId(string pitureId);

        void InsertPicture(Picture entity);

        void UpdatePicture(Picture entity);

        void InsertPictureBinary(PictureBinary entity);

        void UpdatePictureBinary(PictureBinary entity);

    }
}
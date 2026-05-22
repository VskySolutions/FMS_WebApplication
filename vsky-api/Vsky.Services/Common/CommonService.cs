using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vsky.Data;
using Vsky.Models;

namespace Vsky.Services.Common
{
    public class CommonService : ICommonService
    {
        #region Fields

        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<StateProvince> _stateProvinceRepository;
        private readonly IRepository<Picture> _pictureRepository;
        private readonly IRepository<PictureBinary> _pictureBinaryRepository;

        #endregion

        #region Ctor

        public CommonService(IRepository<Country> countryRepository,
            IRepository<StateProvince> stateProvinceRepository, 
            IRepository<Picture> pictureRepository, 
            IRepository<PictureBinary> pictureBinaryRepository)
        {
            _countryRepository = countryRepository;
            _stateProvinceRepository = stateProvinceRepository;
            _pictureRepository = pictureRepository;
            _pictureBinaryRepository = pictureBinaryRepository;
        }

        #endregion

        #region Public Methods

        public async Task<IList<Country>> GetAllCountries()
        {
            var query = _countryRepository.TableNoTracking;

            query = query.Where(x => x.Active).OrderBy(x=>x.Name);

            var list = await query.ToListAsync();

            return list;
        }

        public async Task<IList<StateProvince>> GetAllStateProvinces(string countryId)
        {
            var query = _stateProvinceRepository.TableNoTracking;

            query = query.Where(x => x.CountryId == countryId);

            query = query.Where(x => x.Active).OrderBy(x => x.Name); ;

            var list = await query.ToListAsync();

            return list;
        }

        public async Task<Picture> GetByPictureId(string pictureId)
        {
            var query = _pictureRepository.Table;

            query = query.Where(x => x.Id == pictureId).AsNoTracking();

            var item = await query.FirstOrDefaultAsync();

            return item;
        }

        public async Task<PictureBinary> GetBinaryPictureByPictureId(string pictureId)
        {
            var query = _pictureBinaryRepository.Table;

            query = query.Where(x => x.PictureId == pictureId).AsNoTracking();

            var item = await query.FirstOrDefaultAsync();

            return item;
        }

        public void InsertPicture(Picture entity)
        {
            _pictureRepository.Insert(entity);
        }

        public void InsertPictureBinary(PictureBinary entity)
        {
            _pictureBinaryRepository.Insert(entity);
        }

        public void UpdatePicture(Picture entity)
        {
            _pictureRepository.Update(entity);
        }
        
        public void UpdatePictureBinary(PictureBinary entity)
        {
            _pictureBinaryRepository.Update(entity);
        }

        #endregion
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Vsky.Core;
using Vsky.Models;

namespace Vsky.Services.DropDowns
{
    public interface IDropDownService
    {
        IPagedList<DropDown> GetAllDropDowns(string dropdownTypeId, string sortBy,
            bool descending, int page = 1, int pageSize = int.MaxValue, bool lookup = false);

        Task<IList<DropDown>> GetDropDowns(string typeId, string dropdownType=null, string orderbyColumn=null);

        Task<IList<DropDown>> GetAllDropDowns(string typeId);

        Task<DropDownType> GetDropDownType(string type);

        Task<DropDown> GetById(string id);

        Task<DropDown> GetByName(string name);

        void InsertDropDown(DropDown entity);

        void UpdateDropDown(DropDown entity);

        void DeleteDropDown(DropDown entity);
    }
}
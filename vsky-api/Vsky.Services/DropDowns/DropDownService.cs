using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using Vsky.Core;
using Vsky.Data;
using Vsky.Models;

namespace Vsky.Services.DropDowns
{
    public class DropDownService : IDropDownService
    {
        #region Fields
        private readonly IRepository<DropDown> _dropdownRepository;
        private readonly IRepository<DropDownType> _dropdownTypeRepository;
        #endregion

        #region Ctor
        public DropDownService(IRepository<DropDown> dropDownRepository, IRepository<DropDownType> dropdownTypeRepository)
        {
            _dropdownRepository = dropDownRepository;
            _dropdownTypeRepository = dropdownTypeRepository;
        }
        #endregion

        #region Private Methods

        private static string GetOrderBy(string orderBy)
        {
            return orderBy;
        }

        #endregion

        #region Public Methods

        public IPagedList<DropDown> GetAllDropDowns(string dropdownTypeId, string sortBy,
            bool descending, int page = 1, int pageSize = int.MaxValue, bool lookup = false)
        {
            var query = _dropdownRepository.Table;

            // global filter
            query = query.Where(x => !x.Deleted);

            // custom filter
            if (!string.IsNullOrWhiteSpace(dropdownTypeId))
            {
                query = query.Where(x => x.DropDownTypeId.Contains(dropdownTypeId));
            }

            //sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                var orderBy = $"{GetOrderBy(sortBy)} {(descending ? "desc" : "asc")}";

                query = query.OrderBy(orderBy);
            }
            else
            {
                query = query.OrderBy(x => x.DropDownValue);
            }

            if (lookup)
            {
                query = query.Select(x => new DropDown
                {
                    Id = x.Id,
                    DropDownValue = x.DropDownValue,
                    DisplayName = x.DisplayName,
                    FilePath = x.FilePath,
                });
            }
            else
            {
                // projection
                query = query.Select(x => new DropDown
                {
                    Id = x.Id,
                    DropDownValue = x.DropDownValue,
                    DisplayName = x.DisplayName,
                    Active = x.Active,
                    FilePath = x.FilePath,
                    DropDownType = new DropDown
                    {
                        Id = x.DropDownType.Id,
                        DropDownValue = x.DropDownType.DropDownValue,
                        DisplayName = x.DropDownType.DisplayName,
                    }
                });
            }

            var list = new PagedList<DropDown>(query, page, pageSize);

            return list;
        }

        public async Task<IList<DropDown>> GetDropDowns(string TypeId, string dropdownType = null, string orderbyColumn = null)
        {
            var query = _dropdownRepository.Table;

            query = query.Where(x => x.DropDownTypeId == TypeId && !x.Deleted);

            if (dropdownType != null)
                query = query.Where(x => x.Type == dropdownType);

            if (orderbyColumn != null)
                query = query.OrderBy(orderbyColumn);
            else
                query = query.OrderBy(x => x.DropDownValue);

            query = query.Select(x => new DropDown
            {
                Id = x.Id,
                DropDownTypeId = x.DropDownTypeId,
                DropDownValue = x.DropDownValue,
                DisplayName = x.DisplayName,
                Sortorder = x.Sortorder,
                Description = x.Description,
                FilePath = x.FilePath,
                Type = x.Type,
                
            });

            var list = await query.ToListAsync();

            return list;
        }

        public async Task<IList<DropDown>> GetAllDropDowns(string TypeId)
        {
            var query = _dropdownRepository.Table;

            query = query.Where(x => x.DropDownTypeId == TypeId && !x.Deleted);
        
            query = query.OrderBy(x => x.Sortorder);

            query = query.Select(x => new DropDown
            {
                Id = x.Id,
                DropDownTypeId = x.DropDownTypeId,
                DropDownValue = x.DropDownValue,
                DisplayName = x.DisplayName,
                Sortorder = x.Sortorder,
                Description = x.Description,
                FilePath = x.FilePath,
                Type = x.Type,                
            });

            var list = await query.ToListAsync();

            return list;
        }

        public async Task<DropDownType> GetDropDownType(string type)
        {
            var query = _dropdownTypeRepository.Table;

            query = query.Where(x => x.Type == type);            

            var item = await query.FirstOrDefaultAsync();

            return item;
        }

        public async Task<DropDown> GetById(string id)
        {
            var query = _dropdownRepository.Table;

            query = query.Where(x => x.Id == id);

            query = query.Where(x => !x.Deleted);

            var item = await query.FirstOrDefaultAsync();

            return item;
        }

        public async Task<DropDown> GetByName(string name)
        {
            var query = _dropdownRepository.Table;

            query = query.Where(x => x.DropDownValue.ToLower().Replace(" ","-") == name.ToLower());

            query = query.Where(x => !x.Deleted);

            var item = await query.FirstOrDefaultAsync();

            return item;
        }

        public void InsertDropDown(DropDown entity)
        {
            _dropdownRepository.Insert(entity);
        }

        public void UpdateDropDown(DropDown entity)
        {
            _dropdownRepository.Update(entity);
        }

        public void DeleteDropDown(DropDown entity)
        {
            entity.Deleted = true;

            _dropdownRepository.Update(entity);
        }

        #endregion
    }
}

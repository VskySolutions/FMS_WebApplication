
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vsky.Api.ApiErrors;
using Vsky.Api.Extensions;
using Vsky.Api.Models;
using Vsky.Models;
using Vsky.Services.DropDowns;
using static Vsky.Api.Models.DropDownModel;

namespace Vsky.Api.Controllers
{
    [Route("drop-downs")]
    public class DropDownsController : BaseController
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IDropDownService _dropDownService;

        #endregion

        #region Ctor

        public DropDownsController(IMapper mapper, IDropDownService dropDownService)
        {
            _mapper = mapper;
            _dropDownService = dropDownService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IActionResult GetAllDropDowns([FromQuery] DropDownSearchModel searchModel)
        {
            var list = _dropDownService.GetAllDropDowns(searchModel.DropDownTypeId, searchModel.SortBy, searchModel.Descending, searchModel.Page, searchModel.PageSize);

            var model = new DropDownListModel
            {
                Data = _mapper.Map<IList<DropDownModel>>(list),
                Total = list.TotalCount
            };

            return Ok(model);
        }

        [HttpGet("list")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string type, string dropdownType=null, string orderbyColumn=null)
        {
            try
            {
                var item = await _dropDownService.GetDropDownType(type);

                var list = await _dropDownService.GetDropDowns(item.Id, dropdownType, orderbyColumn);

                var model = _mapper.Map<IList<DropDownViewModel>>(list);

                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("all-list")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllList(string type)
        {
            try
            {
                var item = await _dropDownService.GetDropDownType(type);

                var list = await _dropDownService.GetAllDropDowns(item.Id);

                var model = _mapper.Map<IList<DropDownViewModel>>(list);

                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("by-name/{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDropDownByName(string name)
        {
            var entity = await _dropDownService.GetByName(name);

            if (entity == null)
            {
                return BadRequest(new BadRequestError("No dropDown found with the specified id."));
            }

            var model = _mapper.Map<DropDownModel>(entity);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDropDownById(string id)
        {
            var entity = await _dropDownService.GetById(id);

            if (entity == null)
            {
                return BadRequest(new BadRequestError("No dropDown found with the specified id."));
            }

            var model = _mapper.Map<DropDownModel>(entity);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateDropDown(DropDownModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<DropDown>(model);

                entity.CreatedById = User.GetLoggedInUserId<string>();
                entity.CreatedOnUtc = DateTime.UtcNow;

                _dropDownService.InsertDropDown(entity);

                return NoContent();
            }

            return ModelStateError(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDropDown(string id, DropDownModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _dropDownService.GetById(id);

                if (entity == null)
                {
                    return BadRequest(new BadRequestError("No dropDown found with the specified id."));
                }

                entity = _mapper.Map(model, entity);

                entity.UpdatedById = User.GetLoggedInUserId<string>();
                entity.UpdatedOnUtc = DateTime.UtcNow;

                _dropDownService.UpdateDropDown(entity);

                return NoContent();
            }

            return ModelStateError(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDropDown(string id)
        {
            var entity = await _dropDownService.GetById(id);

            if (entity == null)
            {
                return BadRequest(new BadRequestError("No DropDown found with the specified id."));
            }

            _dropDownService.DeleteDropDown(entity);

            return NoContent();
        }

        #endregion
    }
}

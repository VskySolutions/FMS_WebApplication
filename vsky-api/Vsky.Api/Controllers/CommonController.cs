using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Vsky.Api.ApiErrors;
using Vsky.Api.Models;
using Vsky.Data;
using Vsky.Models;
using Vsky.Services.Common;
using Vsky.Services.Messages;
using System.Linq;
using Vsky.Api.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Vsky.Api.Controllers
{
    [Route("common")]
    public class CommonController : BaseController
    {
        #region Fields
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly ApplicationDbContext _db;
        #endregion

        #region Ctor
        public CommonController(ICommonService commonService, ApplicationDbContext db,
            IMapper mapper, IWorkflowMessageService workflowMessageService)
        {
            _commonService = commonService;
            _mapper = mapper;
            _db = db;
            _workflowMessageService = workflowMessageService;
        }
        #endregion

        #region Methods

        [HttpGet("countries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var list = await _commonService.GetAllCountries();

            var model = _mapper.Map<IList<CountryModel>>(list);

            return Ok(model);
        }

        [HttpGet("state-provinces")]
        public async Task<IActionResult> GetAllStateProvinces(string countryId)
        {
            var list = await _commonService.GetAllStateProvinces(countryId);

            var model = _mapper.Map<IList<StateProvinceModel>>(list);

            return Ok(model);
        }

        [HttpGet("picture")]
        public async Task<IActionResult> GetPicture(string PictureId=null)
        {
            var entity = await _commonService.GetBinaryPictureByPictureId(PictureId);

            if (entity == null)
            {
                return BadRequest(new BadRequestError("No image found with the specified id."));
            }

            var model = _mapper.Map<PictureBinaryModel>(entity);

            return Ok(model);
        }

        #endregion
    }
}
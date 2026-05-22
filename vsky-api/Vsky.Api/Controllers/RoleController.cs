
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vsky.Api.ApiErrors;
using Vsky.Api.Extensions;
using Vsky.Api.Models;
using Vsky.Data;
using Vsky.Models;
using static Vsky.Api.Models.RoleModel;

namespace Vsky.Api.Controllers
{
    [Route("roles")]
    public class RoleController : BaseController
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Ctor
        public RoleController(IMapper mapper,
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager
            )
        {
            _mapper = mapper;
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        #endregion

        #region Methods

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var loggedUserId = User.GetLoggedInUserId<string>();
            var loggedUser = _db.Users.Where(x => x.Id== loggedUserId).FirstOrDefault();

            var list = _roleManager.Roles.OrderByDescending(x=>x.CreatedOnUtc).ToList();

            var model = new RoleModel
            {
                Data = _mapper.Map<IList<RoleModel>>(list),
                Total = list.Count()
            };

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var entity = await _roleManager.FindByIdAsync(id);

            if (entity == null)
            {
                return BadRequest(new BadRequestError("No role found with the specified id."));
            }

            var model = _mapper.Map<RoleModel>(entity);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            try
            {
                var exists = _db.Roles.Any(x => x.Name == model.Name);
                if (exists)
                {
                    return BadRequest(new BadRequestError("Role Name already exists."));
                }

                var loggedUserId = User.GetLoggedInUserId<string>();
                var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

                var newRole = new ApplicationRole();
                newRole.Id = Guid.NewGuid().ToString();
                newRole.Name = model.Name;
                newRole.NormalizedName = model.Name.ToLower();
                newRole.ConcurrencyStamp = Guid.NewGuid().ToString();
                newRole.CreatedById = loggedUserId;
                newRole.CreatedOnUtc = DateTime.UtcNow;
                var roleCreated = await _roleManager.CreateAsync(newRole);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, RoleModel model)
        {
            var exists = _db.Roles.Any(x => x.Name == model.Name && x.Id != id);
            if (exists)
            {
                return BadRequest(new BadRequestError("Role Name already exists."));
            }

            var entity = await _roleManager.FindByIdAsync(id);
            if (entity == null)
            {
                return BadRequest(new BadRequestError("No role found with the specified id."));
            }

            entity = _mapper.Map(model, entity);

            entity.Name = model.Name;
            entity.NormalizedName = model.Name.ToLower();
            entity.UpdatedById = User.GetLoggedInUserId<string>();
            entity.UpdatedOnUtc = DateTime.UtcNow;
            await _roleManager.UpdateAsync(entity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            //var entity = await _companyService.GetById(id);

            //if (entity == null)
            //{
            //    return BadRequest(new BadRequestError("No company found with the specified id."));
            //}

            //_companyService.DeleteCompany(entity);

            return NoContent();
        }


        #endregion
    }
}

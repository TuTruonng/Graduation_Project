using AutoMapper;
using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Controllers
{
    [Route("[controller]")]
    //[EnableCors("AllowOrigins")]
    [ApiController]
    //[Authorize("Bearer")]

    public class RealEstateController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public readonly IRealEstate _realStateService;
        private readonly IMapper _mapper;

        public RealEstateController(ApplicationDbContext dbContext, IRealEstate realStatrService, IMapper mapper)
        {
            _dbContext = dbContext;
            _realStateService = realStatrService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<RealEstateModel>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _realStateService.GetAllAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<bool>> GetById(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _realStateService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("category={categoryName}")]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> GetByCategory(string categoryName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(categoryName);
            }

            var result = await _realStateService.GetByCategoryAsync(categoryName);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> CreateAsync([FromBody] RealEstateCreateRequest productShare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(productShare);
            }

            var result = await _realStateService.CreateRealEstatesAsync(productShare);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            if (!ModelState.IsValid && string.IsNullOrEmpty(id))
            {
                return BadRequest(id);
            }

            var result = await _realStateService.DeleteRealEstateModelAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<ListApprove>> UpdateAsync(string id, [FromForm] ListApprove model)
        {
            //if (!ModelState.IsValid && string.IsNullOrEmpty(id))
            //{
            //    return BadRequest(id);
            //}

            var result = await _realStateService.UpdateRealEstateAsync(id, model);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

    }
}

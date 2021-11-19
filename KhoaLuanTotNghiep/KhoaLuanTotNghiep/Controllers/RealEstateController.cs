﻿using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using ShareModel.Constant;
using System.Threading;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Controllers
{
    [Route("[controller]")]
    //[EnableCors("AllowOrigins")]
    [ApiController]
    //[Authorize("Bearer")]

    public class RealEstateController : ControllerBase
    {
        public readonly IRealEstate _realStateService;

        public RealEstateController(IRealEstate realStatrService)
        {
            _realStateService = realStatrService;
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<ActionResult<PagedResponseDto<RealEstateModel>>> Get([FromQuery] RealEstateCriteriaDto realEstateCriteriaDto,
        //    CancellationToken cancellationToken)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var result = await _realStateService.GetAllAsync(realEstateCriteriaDto, cancellationToken);
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<PagedResponseDto<RealEstateModel>>> Get()
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
        public async Task<ActionResult<RealEstateCreateRequest>> CreateAsync([FromForm] RealEstateCreateRequest productShare)
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

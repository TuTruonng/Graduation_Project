using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Controllers
{
    [Route("[Controller]")]
    [ApiController]

    public class NewsController : ControllerBase
    {
        private readonly INews _newsService;
        public NewsController(INews newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<NewsModel>>> GetListAsync()
        {
            return Ok(await _newsService.GetListNewsAsync());

        }

        [HttpGet]
        [Route("name={name}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<NewsModel>>> GetListNewsUserNameAsync(string name)
        {
            return Ok(await _newsService.GetListNewsUserNameAsync(name));

        }

        [HttpPost]
        [Route("name={name}")]
        [AllowAnonymous]
        public async Task<ActionResult<CreateNewsModel>> CreateAsync(string name, CreateNewsModel newsModel)
        {
            if (!ModelState.IsValid) return BadRequest(newsModel);
            return Ok(await _newsService.CreateNewsAsync(newsModel, name));

        }

        [HttpPut("disable/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("News Id is not valid");
            return Ok(await _newsService.DeleteNewsAsync(id));

        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<NewsModel>> UpdateAsync(string id, [FromForm] NewsModel newsModel)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("News Id is not valid");
            return Ok(await _newsService.UpdateNewsAsync(id, newsModel));

        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<NewsModel>> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("News ID not valid");
            return Ok(await _newsService.GetNewsByIDAsync(id));
        }
    }
}

using Marks.Core.Models;
using Marks.Core.PagingSorting;
using Marks.Web.Services;
using Marks.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Marks.Web.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly ICrudService<People, long, PeopleMarkViewModel> _crudService;

        public ApiController(ICrudService<People, long, PeopleMarkViewModel> crudService)
        {
            _crudService = crudService;
        }

        /// <summary>
        /// Uses CRUD service for getting paged and sorted items.
        /// </summary>
        /// <param name="input">Paging and sorting</param>
        /// <returns>Response object with status description and items as result if success</returns>
        public async Task<IActionResult> GetAll(PagedAndSortedInput input)
        {
            input.ValidateAndSetDefaults();

            PagedOutput<PeopleMarkViewModel> model = null;

            try
            {
                model = await _crudService.GetAll(input, p => p.Mark);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResult.FailResult(ex.Message));
            }
            

            return Json(ApiResult.SuccessResult(model));
        }

        /// <summary>
        /// Validates input model, than uses CRUD service to insert data to database.
        /// </summary>
        /// <param name="model">ViewModel with needed data to insert</param>
        /// <returns>Status description</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PeopleMarkViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorMessage = string.Empty;

                foreach (var error in ModelState)
                {
                    foreach (var message in error.Value.Errors)
                    {
                        errorMessage += $"{message.ErrorMessage}\n";
                    }
                }

                return StatusCode(500, ApiResult.FailResult(errorMessage));
            }

            try
            {
                await _crudService.Create(model);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, 
                    ApiResult.FailResult("Something went wrong while inserting data to database. Notice that \"Full Name\" should be unique."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResult.FailResult(ex.Message));
            }

            return Ok(ApiResult.SuccessResult());
        }
    }
}
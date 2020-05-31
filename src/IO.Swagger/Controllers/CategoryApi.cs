using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;
using IO.Swagger.Security;
using Microsoft.AspNetCore.Authorization;
using IO.Swagger.Models;
using IO.Swagger.DBModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using IO.Swagger.DAL;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class CategoryApiController : ControllerBase
    { 
         DAL.CategoryDal _categoryDal;

        public CategoryApiController(PetstoreDBContext _context)//PetstoreDBContext context)
        {
             _categoryDal = new CategoryDal(_context);
        }

        /// <summary>
        /// Add a new Category to the store
        /// </summary>
        
        /// <param name="Category">Category object that needs to be added to the store</param>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/v2/Category")]
        [ValidateModelState]
        [SwaggerOperation("AddCategory")]
        public virtual ActionResult<CategoryCreateResponsetDto> AddCategory([FromBody] CategoryCreateRequestDto category)
        {
            try
            { 
                category.Validate();
              
                //Convert DTO object to DAO
                DBModels.Category categoryDao = new DBModels.Category();
                categoryDao.Name = category.Name;
             
                //Create CategoryDal to get CategoryID from name 
                _categoryDal.saveCategory(categoryDao);
            
                //Convert response DAO to DTO
                CategoryCreateResponsetDto result = new CategoryCreateResponsetDto();
                result.Id = categoryDao.Id;
                result.Name = categoryDao.Name;

                Console.WriteLine("Received request for new category. Thank you!!!");
                return StatusCode(201, result);


            }
            catch(ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch(DbUpdateException ex)
            {
                if(ex.InnerException.GetType() == typeof(SqlException)
                    && ((SqlException)(ex.InnerException)).Number == 2601)
                {
                    ApiResponse response = new ApiResponse();
                    response.Code = 409; 
                    response.Type = "Duplicate";
                    response.Message = "Category with the same name already exist."; 
                
                    return StatusCode((int)response.Code, response);
                }
               
               return StatusCode(500);
            }
        }
    }
}
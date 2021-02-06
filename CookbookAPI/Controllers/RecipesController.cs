using System;
using System.Collections.Generic;
using CookbookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//using System.Web.Http;
using System.Net;

namespace CookbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeRepository recipeRepository;
        private readonly SectionRepository sectionRepository;
        public RecipesController()
        {
            recipeRepository = new RecipeRepository();
            sectionRepository = new SectionRepository();
        }

        [HttpGet]
        public IEnumerable<Recipe> GetAll()
        {
            return recipeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Recipe GetById(int id)
        {
            return recipeRepository.GetById(id);
        }

        [HttpGet("section/{id}")]
        public IEnumerable<Recipe> GetAllFromSection(int id)
        {
            return recipeRepository.GetAllFromSection(id);
        }

        [HttpPost]
        public void Post([FromBody] Recipe rcp)
        {
            ValidateCookbookSectionIds(rcp, sectionRepository.GetByCookbookId(rcp.CookbookId));
            if (ModelState.IsValid)
                recipeRepository.Add(rcp);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Recipe rcp)
        {
            rcp.RecipeId = id;
            if (ModelState.IsValid)
                recipeRepository.Update(rcp);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            recipeRepository.Delete(id);
            // Add call to delete all notes for a recipe.
        }

        private static void ValidateCookbookSectionIds(Recipe rcp, IEnumerable<Section> results)
        {
            bool found = false;
            foreach (var result in results)
            {
                if (result.SectionId == rcp.SectionId)
                {
                    found = true;
                }
            }
            if (!found)
            {
                throw new ArgumentException("Error: SectionId and CookbookId must be valid...");
            }
        }
    }
}
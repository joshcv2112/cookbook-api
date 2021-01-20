using System.Collections.Generic;
using CookbookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeRepository recipeRepository;
        public RecipesController()
        {
            recipeRepository = new RecipeRepository();
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
        public void Post([FromBody] Recipe prod)
        {
            // ADD VALIDATION TO VERIFY THAT SECTION BELONGS TO COOKBOOK....
            if (ModelState.IsValid)
                recipeRepository.Add(prod);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Recipe prod)
        {
            prod.RecipeId = id;
            if (ModelState.IsValid)
                recipeRepository.Update(prod);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            recipeRepository.Delete(id);
            // Add call to delete all notes for a recipe.
        }
    }
}
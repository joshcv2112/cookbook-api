using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookbookAPI.Models;
using Microsoft.AspNetCore.Http;
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
        public IEnumerable<Recipe> Get()
        {
            return recipeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return recipeRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]Recipe prod)
        {
            if (ModelState.IsValid)
                recipeRepository.Add(prod);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Recipe prod)
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
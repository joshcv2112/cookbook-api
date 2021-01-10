using CookbookAPI.Controllers;
using NUnit.Framework;
using System;

namespace CookbookAPI_UnitTests
{
    public class Tests
    {


        [Test]
        public void CreateRecipe_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.CreateRecipe(new RecipeCreateDto { });
            Assert.IsInstanceOf<ActionResult<RecipeReadDto>>(result);
        }
    }
}

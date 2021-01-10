using System.Collections.Generic;
using CookbookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookbooksController : ControllerBase
    {
        private readonly CookbookRepository cookbookRepository;
        public CookbooksController()
        {
            cookbookRepository = new CookbookRepository();
        }

        [HttpGet]
        public IEnumerable<Cookbook> Get()
        {
            return cookbookRepository.GetAll();
        }

        [HttpGet("{cookbookId}")]
        public Cookbook Get(int cookbookId)
        {
            return cookbookRepository.GetById(cookbookId);
        }

        [HttpPost]
        public void Post([FromBody] Cookbook cookbook)
        {
            if (ModelState.IsValid)
                cookbookRepository.Add(cookbook);
        }

        [HttpPut("{cookbookId}")]
        public void Put(int cookbookId, [FromBody] Cookbook cookbook)
        {
            cookbook.CookbookId = cookbookId;
            if (ModelState.IsValid)
                cookbookRepository.Update(cookbook);
        }

        [HttpDelete("{cookbookId}")]
        public void Delete(int cookbookId)
        {
            cookbookRepository.Delete(cookbookId);
        }
    }
}
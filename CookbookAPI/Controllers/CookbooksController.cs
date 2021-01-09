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

        [HttpGet("{id}")]
        public Cookbook Get(int id)
        {
            return cookbookRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]Cookbook cookbook)
        {
            if (ModelState.IsValid)
                cookbookRepository.Add(cookbook);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Cookbook cookbook)
        {
            if (ModelState.IsValid)
                cookbookRepository.Update(cookbook);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cookbookRepository.Delete(id);
        }
    }
}
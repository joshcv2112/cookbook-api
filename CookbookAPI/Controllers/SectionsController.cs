using System.Collections.Generic;
using CookbookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly SectionRepository sectionRepository;
        public SectionsController()
        {
            sectionRepository = new SectionRepository();
        }

        [HttpGet]
        public IEnumerable<Section> Get()
        {
            return sectionRepository.GetAll();
        }

        [HttpGet("{sectionId}")]
        public Section Get(int sectionId)
        {
            return sectionRepository.GetById(sectionId);
        }

        // Add endpoint to get sections by cookbookId instead of by sectionId

        [HttpPost]
        public void Post([FromBody] Section prod)
        {
            if (ModelState.IsValid)
                sectionRepository.Add(prod);
        }

        [HttpPut("{sectionId}")]
        public void Put(int sectionId, [FromBody] Section prod)
        {
            prod.SectionId = sectionId;
            if (ModelState.IsValid)
                sectionRepository.Update(prod);
        }

        [HttpDelete("{sectionId}")]
        public void Delete(int sectionId)
        {
            sectionRepository.Delete(sectionId);
        }
    }
}
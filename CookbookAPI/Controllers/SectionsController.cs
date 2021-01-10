﻿using System.Collections.Generic;
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
        public IEnumerable<Section> GetAllSections()
        {
            return sectionRepository.GetAll();
        }

        [HttpGet("{sectionId}")]
        public Section GetSectionById(int sectionId)
        {
            return sectionRepository.GetById(sectionId);
        }

        [HttpGet("cookbook/{cookbookId}")]
        public IEnumerable<Section> GetSectionsByCookbook(int cookbookId)
        {
            return sectionRepository.GetByCookbookId(cookbookId);
        }

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
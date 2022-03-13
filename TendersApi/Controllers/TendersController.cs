using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TendersApi.Model;

namespace TendersApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TendersController : ControllerBase
    {
        public IEnumerable<Tender> List { get ; set; } = new List<Tender>
            {
                new Tender
                {
                    Id=1,
                    Name="Vanzare detergenti",
                    StartPrice=100,
                    CreatedOn = DateTime.Now,
                    CPVCode = "A100"
                },
                new Tender
                {
                    Id=2,
                    Name="Prestare servicii de gradinarit",
                    StartPrice=1000,
                    CreatedOn = DateTime.Now,
                    CPVCode = "B100"
                },
                new Tender
                {
                    Id=3,
                    Name="Prestare servicii audit",
                    StartPrice=2000,
                    CreatedOn = DateTime.Now,
                    CPVCode = "C100"
                }
            };

        [HttpGet]
        public IEnumerable<Tender> Get()
        {
            return List;
        }

        [HttpGet("{id}")]
        public Tender Get(int id)
        {
            var tender = List.Where(x => x.Id == id)?.First();
            return tender;
        }

        [HttpPost]
        public IEnumerable<Tender> Post(string name, int startPrice)
        {
            var newTender = new Tender
            {
                Id = List.Count() + 1,
                Name = name,
                StartPrice = startPrice
            };

            var result = List.ToList();
            result.Add(newTender);

            return result;
        }
    }
}

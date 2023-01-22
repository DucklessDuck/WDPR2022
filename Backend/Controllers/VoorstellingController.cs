using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Text;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VoorstellingController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public VoorstellingController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voorstelling>>> GetVoorstellingen()
        {
            try
            {
                return (await _context.Voorstellingen.ToListAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //... Get accountId by emailaddress ..//
        [HttpGet("getVoorstellingenByDate")]
        public async Task<ActionResult<Voorstelling>> getVoorstellingenByDate(DateTime datum)
        {
            var result = await _context.Voorstellingen.Where((e) => e.VoorstellingsDatum >= datum).FirstOrDefaultAsync();
            if(result == null)
                return NotFound();

            return result;
        }



        //... Aanmaken van voorstelling ...//
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateVoorstelling([FromBody] CreateVoorstellingRequestData request)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            var voorstelling = new Voorstelling
            {
                NaamVoorstelling = request.naamvoorstelling,
                VoorstellingsDatum = request.datumtijd,
                Beschrijving = request.beschrijving,
                ZaalID = request.zaalid
                // Crew = request.Crew
                // Tickets = request.Tickets
            };

            var result =  _context.Voorstellingen.Add(voorstelling);
            await _context.SaveChangesAsync();

            return Ok(200);
            // return await result.ReloadAsync ? new BadRequestObjectResult(result) : StatusCode(201);
        }


        public class CreateVoorstellingRequestData
        {
            public string naamvoorstelling { get; set; }
            public DateTime datumtijd { get; set; }
            public string beschrijving { get; set; }
            public int zaalid { get; set; }

            // public FileModel file {get; set;}

            // public List<BetrokkenPersoon> Crew { get; set; }
            // public List<Kaart> Tickets { get; set; }
        }
    }
}

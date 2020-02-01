using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PathApp.Data;
using PathApp.Models;
using PathApp.Services;

namespace PathApp.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ApiPathController : Controller
    {
        private readonly PercorsiContext _context;

        public ApiPathController(PercorsiContext context)
        {
            _context = context;
        }

        //GET: api/PercorsiModels
        //[HttpGet]
        public async Task<ActionResult<IEnumerable<PercorsiModel>>> Percorsi()
        {
            return await _context.PercorsiModel.ToListAsync();
        }

        // GET: api/PercorsiModels
        /// <summary>
        /// return list of path with stations name.
        /// Original and Destination parameters are mandatory.
        /// </summary>
        /// <param name="o">Original Station Name</param>
        /// <param name="d">Destination Station Name</param>
        /// <param name="v1">Via1 Station Name</param>
        /// <param name="v2">Via2 Station Name</param>
        /// <returns>List path in json model</returns>
        [HttpGet]
        public ActionResult<IEnumerable<NewPercorsiModel>> GetPathsByStationName([FromQuery] string o, string d, string? v1, string? v2)
        {
            PathService pathService = new PathService(_context);
            int idOriginalStation;
            int idDestinationStation;
            int idVia1;
            int idVia2;

            //406NotAcceptable
            if ((o == null || o == string.Empty) && (d == null || d == string.Empty))
            {
                return StatusCode(406, "406 Error.The parameters Original station(o) or Destination station(d) are Empty and not acceptable.");
            }
            else if (o == null || o == string.Empty)
            {
                return StatusCode(406, "406 Error.The parameter Original station(o) is Empty and not acceptable.");
            }
            else if (d == null || d == string.Empty)
            {
                return StatusCode(406, "406 Error.The parameter Destination station(d) is Empty and not acceptable.");
            }

            idOriginalStation = pathService.GetIdStationByName(o);
            idDestinationStation = pathService.GetIdStationByName(d);
            idVia1 = pathService.GetIdStationByName(v1);
            idVia2 = pathService.GetIdStationByName(v2);

            //404NotFound

            if ((idOriginalStation == 0) && (idDestinationStation == 0))
            {
                return StatusCode(404, "404 Error.The parameters Original station or Destination station that you insert Not Found.");
            }
            else if (idOriginalStation == 0)
            {
                return StatusCode(404, "404 Error.The parameter Original station that you insert Not Found.");
            }
            else if (idDestinationStation == 0)
            {
                return StatusCode(404, "404 Error.The parameter Destination station that you insert Not Found.");
            }
            else if ((v1 != null) && (idVia1 == 0))
            {
                return StatusCode(404, "404 Error.The parameter Via1 station that you insert Not Found.");
            }
            else if ((v2 != null) && (idVia2 == 0))
            {
                return StatusCode(404, "404 Error.The parameter Via2 station that you insert Not Found.");
            }
            
            return pathService.GetPathsByStationsName(o, d, v1, v2);
        }
    }
}
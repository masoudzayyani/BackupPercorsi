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
    public class PathController : Controller
    {
        private readonly PercorsiContext _context;

        public PathController(PercorsiContext context)
        {
            _context = context;
        }

        // GET: Path
        public async Task<IActionResult> Index()
        {
            return View(await _context.PercorsiModel.ToListAsync());
            //return View();
        }

        // GET: Path/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var percorsiModel = await _context.PercorsiModel
                .FirstOrDefaultAsync(m => m.IdPercorso == id);
            if (percorsiModel == null)
            {
                return NotFound();
            }

            return View(percorsiModel);
        }

        // GET: Path/Create
        public IActionResult Create()
        {
            PathService pathService = new PathService(_context);
            ViewBag.originalStationsList = pathService.ReturnListStationsForDropDowns(0, false);
            ViewBag.destinationStationsList = pathService.ReturnListStationsForDropDowns(0, false);
            ViewBag.via1StationsList = pathService.ReturnListStationsForDropDowns(0, true);
            ViewBag.via2StationsList = pathService.ReturnListStationsForDropDowns(0, true);
            return View();
        }

        // POST: Path/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include: "IdPercorso,IdSottorete,Distanza,Versione")] PercorsiModel percorsiModel)
        {
            percorsiModel.IdStazioneOrigine = System.Convert.ToInt32(Request.Form["drpOriginalStation"]);
            percorsiModel.IdStazioneDestinazione = System.Convert.ToInt32(Request.Form["drpDestinationStation"]);
            percorsiModel.IdVia1 = System.Convert.ToInt32(Request.Form["drpVia1Station"]);
            percorsiModel.IdVia2 = System.Convert.ToInt32(Request.Form["drpVia2Station"]);
            if (ModelState.IsValid)
            {
                _context.Add(percorsiModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PathService pathService = new PathService(_context);
            ViewBag.originalStationsList = pathService.ReturnListStationsForDropDowns(percorsiModel.IdStazioneOrigine, false);
            ViewBag.destinationStationsList = pathService.ReturnListStationsForDropDowns(percorsiModel.IdStazioneDestinazione, false);
            ViewBag.via1StationsList = pathService.ReturnListStationsForDropDowns(percorsiModel.IdVia1, true);
            ViewBag.via2StationsList = pathService.ReturnListStationsForDropDowns(percorsiModel.IdVia2, true);
            return View(percorsiModel);
        }

        // GET: Path/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var percorsiModel = await _context.PercorsiModel.FindAsync(id);
            if (percorsiModel == null)
            {
                return NotFound();
            }
            return View(percorsiModel);
        }

        // POST: Path/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPercorso,IdSottorete,IdStazioneOrigine,IdStazioneDestinazione,IdVia1,IdVia2,Distanza,Version")] PercorsiModel percorsiModel)
        {
            if (id != percorsiModel.IdPercorso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(percorsiModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PercorsiModelExists(percorsiModel.IdPercorso))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(percorsiModel);
        }

        // GET: Path/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var percorsiModel = await _context.PercorsiModel
                .FirstOrDefaultAsync(m => m.IdPercorso == id);
            if (percorsiModel == null)
            {
                return NotFound();
            }
            PathService pathService = new PathService(_context);
            ViewBag.originalStationName = pathService.GetNameStationByID(percorsiModel.IdStazioneOrigine);
            ViewBag.destinationStationName = pathService.GetNameStationByID(percorsiModel.IdStazioneDestinazione);
            ViewBag.via1StationName = pathService.GetNameStationByID(percorsiModel.IdVia1);
            ViewBag.via2StationName = pathService.GetNameStationByID(percorsiModel.IdVia2);
            return View(percorsiModel);
        }

        // POST: Path/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var percorsiModel = await _context.PercorsiModel.FindAsync(id);
            _context.PercorsiModel.Remove(percorsiModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PercorsiModelExists(int id)
        {
            return _context.PercorsiModel.Any(e => e.IdPercorso == id);
        }
    }
}

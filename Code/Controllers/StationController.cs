using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PathApp.Data;
using PathApp.Models;

namespace PathApp.Controllers
{
    [Authorize]
    public class StationController : Controller
    {
        private readonly PercorsiContext _context;

        public StationController(PercorsiContext context)
        {
            _context = context;
        }

        // GET: Station
        public async Task<IActionResult> Index()
        {
            return View(await _context.StazioneModel.ToListAsync());
        }

        // GET: Station/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var stazioneModel = await _context.StazioneModel
                .FirstOrDefaultAsync(m => m.IDStazione == id);
            if (stazioneModel == null)
            {
                return NotFound();
            }

            return View(stazioneModel);
        }

        // GET: Station/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Station/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDStazione,CodiceStazione,NomeStazione,RitiroTessera,RiCaricaAbbonamento,Versione")] StazioneModel stazioneModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stazioneModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stazioneModel);
        }

        // GET: Station/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var stazioneModel = await _context.StazioneModel.FindAsync(id);
            if (stazioneModel == null)
            {
                return NotFound();
            }
            return View(stazioneModel);
        }

        // POST: Station/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDStazione,CodiceStazione,NomeStazione,RitiroTessera,RiCaricaAbbonamento,Versione")] StazioneModel stazioneModel)
        {
            if (id != stazioneModel.IDStazione)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stazioneModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StazioneModelExists(stazioneModel.IDStazione))
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
            return View(stazioneModel);
        }

        // GET: Station/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var stazioneModel = await _context.StazioneModel
                .FirstOrDefaultAsync(m => m.IDStazione == id);
            if (stazioneModel == null)
            {
                return NotFound();
            }

            return View(stazioneModel);
        }

        // POST: Station/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stazioneModel = await _context.StazioneModel.FindAsync(id);
            _context.StazioneModel.Remove(stazioneModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StazioneModelExists(int id)
        {
            return _context.StazioneModel.Any(e => e.IDStazione == id);
        }
    }
}

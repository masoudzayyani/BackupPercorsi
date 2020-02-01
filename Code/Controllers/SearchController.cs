using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PathApp.Data;
using PathApp.Services;
using System.Linq;
using System.Collections.Generic;
using PathApp.Models;

namespace PathApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly PercorsiContext _context;
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;

        public SearchController(PercorsiContext context)
        {
            _context = context;
            //_userManager = userManager;
            //_signInManager = signInManager;
        }

        public IActionResult Index()
        {
            PathService pathService = new PathService(_context);
            var listItems = new List<SelectListItem>();
            listItems = pathService.ReturnListStationsForDropDowns(0, true);
            ViewBag.originalStationsList = listItems;
            ViewBag.destinationStationsList = listItems;
            ViewBag.Via1StationsList = pathService.MakeEmptyItemForDropdowns(0);
            ViewBag.Via2StationsList = pathService.MakeEmptyItemForDropdowns(0);

            //CraeteAdminForFirstTime();

            return View();
        }

        //public async void CraeteAdminForFirstTime()
        //{
        //    var user = new IdentityUser { UserName = "admin", EmailConfirmed = true, NormalizedUserName = "ADMIN" };
        //    var result = await _userManager.CreateAsync(user, "Admin@654321");
        //    if (result.Succeeded)
        //        await _signInManager.SignInAsync(user, isPersistent: false);
        //}

        [HttpPost]
        public IActionResult SearchPath()
        {
            List<SelectListItem> listItemsOriginal = new List<SelectListItem>();
            List<SelectListItem> listItemsDestination = new List<SelectListItem>();
            PathService pathService = new PathService(_context);

            if (ModelState.IsValid)
            {
                //listItemsOriginal = pathService.ReturnSortedListOfStations().Select(
                //    s => new SelectListItem
                //    {
                //        Text = s.NomeStazione,
                //        Value = s.IDStazione.ToString(),
                //        Selected = (s.IDStazione == System.Convert.ToInt32(Request.Form["drpOriginalStation"]) ? true : false)
                //    }).ToList();
                //listItemsOriginal.Insert(0, new SelectListItem
                //{
                //    Text = "-- Select Station --",
                //    Value = System.Convert.ToString(0),
                //    Selected = (0 == System.Convert.ToInt32(Request.Form["drpOriginalStation"]) ? true : false)
                //});

                //listItemsDestination = pathService.ReturnSortedListOfStations().Select(
                //    s => new SelectListItem
                //    {
                //        Text = s.NomeStazione,
                //        Value = s.IDStazione.ToString(),
                //        Selected = (s.IDStazione == System.Convert.ToInt32(Request.Form["drpDestinationStation"]) ? true : false)
                //    }).ToList();
                //listItemsDestination.Insert(0, new SelectListItem
                //{
                //    Text = "-- Select Station --",
                //    Value = System.Convert.ToString(0),
                //    Selected = (0 == System.Convert.ToInt32(Request.Form["drpDestinationStation"]) ? true : false)
                //});

                ViewBag.originalStationsList = pathService.ReturnListStationsForDropDowns(System.Convert.ToInt32(Request.Form["drpOriginalStation"]), true);
                ViewBag.destinationStationsList = pathService.ReturnListStationsForDropDowns(System.Convert.ToInt32(Request.Form["drpDestinationStation"]), true);
                ViewBag.Via1StationsList = pathService.MakeEmptyItemForDropdowns(0);
                ViewBag.Via2StationsList = pathService.MakeEmptyItemForDropdowns(0);

                System.Text.StringBuilder errorMessage = new System.Text.StringBuilder();

                string originalStationName = pathService.GetNameStationByID(System.Convert.ToInt32(Request.Form["drpOriginalStation"]));
                string destinationStationName = pathService.GetNameStationByID(System.Convert.ToInt32(Request.Form["drpDestinationStation"]));
                string via1StationName = null;
                try
                {
                    via1StationName = pathService.GetNameStationByID(System.Convert.ToInt32(Request.Form["drpVia1Station"]));
                }
                finally
                {
                    via1StationName = null;
                }
                string via2StationName = pathService.GetNameStationByID(System.Convert.ToInt32(Request.Form["drpVia2Station"]));

                if (!string.IsNullOrEmpty(originalStationName) && !string.IsNullOrEmpty(destinationStationName) && originalStationName != destinationStationName)
                {
                    List<SelectListItem> listItemsVia1 = new List<SelectListItem>();
                    listItemsVia1.Add(pathService.MakeEmptyItemForDropdowns(0));
                    List<SelectListItem> listItemsVia2 = new List<SelectListItem>();
                    listItemsVia2.Add(pathService.MakeEmptyItemForDropdowns(0));

                    //use GetPathsByStationName method in pathService Class to search paths
                    List<NewPercorsiModel> PathList = pathService.GetPathsByStationsName(originalStationName, destinationStationName, via1StationName, via2StationName);
                    if (PathList.Count > 0)
                    {
                        //order paths with distance 
                        var pathListSortedByDistance = PathList.OrderBy(p => p.Distanza);

                        ViewBag.PathList = pathListSortedByDistance;
                        foreach (var obj in pathListSortedByDistance)
                        {
                            if (obj.Via1Name != null && obj.Via1Name != string.Empty)
                            {
                                if (listItemsVia1.Find(x => x.Value == obj.IdVia1.ToString()) == null)
                                {
                                    listItemsVia1.Add(new SelectListItem
                                    {
                                        Text = obj.Via1Name,
                                        Value = obj.IdVia1.ToString(),
                                        Selected = (obj.IdVia1 == Request.Form["drpVia1Station"] ? true : false)
                                    });
                                }
                            }
                            if (obj.Via2Name != null && obj.Via2Name != string.Empty)
                            {
                                if (listItemsVia2.Find(x => x.Value == obj.IdVia2.ToString()) == null)
                                {
                                    listItemsVia2.Add(new SelectListItem
                                    {
                                        Text = obj.Via2Name,
                                        Value = obj.IdVia2.ToString(),
                                        Selected = (obj.IdVia2 == Request.Form["drpVia2Station"] ? true : false)
                                    });
                                }
                            }
                        }
                    }
                    ViewBag.Via1StationsList = listItemsVia1;
                    ViewBag.Via2StationsList = listItemsVia2;


                    return View("Index");
                }
                else
                {
                    if (originalStationName == null || string.IsNullOrEmpty(originalStationName))
                        ModelState.AddModelError("OriginalStation", "Please Choose Original Station ");
                    if (destinationStationName == null || string.IsNullOrEmpty(destinationStationName))
                        ModelState.AddModelError("destinationStation", "Please Choose Destination Station ");
                }
                if (ModelState.ErrorCount == 0 && originalStationName == destinationStationName)
                    ModelState.AddModelError("sameStations", "Original Station And Destination Station could not be Same ");
            }
            return View("Index");
        }
    }
}
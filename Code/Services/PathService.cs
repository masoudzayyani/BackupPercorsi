using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using PathApp.Data;
using PathApp.Models;

namespace PathApp.Services
{
    public class PathService
    {
        private readonly PercorsiContext _context;
        public PathService(PercorsiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Paths with Stations Name(Original and Destination are mandatory
        /// </summary>
        /// <param name="originalStationName">Original Station Name</param>
        /// <param name="destinationStationName">Destination Station Name</param>
        /// <param name="via1StationName">Via1 Station Name</param>
        /// <param name="via2StationName">Via2 Station Name</param>
        /// <returns>List of Paths With NewPercorsi Models</returns>
        public List<NewPercorsiModel> GetPathsByStationsName(string originalStationName, string destinationStationName, string? via1StationName, string? via2StationName)
        {
            int idOriginalStation = GetIdStationByName(originalStationName);
            int idDestinationStation = GetIdStationByName(destinationStationName);
            int idVia1 = GetIdStationByName(via1StationName);
            int idVia2 = GetIdStationByName(via2StationName);

            IQueryable<PercorsiModel> linqPercorsiModel;
            List<NewPercorsiModel> newPercorsilist = new List<NewPercorsiModel>();

            if (idVia1 == 0 && idVia2 == 0)
            {
                linqPercorsiModel = from objpercorsi in _context.PercorsiModel
                                    where objpercorsi.IdStazioneOrigine == idOriginalStation &&
                                           objpercorsi.IdStazioneDestinazione == idDestinationStation
                                    orderby objpercorsi.IdPercorso
                                    select objpercorsi;
                newPercorsilist = MakeNewPercorsiListFromPercorsiList(linqPercorsiModel.ToList(), originalStationName, destinationStationName);
            }
            else if (idVia1 != 0 && idVia2 != 0)
            {
                linqPercorsiModel = from objpercorsi in _context.PercorsiModel
                                    where objpercorsi.IdStazioneOrigine == idOriginalStation &&
                                          objpercorsi.IdStazioneDestinazione == idDestinationStation &&
                                          objpercorsi.IdVia1 == idVia1 &&
                                          objpercorsi.IdVia2 == idVia2
                                    orderby objpercorsi.IdPercorso
                                    select objpercorsi;

                newPercorsilist = MakeNewPercorsiListFromPercorsiList(linqPercorsiModel.ToList(), originalStationName, destinationStationName);
            }
            else if (idVia1 == 0)
            {
                linqPercorsiModel = from objpercorsi in _context.PercorsiModel
                                    where objpercorsi.IdStazioneOrigine == idOriginalStation &&
                                          objpercorsi.IdStazioneDestinazione == idDestinationStation &&
                                          objpercorsi.IdVia2 == idVia2
                                    orderby objpercorsi.IdPercorso
                                    select objpercorsi;
                newPercorsilist = MakeNewPercorsiListFromPercorsiList(linqPercorsiModel.ToList(), originalStationName, destinationStationName);
            }
            else if (idVia2 == 0)
            {
                linqPercorsiModel = from objpercorsi in _context.PercorsiModel
                                    where objpercorsi.IdStazioneOrigine == idOriginalStation &&
                                          objpercorsi.IdStazioneDestinazione == idDestinationStation &&
                                          objpercorsi.IdVia1 == idVia1
                                    orderby objpercorsi.IdPercorso
                                    select objpercorsi;
                newPercorsilist = MakeNewPercorsiListFromPercorsiList(linqPercorsiModel.ToList(), originalStationName, destinationStationName);
            }
            return newPercorsilist;
        }

        /// <summary>
        /// Get all paths and return them with NewPercorsiModel with stations Name
        /// </summary>
        /// <returns>List of NewPercorsiModels</returns>
        public List<NewPercorsiModel> GetAllPaths()
        {
            IQueryable<PercorsiModel> linqPercorsiModel = from objpercorsi in _context.PercorsiModel
                                                          orderby objpercorsi.IdPercorso
                                                          select objpercorsi;
            return MakeNewPercorsiListFromPercorsiList(linqPercorsiModel.ToList(), string.Empty, string.Empty);
        }

        /// <summary>
        /// with this method we will add via1name and via2name to percorsi model and make new object(NewPercorsiModel)
        /// two parameters of Original and Destination name are not mandatory
        /// </summary>
        /// <param name="objpercorsiList">List of percorsi model for changing it to NewPercorsiModel</param>
        /// <param name="originalStationName">original station name</param>
        /// <param name="destinationStationName">destination station name</param>
        /// <returns>list of newpercorsi model</returns>
        private List<NewPercorsiModel> MakeNewPercorsiListFromPercorsiList(List<PercorsiModel> objpercorsiList, string? originalStationName, string? destinationStationName)
        {
            List<NewPercorsiModel> objnewpercorsiList = new List<NewPercorsiModel>();
            foreach (PercorsiModel objPercorsi in objpercorsiList)
            {
                if (string.IsNullOrEmpty(originalStationName))
                    originalStationName = GetNameStationByID(System.Convert.ToInt32(objPercorsi.IdStazioneOrigine));
                if (string.IsNullOrEmpty(destinationStationName))
                    destinationStationName = GetNameStationByID(System.Convert.ToInt32(objPercorsi.IdStazioneDestinazione));
                NewPercorsiModel objnewpercorsi = new NewPercorsiModel
                {
                    Distanza = objPercorsi.Distanza,
                    IdPercorso = objPercorsi.IdPercorso,
                    IdSottorete = objPercorsi.IdSottorete,
                    IdStazioneDestinazione = objPercorsi.IdStazioneDestinazione,
                    IdStazioneOrigine = objPercorsi.IdStazioneOrigine,
                    IdVia1 = objPercorsi.IdVia1,
                    IdVia2 = objPercorsi.IdVia2,
                    Versione = objPercorsi.Versione,
                    StazioneDestinazioneName = destinationStationName,
                    StazioneOrigineName = originalStationName,
                    Via1Name = GetNameStationByID(System.Convert.ToInt32(objPercorsi.IdVia1)),
                    Via2Name = GetNameStationByID(System.Convert.ToInt32(objPercorsi.IdVia2))
                };
                objnewpercorsiList.Add(objnewpercorsi);
            }
            return objnewpercorsiList;
        }

        /// <summary>
        /// return station Id by Name of Station
        /// </summary>
        /// <param name="stationName">station Name</param>
        /// <returns>station Id</returns>
        public int GetIdStationByName(string stationName)
        {
            var linq = from obj in _context.StazioneModel
                       where obj.NomeStazione == stationName
                       select obj.IDStazione;
            if (linq.Count() != 0)
                return linq.First();
            return 0;
        }

        /// <summary>
        /// return station name by station Id
        /// </summary>
        /// <param name="stationID">station Id</param>
        /// <returns>station name</returns>
        public string GetNameStationByID(int stationID)
        {
            var linq = from obj in _context.StazioneModel
                       where obj.IDStazione == stationID
                       select obj.NomeStazione;
            if (linq.Count() != 0)
                return linq.First().ToString();
            return string.Empty;
        }

        /// <summary>
        /// return sorted list of stations with Name of stations
        /// </summary>
        /// <returns>list of stations</returns>
        public List<StazioneModel> ReturnSortedListOfStations()
        {
            return (from objStation in _context.StazioneModel
                    orderby objStation.NomeStazione
                    select objStation).ToList();
        }

        /// <summary>
        /// Return selectListItem of station for fill dropdowns
        /// </summary>
        /// <param name="selectedValue">integer value for choose selected value of dropdown</param>
        /// <param name="hasEmptyItem">bool to choose dropdown has Empty Item or not</param>
        /// <returns>Return selectListItem of station</returns>
        public List<SelectListItem> ReturnListStationsForDropDowns(int selectedValue, bool hasEmptyItem)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems = ReturnSortedListOfStations().Select(
            s => new SelectListItem
            {
                Text = s.NomeStazione,
                Value = s.IDStazione.ToString(),
                Selected = (s.IDStazione == selectedValue ? true : false)
            }).ToList();
            if (hasEmptyItem)
            {
                listItems.Insert(0, MakeEmptyItemForDropdowns(selectedValue));
            }
            return listItems;
        }

        /// <summary>
        /// return seletListItem with empty value for dropdowns
        /// </summary>
        /// <param name="selectedValue">integer value for choose selected value of dropdown</param>
        /// <returns>Empty selectListItem</returns>
        public SelectListItem MakeEmptyItemForDropdowns(int selectedValue)
        {
            SelectListItem listItemsEmpty = new SelectListItem
            {
                Text = "-- Select Station --",
                Value = System.Convert.ToString(0),
                Selected = (0 == selectedValue ? true : false)
            };
            return listItemsEmpty;
        }
    }

}

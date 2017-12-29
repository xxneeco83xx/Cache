using CacheBusiness.Interfaces;
using DataTables.Mvc;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Cache.Controllers
{
    public class HomeController : Controller
    {
        #region Properties

        private readonly IMockGeneratorBusiness _mockGeneratorBusiness;

        #endregion

        #region Constructor

        public HomeController(IMockGeneratorBusiness mockGeneratorBusiness)
        {
            _mockGeneratorBusiness = mockGeneratorBusiness;
        }

        #endregion

        #region Web Methods

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get(int sEcho, int iDisplayStart, int iDisplayLength, string sSearch, string sSortDir_0)
        {
            var query = _mockGeneratorBusiness.GetMockData(10000);

            var totalCount = query.Count();

            #region Filtering 

            // Apply filters for searching 
            if (!string.IsNullOrEmpty(sSearch))
            {
                var value = sSearch.Trim();
                query = query.Where(p => p.EventName.Contains(value) ||
                                         p.StartDate.Contains(value) ||
                                         p.EndDate.Contains(value));
            }

            var filteredCount = query.Count();

            #endregion Filtering 

            #region Sorting 

            // Sorting 
            var orderedResults = sSortDir_0 == "asc"
                              ? query.OrderBy(o => o.EndDate)
                              : query.OrderByDescending(o => o.EndDate);
            var itemsToSkip = iDisplayStart == 0
                              ? 0
                              : iDisplayStart + 1;

            #endregion Sorting 

            // Paging 
            query = query.Skip(iDisplayStart).Take(iDisplayLength);

            var data = query.Select(mevent => new
            {
                EventName = mevent.EventName,
                StartDate = mevent.StartDate,
                EndDate = mevent.EndDate,
            }).ToList();

            return Json(new
            {
                sEcho = sEcho.ToString(),
                iTotalRecords = totalCount.ToString(),
                iTotalDisplayRecords = filteredCount.ToString(),
                aaData = data
            }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
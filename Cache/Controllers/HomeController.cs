using CacheBusiness.Interfaces;
using DataTables.Mvc;
using DTO;
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
        [OutputCache(Duration = 10, VaryByParam = "iDisplayStart; iDisplayLength; sSearch", Location = OutputCacheLocation.Client)]
        public ActionResult Get([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var query = _mockGeneratorBusiness.GetMockData(10000);

            var totalCount = query.Count();

            #region Filtering 

            // Apply filters for searching 
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim();
                query = query.Where(p => p.EventName.Contains(value) ||
                                         p.StartDate.Contains(value) ||
                                         p.EndDate.Contains(value));
            }

            var filteredCount = query.Count();

            #endregion Filtering 

            #region Sorting 

            // Sorting 
            var sortedColumns = requestModel.Columns.GetSortedColumns();
            var orderByString = string.Empty;

            foreach (var column in sortedColumns)
            {
                orderByString += orderByString != string.Empty ? "," : "";
                orderByString += (column.Data) + (column.SortDirection == Column.OrderDirection.Ascendant ? " asc" : " desc");
            }

            query = query.OrderBy(m=>orderByString == string.Empty ? "BarCode asc" : orderByString);

            #endregion Sorting 

            // Paging 
            query = query.Skip(requestModel.Start).Take(requestModel.Length);

            var data = query.Select(mevent => new
            {
                EventName = mevent.EventName,
                StartDate = mevent.StartDate,
                EndDate = mevent.EndDate,
            }).ToList();

            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
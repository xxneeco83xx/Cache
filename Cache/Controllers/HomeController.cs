using CacheBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var objects = _mockGeneratorBusiness.GetMockData(200);

            return View();
        }

        #endregion
    }
}
using CacheBusiness.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CacheBusiness.Business
{
    public class MockGeneratorBusiness : IMockGeneratorBusiness
    {
        #region Properties

        private JObject _data { get; set; }

        #endregion

        #region Constructor

        public MockGeneratorBusiness()
        {
            dynamic dataObj = new JObject();

            dataObj.eventName = "Internet event";
            dataObj.startTime = DateTime.Now.ToString("yyyy/MM/dd");
            dataObj.endTime = DateTime.Now.AddHours(2).ToString("yyyy/MM/dd hh:MM:ss");

            _data = dataObj;
        }

        #endregion

        #region Methods

        public IEnumerable<JObject> GetMockData(int objectsCount = 100)
        {
            return (Enumerable.Repeat(_data, objectsCount));
        }

        #endregion
    }
}

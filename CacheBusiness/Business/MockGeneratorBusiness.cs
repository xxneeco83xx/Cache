using CacheBusiness.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CacheBusiness.Business
{
    public class MockGeneratorBusiness : IMockGeneratorBusiness
    {
        #region Properties

        private EventDTO _data { get; set; }

        #endregion

        #region Constructor

        public MockGeneratorBusiness()
        {
            var eventDTO = new EventDTO
            {
                EventName = "Internet event",
                StartDate = DateTime.Now.ToString("yyyy/MM/dd"),
                EndDate = DateTime.Now.AddHours(2).ToString("yyyy/MM/dd hh:MM:ss")
            };

            _data = eventDTO;
        }

        #endregion

        #region Methods

        public IQueryable<EventDTO> GetMockData(int objectsCount = 10000)
        {
            return (Enumerable.Repeat(_data, objectsCount).AsQueryable());
        }

        #endregion
    }
}

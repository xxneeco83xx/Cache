using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CacheBusiness.Interfaces
{
    public interface IMockGeneratorBusiness
    {
        #region Methods

        IEnumerable<JObject> GetMockData(int objectsCount = 100);

        #endregion
    }
}

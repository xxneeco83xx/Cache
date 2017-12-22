using DTO;
using System.Linq;

namespace CacheBusiness.Interfaces
{
    public interface IMockGeneratorBusiness
    {
        #region Methods

        IQueryable<EventDTO> GetMockData(int objectsCount = 100);

        #endregion
    }
}

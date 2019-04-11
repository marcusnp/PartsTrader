using System.Collections.Generic;
using System.Linq;
using PartsTrader.ClientTools.Api.Entities;
using PartsTrader.ClientTools.Api.ValueObjects;

namespace PartsTrader.ClientTools.Integration
{
    public class PartsTraderPartsService : IPartsTraderPartsService
    {
        /// <summary>
        /// Bring the compatibleParts using the partNumber
        /// </summary>
        /// <param name="partNumber"></param>
        /// <returns></returns>
        public IEnumerable<PartSummary> FindAllCompatibleParts(string partNumber)
        {
            List<PartSummary> dataContext = new List<PartSummary>();
            dataContext = Context();
            return from parts in dataContext
                   where parts.PartNumber == partNumber
                   select parts;
        }


        //Fake DataBase
        private List<PartSummary> Context()
        {
            var list = new List<PartSummary>();
            list.Add(new PartSummary
            {
                Description = "Description 1",
                PartNumber = PartNumber.For("1234-1234abcd")
            });
            list.Add(new PartSummary
            {
                Description = "Description 2",
                PartNumber = PartNumber.For("1235-abcd")
            });
            list.Add(new PartSummary
            {
                Description = "Description 3",
                PartNumber = PartNumber.For("1236-efgh")
            });
            list.Add(new PartSummary
                    {
                        Description = "Description 4",
                        PartNumber = PartNumber.For("1237-1233")
                    }
                    );
            return list;
        }
    }
}

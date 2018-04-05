using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Bikes
{
    public interface IServiceBikesEvents
    {
        [OperationContract(IsOneWay = true)]
        void GetedBikesed(string city, string station_name);
    }
}

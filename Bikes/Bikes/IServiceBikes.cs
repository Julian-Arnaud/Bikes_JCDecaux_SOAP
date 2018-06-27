using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bikes
{
    [ServiceContract(CallbackContract = typeof(IServiceBikesEvents))]
    public interface IServiceBikes
    {
        [OperationContract]
        String GetBikesTown(String city, String station_number);

        [OperationContract]
        List<string> GetCities();

        [OperationContract]
        List<string> GetStationsCity(String city);

        [OperationContract]
        void SubscribeGetedBikesedEvent(String city, String station);
    }


}

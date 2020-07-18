using System;
using System.Runtime.Serialization;

namespace SmartParkingApp
{
    [DataContract]
    class Tariff
    {
        [DataMember] public int Minutes { get; set; }
        [DataMember] public decimal Rate { get; set; }
    }
}

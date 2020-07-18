using System;
using System.Runtime.Serialization;

namespace SmartParkingApp
{
    [DataContract]
    class User
    {
        public User(string name, string carPlateNumber, string phone) {
            Name = name;
            CarPlateNumber = carPlateNumber;
            Phone = phone;
        }
        [DataMember] public string Name { get; set; }
        [DataMember] public string CarPlateNumber { get; set; }
        [DataMember] public string Phone { get; set; }
    }
}

using System;
using System.Runtime.Serialization;

namespace SmartParkingApp
{
    [DataContract]
    class ParkingSession
    {
        public ParkingSession(string carPlateNumber, DateTime entryDt, int ticketNumber) {
            CarPlateNumber = carPlateNumber;
            EntryDt = entryDt;
            TicketNumber = ticketNumber;
        }
        // Date and time of arriving at the parking
        [DataMember] public DateTime EntryDt { get; set; }
        // Date and time of payment for the parking
        [DataMember] public DateTime? PaymentDt { get; set; }
        // Date and time of exiting the parking
        [DataMember] public DateTime? ExitDt { get; set; }
        // Total cost of parking
        [DataMember] public decimal? TotalPayment { get; set; }
        // Plate number of the visitor's car
        [DataMember] public string CarPlateNumber { get; set; }
        // Issued printed ticket
        [DataMember] public int TicketNumber { get; set; }
    }
}

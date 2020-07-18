using System;
using System.Collections.Generic;

namespace SmartParkingApp
{
    class ParkingManager
    {
        List<Tariff> tariffs;
        List<ParkingSession> activeSessions;
        List<ParkingSession> completedSessions;
        List<User> users;
        int ParkingCapacity { get; } = DataBase.AppData.parkingCapacity;
        int FreeLeavePeriod { get; } = 15;

        public ParkingManager()
        {
            tariffs = DataBase.AppData.tariffs;
            activeSessions = DataBase.AppData.activeSessions;
            completedSessions = DataBase.AppData.completedSessions;
            users = DataBase.AppData.users;
            bool exit = false;
            Console.WriteLine(
            "Enter command: \n" +
            "Entry - car enters the parking \n" +
            "Payment - payment is performed \n" +
            "Exit - Car exits the parking \n" +
            "Close - close the program");
            do
            {
                switch (Console.ReadLine())
                {
                    case "Entry":
                        {
                            Console.WriteLine("Enter car plate number");
                            EnterParking(Console.ReadLine());
                            break;
                        }
                    case "Payment":
                        {
                            Console.WriteLine("Enter ticket number");
                            PayForParking(Convert.ToInt32(Console.ReadLine()));
                            break;
                        }
                    case "Exit":
                        {
                            Tryleave();
                            break;
                        }
                    case "Close":
                        {
                            exit = true;
                            break;
                        }
                }
            }
            while (exit != true);
        }

        public ParkingSession EnterParking(string carPlateNumber)
        {
            ParkingSession session;
            int ticketNumber;
            if (activeSessions.FindIndex(item => item.CarPlateNumber == carPlateNumber) != -1)
            {
                Console.WriteLine("A car with this number already exists");
                return null;
            }
            if (activeSessions.Count == ParkingCapacity)
            {
                Console.WriteLine("No free places");
                return null;
            }
            if (activeSessions.Count != 0)
            {
                ticketNumber = activeSessions[activeSessions.Count - 1].TicketNumber + 1;
            }
            else
            {
                ticketNumber = 0;
            }
            session = new ParkingSession(carPlateNumber, getCurrentTime(), ticketNumber);
            activeSessions.Add(session);
            DataBase.ChangeActiveSessions(activeSessions);
            Console.WriteLine(
                "Car enters the parking at {0}\n" +
                "ticket number: {1}", session.EntryDt, session.TicketNumber);
            return session;
        }

        public void GetRemainingCost(int ticketNumber)
        {
            ParkingSession session = activeSessions.Find(item => item.TicketNumber == ticketNumber);
            DateTime paymentDt = getCurrentTime();
            session.TotalPayment += GetCostFromTariff(paymentDt - session.PaymentDt);
            Console.WriteLine("Additional pay " + session.TotalPayment);
            DataBase.ChangeActiveSessions(activeSessions);
        }

        public void PayForParking(int ticketNumber)
        {
            ParkingSession session = activeSessions.Find(item => item.TicketNumber == ticketNumber);
            if (session != null)
            {
                session.PaymentDt = getCurrentTime();
                session.TotalPayment = GetCostFromTariff(session.PaymentDt - session.EntryDt);
                Console.WriteLine("Visitor pay " + session.TotalPayment);
                DataBase.ChangeActiveSessions(activeSessions);
            }
        }

        private void Tryleave()
        {
            Console.WriteLine("Whith ticket or by car plate number [T]/[N]?");
            bool correctAnswer = false;
            while (correctAnswer == false) 
            {
                string key = Console.ReadLine();
                if (key == "T" || key == "t") {
                    correctAnswer = true;
                    Console.WriteLine("Enter ticket number");
                    TryLeaveParkingWithTicket(Convert.ToInt32(Console.ReadLine()));
                }
                if (key == "N" || key == "n")
                {
                    correctAnswer = true;
                    Console.WriteLine("Enter car plate number");
                    TryLeaveParkingByCarPlateNumber(Console.ReadLine());
                }
            }
        }

        public bool TryLeaveParkingWithTicket(int ticketNumber)
        {
            ParkingSession session = activeSessions.Find(item => item.TicketNumber == ticketNumber);
            if (session.PaymentDt == null) {
                Console.WriteLine("Pay for parking!");
                return false;
            }
            DateTime exitDt = getCurrentTime();
            if (session.EntryDt.Second - exitDt.Second < FreeLeavePeriod * 60)
            {
                session.ExitDt = exitDt;
                Console.WriteLine("Car exit the parking at " + session.ExitDt);
                completedSessions.Add(session);
                activeSessions.Remove(session);
                DataBase.ChangeActiveSessions(activeSessions);
                DataBase.ChangeCompletedSessions(completedSessions);
            }
            else 
            {
                Console.WriteLine("Need additional pay");
                GetRemainingCost(ticketNumber);
                session.ExitDt = getCurrentTime();
                Console.WriteLine("Car exit the parking at " + session.ExitDt);
                completedSessions.Add(session);
                activeSessions.Remove(session);
                DataBase.ChangeActiveSessions(activeSessions);
                DataBase.ChangeCompletedSessions(completedSessions);
            }
            return true;
        }

        public bool TryLeaveParkingByCarPlateNumber(string carPlateNumber)
        {
            ParkingSession session = activeSessions.Find(item => item.CarPlateNumber == carPlateNumber);
            DateTime exitDt = getCurrentTime();
            if ((exitDt - session.EntryDt).TotalSeconds < FreeLeavePeriod * 60)
            {
                session.ExitDt = exitDt;
                Console.WriteLine("Car exit the parking at " + session.ExitDt);
                DataBase.ChangeActiveSessions(activeSessions);
                return true;
            }
            if (session.PaymentDt != null)
            {
                if (session.PaymentDt.Value.Second - exitDt.Second < FreeLeavePeriod * 60)
                {
                    session.ExitDt = exitDt;
                    Console.WriteLine("Car exit the parking at " + session.ExitDt);
                    DataBase.ChangeActiveSessions(activeSessions);
                }
                else 
                {
                    Console.WriteLine("Need additional pay");
                    GetRemainingCost(session.TicketNumber);
                    session.ExitDt = getCurrentTime();
                    Console.WriteLine("Car exit the parking at " + session.ExitDt);
                    DataBase.ChangeActiveSessions(activeSessions);
                }
            }
            else
            {
                User user = users.Find(item => item.CarPlateNumber == carPlateNumber);
                if (user != null)
                {
                    TimeSpan? detTime = exitDt - session.EntryDt;
                    detTime = detTime.Value.Subtract(new TimeSpan(0, FreeLeavePeriod, 0));
                    session.TotalPayment = GetCostFromTariff(detTime);
                    session.ExitDt = exitDt;
                    Console.WriteLine("Car exit the parking at " + session.ExitDt);
                    completedSessions.Add(session);
                    activeSessions.Remove(session);
                    DataBase.ChangeActiveSessions(activeSessions);
                    DataBase.ChangeCompletedSessions(completedSessions);
                }
                else
                {
                    Console.WriteLine("Pay for parking!");
                    return false;
                }
            }
            return true;
        }

        private DateTime getCurrentTime()
        {
            Console.WriteLine("Enter current time");
            return Convert.ToDateTime(Console.ReadLine());
        }

        private decimal GetCostFromTariff(TimeSpan? detTime) 
        {
            Tariff tariff = tariffs.Find(item => item.Minutes * 60 >= detTime.Value.TotalSeconds);
            if (tariff != null)
            {
                return tariff.Rate;
            }
            else
            {
                return 0;
            }
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace SmartParkingApp
{
    class DataBase
    {
        public static AppDataSerialize AppData {
            get {
                if (appData == null) {
                    appData = GetAppData();
                }
                return appData;
            }
            set { } 
        }
        static AppDataSerialize appData;

        static string FilePath {
            get {
                if (filePath == null) {
                    filePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName + @"\appData.json";
                }
                return filePath;
            }
        }
        static string filePath;

        private static AppDataSerialize GetAppData()
        {
            AppDataSerialize appData;
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(AppDataSerialize)); //создаём экземпляр десериализатора
            if (File.Exists(FilePath) != true) //если файла с данными нет, то создаём его
            {
                appData = new AppDataSerialize();
                using (FileStream fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fileStream, appData); //задаём начальные значения
                }

                return appData;
            }
            using (FileStream fileStream = new FileStream(FilePath, FileMode.Open))
            {
                return (AppDataSerialize)jsonFormatter.ReadObject(fileStream); //десериализуем файл с данными
            }
        }

        public static void ChangeActiveSessions(List<ParkingSession> activeSessions) {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(AppDataSerialize));
            appData.activeSessions = activeSessions;
            using (FileStream fileStream = new FileStream(FilePath, FileMode.Truncate))
            {
                jsonFormatter.WriteObject(fileStream, appData);
            }
        }

        public static void ChangeCompletedSessions(List<ParkingSession> completedSessions)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(AppDataSerialize));
            appData.completedSessions = completedSessions;
            using (FileStream fileStream = new FileStream(FilePath, FileMode.Truncate))
            {
                jsonFormatter.WriteObject(fileStream, appData);
            }
        }
    }

    [DataContract]
    class AppDataSerialize
    {
        public AppDataSerialize() {
            parkingCapacity = 0;
            tariffs = new List<Tariff>();
            activeSessions = new List<ParkingSession>();
            completedSessions = new List<ParkingSession>();
            users = new List<User>();
        }
        [DataMember] public int parkingCapacity { get; set; }
        [DataMember] public List<Tariff> tariffs { get; set; }
        [DataMember] public List<ParkingSession> activeSessions { get; set; }
        [DataMember] public List<ParkingSession> completedSessions { get; set; }
        [DataMember] public List<User> users { get; set; }
    }
}

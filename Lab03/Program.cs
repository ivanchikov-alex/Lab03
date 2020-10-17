using System;

namespace Lab03
{
    public partial class Airline
    {
        public enum WeekDays { monday = 1, tuestay, wednesday, thirsday, friday, saturday, sunday }
        int flightNum { get; set; }
        WeekDays day { get; set; }
        string destination { get; set; }
        const string departPoint = "Гуанчжоу";
        string departTime { get; set; }
        string planeType
        {
            set
            {
                if (value.ToLower() == "почтовый" || value.ToLower() == "пассажирский")
                    planeType = value;
                else Console.WriteLine("Данного типа нет в наличии");
            }
            get
            {
                return planeType;
            }
        }
        static int listSize { get; set; }
    }
    public partial class Airline
    { 
        static Airline()
        {
            listSize = 0;
        }
        private Airline(){ }

        public Airline(WeekDays day)
        {
            listSize++;
            flightNum++;
            this.day = day;
            destination = "Минск";
            departTime = "0:00";
            planeType = "Почтовый";
        }

        public Airline(int flightNum, WeekDays day, string destination, string departTime, string planeType = "Пассажирский")
        {
            listSize++;
            this.flightNum = flightNum;
            this.day = day;
            this.destination = destination;
            this.departTime = departTime;
            this.planeType = planeType;
        }

        public static void ClassInfo()
        {
            Console.WriteLine($"{listSize}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Airline flight1 = new Airline(Airline.WeekDays.sunday);
            Airline.ClassInfo();
        }
    }
}

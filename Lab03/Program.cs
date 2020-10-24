using System;

namespace Lab03
{
    public partial class Airline
    {
        public enum WeekDays { monday = 1, tuestay, wednesday, thirsday, friday, saturday, sunday }
        int flightNum;
        public WeekDays day;
        public string destination;
        const string departPoint = "Гуанчжоу";
        string departTime;
        string planeType;
        static int listSize;
        public readonly int id;
        public string DepartTime { get; set; }
        public string ListSize { get; set; }
        public string PlaneType
        {
            set
            {
                if (value.ToLower() == "почтовый" || value.ToLower() == "пассажирский")
                    PlaneType = value;
                else PlaneType = null;
            }
            get
            {
                return PlaneType;
            }
        }
    }
    public partial class Airline
    {
        static Airline()
        {
            listSize = 0;
        }
        private Airline()
        {
            listSize++;
            flightNum++;
            destination = "Минск";
            departTime = "0:00";
            planeType = "Почтовый";
            id = this.GetHashCode();
        }

        public Airline(WeekDays day)
        {
            listSize++;
            flightNum++;
            destination = "Минск";
            departTime = "0:00";
            planeType = "Почтовый";
            this.day = day;
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

        public void ChangeDestination(out string oldDest, ref string newDest)
        {
            oldDest = newDest;
        }
        public bool Equals(Airline flight)
        {
            if (this.GetHashCode() == flight.GetHashCode())
                return true;
            else return false;
        }

        new public string ToString()
        {
            return this.day + " " + destination + " " + departTime + " " + flightNum;
        }

        new public int GetHashCode()
        {
            return this.flightNum.GetHashCode() + destination.GetHashCode();
        }

        public int GetID()
        {
            Airline flight = new Airline();
            if (this.flightNum == 0 && destination == null)
                return flight.id;
            else return this.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var anonType = new { destination = "Канто", departTime = "10:00" };
            Airline flight1 = new Airline(Airline.WeekDays.sunday);
            Airline flight2 = new Airline(2, Airline.WeekDays.friday, "Минск", "20:10");
            Console.WriteLine(flight2.ToString());
            Console.WriteLine(flight1.GetID());
            Airline.ClassInfo();
            Console.WriteLine(flight1.GetHashCode());
            Console.WriteLine("Новый пункт назначения");
            string newdest = Console.ReadLine();
            flight1.ChangeDestination(out flight1.destination, ref newdest);
            Console.WriteLine(flight1.Equals(flight2));
            Console.WriteLine(flight1.GetType());

            Airline[] flights = new Airline[5];
            for (int i = 0; i < 5; i++)
                flights[i] = new Airline((Airline.WeekDays)i+1);

            Console.WriteLine();

            for (int i = 0; i < 5; i++)
                if (flights[i].destination == "Минск")
                    Console.WriteLine(flights[i].ToString());

            Console.WriteLine();

            for (int i = 0; i < 5; i++)
                if (flights[i].day == (Airline.WeekDays)3)
                    Console.WriteLine($"{flights[i].ToString()}");

        }
    }
}

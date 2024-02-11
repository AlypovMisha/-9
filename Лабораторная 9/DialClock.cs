using System;
using System.Globalization;

namespace Лабораторная_9
{
    public class DialClock
    {
        private int hours;
        private int minutes;
        private static int objectCount = 0;

        //Конструктор без параметров
        public DialClock()
        {
            objectCount++;
            hours = 0;
            minutes = 0;
        }

        // Конструктор с параметрами
        public DialClock(int hours, int minutes)
        {
            objectCount++;
            if(minutes >= 60)
            {
                this.minutes = minutes % 60;
                this.hours = hours % 24 + (int)minutes/60 ;
            }
            else
            {
                this.minutes = minutes % 60;
                this.hours = hours % 24;
            }
            hours = this.hours % 24;

        }
        public DialClock(string hour, string minute)
        {
            objectCount++;
            int hours = ParseToDC(hour, "1");
            int minutes = ParseToDC(minute, "2");
            if (minutes >= 60)
            {
                this.minutes = minutes % 60;
                this.hours = hours % 24 + (int)minutes / 60;
            }
            else
            {
                this.minutes = minutes % 60;
                this.hours = hours % 24;
            }
            hours = this.hours % 24;

        }

        // Конструктор копирования
        public DialClock(DialClock clock)
        {
            objectCount++;
            this.hours = clock.hours;
            this.minutes = clock.minutes;
        }

        // Свойство для доступа к часам
        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        // Свойство для доступа к минутам
        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }

        // Метод для показа времени
        public override string ToString()
        {
            return $"{hours % 24 + minutes / 60}:{minutes % 60}";
        }

        // Метод для вычисления угла между стрелками
        public double GetLittleAngle()
        {
            double hourAngle = (hours % 12 * 30) + (minutes / 2);
            double minuteAngle = minutes * 6;
            double angle = Math.Abs(hourAngle - minuteAngle);

            if (angle > 180)
            {
                angle = 360 - angle;
            }

            return Math.Round(angle, 4);
        }

        //public double GetBigAngle()
        //{
        //    double hourAngle = (hours % 12 * 30) + (minutes / 2);
        //    double minuteAngle = minutes * 6;
        //    double angle = Math.Abs(hourAngle - minuteAngle);

        //    if (angle < 180)
        //    {
        //        angle = 360 - angle;
        //    }

        //    return Math.Round(angle, 4);
        //}

        //
        public int ParseToDC(string str, string numberFunction)
        {
            switch (numberFunction)
            {
                case "1":
                    int hours;
                    bool isDigit1 = int.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out hours);
                    while (!isDigit1 || (hours < 0) || (hours > 1000))
                    {
                        Console.Write("Вы неправильно ввели кол-во часов, пожалуйста, повторите ввод: ");
                        str = Console.ReadLine();
                        isDigit1 = int.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out hours);
                    }
                    return hours;
                case "2":
                    int minutes;
                    bool isDigit2 = int.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out minutes);
                    while (!isDigit2 || (minutes < 0) || (minutes > 1000))
                    {
                        Console.Write("Вы неправильно ввели кол-во минут, пожалуйста, повторите ввод: ");
                        str = Console.ReadLine();
                        isDigit2 = int.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out minutes);
                    }
                    return minutes;                    
            }
            return 1;
        }

        public bool IsEquals(DialClock dialClock1, DialClock dialClock2) 
        {
            if (dialClock1 == null && dialClock2 == null) 
                return false;
            if(dialClock1.hours == dialClock2.hours && dialClock1.minutes == dialClock2.minutes)
                return true;
            else
                return false;
        }

        //Добавление минуты к времени
        public static DialClock operator ++(DialClock clock)
        {
            clock.minutes++;
            if (clock.minutes == 60)
            {
                clock.minutes = 0;
                clock.hours++;
                if (clock.hours == 24)                
                    clock.hours = 0;
                
            }
            return clock;
        }

        //Убавление минуты от времени           
        public static DialClock operator --(DialClock clock)
        {
            clock.minutes--;
            if (clock.minutes == -1)
            {
                clock.minutes = 59;
                clock.hours--;
                if (clock.hours == -1)                
                    clock.hours = 23;
                
            }
            return clock;
        }

        //Операции приведения типа
        public static explicit operator bool(DialClock clock)
        {
            double angle = clock.GetLittleAngle();
            return angle % 2.5 == 0;
        }

        public static implicit operator int(DialClock clock)
        {
            int count = clock.minutes;
            count += clock.hours * 60;
            return count;
        }


        //Добавление минут с лева и справа
        public static DialClock operator +(DialClock clock, int minutesToAdd)
        {
            clock.minutes += minutesToAdd;
            if (clock.minutes >= 60)
            {
                int additionalHours = clock.minutes / 60;
                clock.minutes = clock.minutes % 60;
                clock.hours += additionalHours;
                if (clock.hours >= 24)
                {
                    clock.hours = clock.hours % 24;
                }
            }
            return clock;
        }
        public static DialClock operator +(int minutesToAdd, DialClock clock)
        {
            clock.minutes += minutesToAdd;
            if (clock.minutes >= 60)
            {
                int additionalHours = clock.minutes / 60;
                clock.minutes = clock.minutes % 60;
                clock.hours += additionalHours;
                if (clock.hours >= 24)
                {
                    clock.hours = clock.hours % 24;
                }
            }
            return clock;
        }

        //Убавление минут с лева и справа
        public static DialClock operator -(DialClock clock, int minutesToSubtract)
        {
            clock.minutes -= minutesToSubtract;
            if (clock.minutes < 0)
            {
                int borrowHours = Math.Abs(clock.minutes / 60) + 1;
                clock.minutes = 60 + (clock.minutes % 60);
                clock.hours -= borrowHours;
                if (clock.hours < 0)
                {
                    clock.hours = 24 + (clock.hours % 24);
                }
            }
            return clock;
        }

        //public static DialClock operator -(int minutesToSubtract, DialClock clock)
        //{
        //    minutesToSubtract -= clock.minutes;
        //    if (minutesToSubtract < 0)
        //    {
        //        int borrowHours = Math.Abs(minutesToSubtract / 60);
        //        minutesToSubtract = 60 + (minutesToSubtract % 60);
        //        minutesToSubtract -= borrowHours;
        //        if (minutesToSubtract < 0)
        //        {
        //            minutesToSubtract = 24 + (minutesToSubtract % 24);
        //        }
        //    }
        //    clock.minutes = minutesToSubtract % 60;
        //    return clock;
        //}

        //Кол-во созданных объектов в классе 
        public static int GetObjectCount()
        {
            return objectCount;
        }
    }
}

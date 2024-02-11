using System;
using System.Globalization;

namespace Лабораторная_9
{
    static class Program
    {
        static void Main(string[] args)
        {
            DialClock clock = new DialClock();
            clock.Hours = 2;
            clock.Minutes = 5;
            DialClock clock1 = new DialClock(15, 22);
            DialClock clock2 = new DialClock(clock1);
            Console.WriteLine(clock.GetLittleAngle());

            ShowMenu();        
            bool IsOk = false;
            do
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        int count = DialClock.GetObjectCount();
                        Console.WriteLine($"Расстояние между часовой и минутной стрелкой первого объекта: {clock.GetLittleAngle()} градусов");
                        Console.WriteLine($"Расстояние между часовой и минутной стрелкой второго объекта: {clock1.GetLittleAngle()} градусов");
                        Console.WriteLine($"Расстояние между часовой и минутной стрелкой третьего объекта: {clock2.GetLittleAngle()} градусов");
                        Console.WriteLine($"Количество созданных объектов: {count}");
                        break;
                    case "2":
                        DialClock dialClock = new DialClock(12, 30);
                        Console.WriteLine(dialClock.Hours + ":" + dialClock.Minutes);  
                        dialClock++;
                        Console.WriteLine(dialClock.Hours + ":" + dialClock.Minutes);
                        dialClock--; 
                        Console.WriteLine(dialClock.Hours + ":" + dialClock.Minutes);
                        bool isAngleMultipleOf2_5 = (bool)dialClock;  // Явное приведение типа
                        Console.WriteLine(isAngleMultipleOf2_5);
                        int minutesPassed = dialClock;  // Неявное приведение типа
                        Console.WriteLine(minutesPassed);
                        DialClock newDc = dialClock + 60;  // Добавление 60 минут
                        Console.WriteLine(newDc.Hours + ":" + newDc.Minutes);  
                        DialClock newDc2 = dialClock - 30;  // Вычитание 30 минут
                        Console.WriteLine(newDc2.Hours + ":" + newDc2.Minutes);
                        break;
                    case "3":
                        Console.WriteLine("1 массив");
                        DialClockArray dialClockArray = new DialClockArray(5);
                        dialClockArray.Show();
                        Console.WriteLine("2 массив");
                        DialClockArray dialClockArray1 = new DialClockArray(dialClockArray);
                        dialClockArray1.Show();
                        Console.WriteLine("1 массив");
                        dialClockArray[0] = new DialClock(5, 25);
                        dialClockArray.Show();
                        Console.WriteLine("2 массив");
                        dialClockArray1.Show();
                        int count1 = DialClock.GetObjectCount();
                        int count2 = DialClockArray.GetCollectionCount();
                        Console.WriteLine("Максимальный угол у часов в коллекции 1: " + dialClockArray.GetMaxAngle().ToString());
                        Console.WriteLine("Максимальный угол у часов в коллекции 2: "+dialClockArray1.GetMaxAngle().ToString());
                        Console.WriteLine($"Создано объектов {count1}");
                        Console.WriteLine($"Создано коллекций {count2}");
                        break;
                    case "4":                        
                        DialClockArray dialClockArray2 = new DialClockArray(5,1);
                        dialClockArray2[0]= new DialClock(0, 0);
                        Console.WriteLine(dialClockArray2[0]);
                        try
                        {
                            dialClockArray2[11] = new DialClock(5, 25);
                            Console.WriteLine(dialClockArray2[11]);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        dialClockArray2.Show();
                        Console.WriteLine("Максимальный угол у часов в коллекции 3: " + dialClockArray2.GetMaxAngle().ToString());
                        
                        int count3 = DialClock.GetObjectCount();
                        int count4 = DialClockArray.GetCollectionCount();
                        Console.WriteLine($"Создано объектов {count3}");
                        Console.WriteLine($"Создано коллекций {count4}");
                        break;
                    default:
                        IsOk = true;
                        break;
                }
            } while (IsOk);
    
            Console.ReadKey();
        }


        static public void ShowMenu()
        {
            Console.WriteLine("   ||Menu||   \n" +
                "1. Задание №1\n" +
                "2. Задание №2\n" +
                "3. Задание №3 (случайное создание массива)\n" +
                "4. Задание №3 (создание массива с клавиатуры)\n");
        }
    }
}

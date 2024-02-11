using System;

namespace Лабораторная_9
{
    public class DialClockArray
    {
        static Random random = new Random();
        private static int collectionCount = 0;
        DialClock[] array;

        public int Length
        {
            get => array.Length;
        }

        //Конструктор без параметров
        public DialClockArray()
        {
            collectionCount++;
            array = new DialClock[1];
        }

        //Конструктор с параметрами, заполняющий элементы случайными значениями
        public DialClockArray(int lengthArray)
        {
            collectionCount++;
            array = new DialClock[lengthArray];
            for (int i = 0; i < lengthArray; i++)
            {                
                array[i] = new DialClock(random.Next(0, 24), random.Next(0, 60));
            }
        }

        //Конструктор с параметрами, заполняющий с клавиатуры
        public DialClockArray(int lengthArray, int a)
        {
            collectionCount++;
            array = new DialClock[lengthArray];
            for (int i = 0; i < lengthArray; i++)
            {
                Console.WriteLine($"Создайте {i + 1} элемент массива");
                Console.Write("Введите часы: ");
                string hourString = Console.ReadLine();
                Console.Write("Введите минуты: ");
                string minuteString = Console.ReadLine();
                DialClock dialClock = new DialClock(hourString, minuteString);                
                array[i] = dialClock;
            }
        }

        public DialClockArray(DialClockArray other)
        {
            collectionCount++;
            this.array = new DialClock[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                this.array[i] = new DialClock(other.array[i]);
            }
        } 


        //Для вывода элементов коллекции
        public void Show()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].ToString());
            }
        }

        public void Show2()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        //Индексатор
        public DialClock this[int index]
        {
            get
            {
                if (0 <= index && index < array.Length)
                    return array[index];
                else
                    throw new Exception("Индекс находился вне границ массива");
            }
            set
            {
                if (0 <= index && index < array.Length)
                    array[index] = value;
                else
                    throw new Exception("Индекс находился вне границ массива");
            }
        }

        //Для нахождения максимального угла
        public DialClock GetMaxAngle()
        {
            DialClock maxAngle = new DialClock();
            for(int i = 0; i<array.Length; i++)
            {
                if (array[i].GetLittleAngle() > maxAngle)
                    maxAngle = array[i];
            }
            return maxAngle;
        }


        //Кол-во созданных объектов в классе 
        public static int GetCollectionCount()
        {
            return collectionCount;
        }
    }
}

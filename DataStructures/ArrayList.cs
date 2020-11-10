using System;

namespace DataStructures
{
    public class ArrayList
    {
        private int[] _array; //поле
        public int Length { get; private set; } //автоматическое свойство чтобы обращаться к полезной длине
        public ArrayList() //конструктор 
        {
            _array = new int[9]; //изначальный массив
            Length = 0; //значение полезной длины по умолчанию при создании объекта конструктором
        }

        public void Add(int value)
        {
            if (_array.Length <= Length)
            {
                IncreaseLength();
            }
            _array[Length] = value;
            Length++;
        }

        private void IncreaseLength(int number = 1)
        {
            int newLength = Length;
            while (newLength <= Length + number)
            {
                newLength = (int)(Length * 1.33 + 1);
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }
    }
}

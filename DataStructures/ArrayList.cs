using System;
using System.Linq;

namespace DataStructures
{
    public class ArrayList
    {
        private int[] _array; //поле
        public int Length { get; private set; } //автоматическое свойство чтобы обращаться к полезной длине

        public ArrayList(int[] array) //конструктор 
        {
            _array = new int[(int)(array.Length * 1.33d)]; 
            Length = array.Length;
            Array.Copy(array, _array, array.Length);
        }

        public ArrayList() //конструктор 
        {
            _array = new int[3]; //изначальный массив
            Length = 0; //значение полезной длины по умолчанию при создании объекта конструктором
        }

        public override string ToString()
        {
            return string.Join(";", _array.Take(Length));
        }

        public void AddToEnd(int value)
        {
            if (_array.Length <= Length)
            {
                IncreaseLength();
            }
            _array[Length] = value;
            Length++;
        }

        public void AddToFirst(int value)
        {
            if (Length == _array.Length)
            {
                IncreaseLength();
            }
            int[] newArr = new int[_array.Length];
            for (int i = 0; i <= Length; i++)
            {
                newArr[i+1] = _array[i];
            }
            newArr[0] = value;
            _array = newArr;
        }

        public void AddToIndex(int index, int value)
        {

        }

        private void IncreaseLength(int number = 1)
        {
            int newLength = _array.Length;
            while (newLength <= Length + number)
            {
                newLength = (int)(newLength * 1.33 + 1);
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray; //новый массив приравнялся к старому, метод поменял поле
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])//если элемент массива не равен элементу массива из объекта полученного на вход 
                                                         //arrayList._array[i] берётся из приватного поля другого объекта
                                                         //так как мы в том же классе где поле _array объявлено, мы можем к нему обращаться
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

using System;
using System.Linq;

namespace DataStructures
{
    public class ArrayList
    {
        private int[] _array; //поле
        //вынести 1.33 в константу
        public int Length { get; private set; } //автоматическое свойство чтобы обращаться к полезной длине

        public ArrayList(int[] array) //конструктор 
            //конструктор создаёт пустой массив
        {
            _array = new int[(int)(array.Length * 1.33d)]; //умножение на 1.33 чтобы размер был больше 0
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

            if (Length <= _array.Length)
            {
                IncreaseLength();
            }
            int[] newArr = new int[_array.Length];
            for (int i = 0; i <= Length; i++)
            {
                newArr[i+1] = _array[i];
            }
            Length++;
            newArr[0] = value;
            _array = newArr;
        }

        public void AddToIndex(int index, int value)
        {
            if (Length <= _array.Length)
            {
                IncreaseLength();
            }
            if (Length != 0)
            {
                for (int i = Length; i >= Length - index; i--)
                {
                    _array[i] = _array[i - 1];
                }
            }
            Length++;
            _array[index] = value;

            //int[] newArr = new int[_array.Length];
            //Length++;
            //for (int i = 0; i < index; i++)
            //{
            //    newArr[i] = _array[i];
            //}
            //for (int i = index; i <= Length; i++)
            //{
            //    if (i <= _array.Length)
            //    {
            //        newArr[i + 1] = _array[i];
            //    }
            //}
            //newArr[index] = value;
            //_array = newArr;
        }

        public void RemoveFirst()
        {
            RemoveIndex(0);
        }
        public void RemoveLast()
        {
            RemoveIndex(Length);
        }

        //make private?
        public void RemoveIndex(int index)
        {
            if (Length > 1)
            {
                for (int i = index; i < Length; i++)
                {
                    _array[i] = _array[i + 1];
                }
            }
            Length--;
        }

        public int GetLength(int[] array)
        {
            return Length;
        }

        public int GetValueByIndex(int index)
        {
            return _array[index];
        }

        public int GetIndexByValue(int value)
        {
            int index = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                }
            }
            return index;
        }

        public void ChangeValueByIndex(int index, int value)
        {
            _array[index] = value;

            if (index > Length || index < 0 )
            {
                throw new IndexOutOfRangeException();
            }

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

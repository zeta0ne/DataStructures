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
            _array = new int[(int)(array.Length * 1.33d )]; //умножение на 1.33 чтобы размер был больше 0
            Length = array.Length;
            Array.Copy(array, _array, array.Length);
        }

        public ArrayList() //конструктор 
        {
            _array = new int[3]; //изначальный массив
            Length = 0; //значение полезной длины по умолчанию при создании объекта конструктором
        }

        public ArrayList(int i) //конструктор 
        {
            _array = new int[1] { i }; 
            Length = 1;
        }

        // Создание индексаторов для класса
        public int this[int i]
        {
            get
            {
                if (i >= Length || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[i];
            }
            set
            {
                if (i >= Length || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[i] = value;
            }
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
                for (int i = Length; i > index; i--)
                {
                    _array[i] = _array[i - 1];
                }
            }
            Length++;
            _array[index] = value;
        }

        public void RemoveFirst()
        {
            RemoveIndex(0);
        }
        public void RemoveLast()
        {
            if (Length > 0)
            {
                RemoveIndex(Length);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveIndex(int index)
        {
            if (Length > 1)
            {
                for (int i = index; i < Length; i++)
                {
                   _array[i] = _array[i + 1];
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
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

        public void Reverse()
        {
            int t = 0;
            for (int i = 0; i < _array.Length/2; i++)
            {
                t = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = t;
            }
        }

        public int GetMaxValue()
        {
            int maxVal = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > maxVal)
                {
                    maxVal = _array[i];
                }
            }
            return maxVal;
        }

        public int GetMinValue()
        {
            int minVal = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < minVal)
                {
                    minVal = _array[i];
                }
            }
            return minVal;
        }

        public int GetMaxValueIndex()
        {
            int maxValIn = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > maxValIn)
                {
                    maxValIn = i;
                }
            }
            return maxValIn;
        }

        public int GetMinValueIndex()
        {
            if (Length > 0)
            {
                int minValIn = _array[0];
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] < minValIn)
                    {
                        minValIn = i;
                    }
                }
                return minValIn;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void SortByAscending()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    int minIndex = _array[i];
                    if (_array[j] > minIndex)
                    {
                        minIndex = _array[j];
                        _array[j] = _array[i];
                        _array[i] = minIndex;
                    }
                }
            }
        }

        public void SortByDescending()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    int minIndex = _array[i];
                    if (_array[j] < minIndex)
                    {
                        minIndex = _array[j];
                        _array[j] = _array[i];
                        _array[i] = minIndex;
                    }
                }
            }
        }

        public void RemoveValues(int value)
        {
            if (Length == _array.Length)
            {
                IncreaseLength();
            }
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    for (int j = i; j < Length; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    Length--;
                    i--;
                }
            }
        }

        public void RemoveFirstValue(int value) //using RemoveIndex() doesn't work for array with 1 element because this method can't run if array is 1 element long
        {
            if (Length == _array.Length)
            {
                IncreaseLength();
            }
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    for (int j = i; j < Length; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    Length--;
                    return;               
                }
            }
        }

        public void AddArrayToFirstIndex(int[] values)
        {
            //подвинуть все элементы на вэльюс.Ленгтх клеток
            //записать элементы из вэльюс на пустые места
            if ((Length + values.Length) >= _array.Length)
            {
                IncreaseLength(values.Length);
            }
            for (int i = 0; i < Length; i++)
            {
                _array[(Length + values.Length) - 1 - i] = _array[Length - 1 - i];
            }
            for (int i = 0; i < values.Length; i++)
            {
                _array[i] = values[i];
            }
            Length += values.Length;
        }

        public void AddArrayToEndOfList(int[] values)
        {
            if ((Length + values.Length) >= _array.Length)
            {
                IncreaseLength(values.Length);
            }
            
            for (int i = 0; i < values.Length; i++)
            {
                _array[Length + i] = values[i];
            }
            Length += values.Length;
        }

        public void AddArrayToIndex(int[] values, int index)
        {
            //подвинуть все элементы на вэльюс.Ленгтх клеток
            //записать элементы из вэльюс на пустые места
            if ((Length + values.Length) >= _array.Length)
            {
                IncreaseLength(values.Length);
            }
            for (int i = 0; i < Length - index; i++)
            {
                _array[(Length + values.Length) - 1 - i] = _array[Length - 1 - i];
            }
            for (int i = 0; i < values.Length; i++)
            {
                _array[index + i] = values[i];
            }
            Length += values.Length;
        }

        public void RemoveNElementsFromEnd(int amount)
        {
            for (int i = Length-1; i >= Length - amount; i--)
            {
                _array[i] = 0;
            }
            Length -= amount;
        }

        public void RemoveNElementsFromBeginning(int amount)
        {
            if (amount > _array.Length - Length)
            {
                IncreaseLength(amount);
            }
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _array[amount + i];
            }
            Length -= amount;
            DecreaseLength();
        }

        public void RemoveNElementsFromIndex(int amount, int index)
        {
            if (amount > _array.Length - Length)
            {
                IncreaseLength(amount);
            }
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[amount + i];
            }
            Length -= amount;
            DecreaseLength();
        }

        private void DecreaseLength()
        {
            if (Length <= _array.Length / 2 - 1 && _array.Length > 3)
            {
                int newLength = _array.Length;
                while (newLength >= _array.Length / 2 - 1)
                {
                    newLength = (int)(newLength * 0.66 + 1);
                }
                int[] newArray = new int[newLength];
                Array.Copy(_array, newArray, newLength);
                _array = newArray;
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

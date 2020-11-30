using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public interface ILists
    {
        public int Length { get; set; }
        public string ToString();
        public void AddToEnd(int value);
        public void AddToFirst(int value);
        public void AddToIndex(int index, int value);
        public void RemoveFirstElement();
        public void RemoveLastElement();
        public void RemoveElementByIndex(int index);
        public int GetValueByIndex(int index);
        public int GetIndexByValue(int value);
        public void ChangeValueByIndex(int index, int value);
        public void Reverse();
        public int GetMaxValue();
        public int GetMinValue();
        public int GetMaxValueIndex();
        public int GetMinValueIndex();
        public void SortByAscending();
        public void SortByDescending();
        public void RemoveAllValues(int value);
        public void RemoveFirstValue(int value);
        public void AddArrayToBeginning(int[] values);
        public void AddArrayToEnd(int[] values);
        public void AddArrayToIndex(int[] values, int index);
        public void RemoveNElementsFromEnd(int amount);
        public void RemoveNElementsFromBeginning(int amount);
        public void RemoveNElementsFromIndex(int amount, int index);
        public bool Equals(object obj);
    }
}

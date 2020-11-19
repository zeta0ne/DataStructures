using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DLL
{
    public class Node //сама нода
    {
        public int Value { get; set; } //значение ноды
        public Node Next { get; set; } //переменная типа Node для хранения ссылки на след ноду
                                       //в переменной класса хранится ссылка на объект, а не сам объект
        public Node Prev { get; set; }

        //конструкторы:
        public Node(int value)
        {
            Value = value;
            Next = null;  //это значит "следующий элемент пока никакой"
            Prev = null;
        }
        public Node()
        {
            Next = null; //это значит "следующий элемент пока никакой"
            Prev = null;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LL
{
    public class LinkedList
    {
        public int Length { get; set; }
        
        private Node _root; //ссылка на первый элемент списка

        public LinkedList() //пустой конструктор ЛЛ не должен обращаться к руту, 
                            //потому что если в руте будет ссылка на какой-то объект, 
                            //то это будет значить что нулевой объект уже создан
        {
            Length = 0;
            _root = null; //тк конструктор пустой, в руте ничего нет
        }

        public LinkedList(int value)
        {
            _root = new Node(value); //в руте вызвается конструктор ноды на основе одного эл-та
                                     //и теперь в руте ссылка на новую ноду, само значение лежит где-то там по ссылке
            Length = 1;
        }

        public LinkedList(int[] array) //конструктор на основе массива
        {
            _root = new Node(array[0]); //рут - первый элемент, поэтому он с индексом 0
            Node tmp = _root; //временная переменная для счёта, ссылается туда же куда и рут

            for (int i = 1; i < array.Length; i++)
            {
                tmp.Next = new Node(array[i]); //tmp.Next обращается к полю для хранения ссылки внутри ноды;
                                               //1) создаётся новый объект типа нод
                                               //2) ссылка на новый объект возвращается в tmp.Next
                                               //3) некст это поле для хранения ссылки

                tmp = tmp.Next; //переопределение временной переменной в следующий элемент
            }
            Length = array.Length;
        }
    }
}

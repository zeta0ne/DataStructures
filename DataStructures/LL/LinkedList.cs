using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LL
{
    public class LinkedList
    {
        public int Length { get; set; }
        
        private Node _root; //ссылка на первый элемент списка
                            //рут - не нода, а место для хранения ссылки
                            //это переменная, а не объект

        public int this[int index]
        {
            get //достаёт значение по индексу
            {
                Node tmp = _root; //ссылка которая лежит в тмп теперь такая же как в руте
                for (int i = 1; i <= index; i++) //не с нуля, потому что нулевой элемент и так в руте/тмп
                {
                    tmp = tmp.Next; 
                }
                return tmp.Value;
            }

            set //с помощью сеттера можно менять значение по индексу
            {
                Node tmp = _root; 
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

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
            if (array.Length != 0) //на случай если передаётся пустой массив
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
            else
            {
                Length = 0;
                _root = null;
            }
        }

        public void AddToEnd(int value)
        {
            if (Length == 0) //отдельная обработка пустого списка
            {
                _root = new Node(value); 
            }
            else
            {
                Node current = _root; //временная переменная чтобы от начала списка бежать по нему до конца
                for (int i = 1; i < Length; i++) //нужно прибежать на одну клетку раньше, чтобы с этой клетки кинуть ссылку на новый нод
                {
                    current = current.Next;
                }
                current.Next = new Node(value); //новый нод с нужным значением на месте следующего за тем, до которого мы дошли в цикле
                                                //в каррент.Некст теперь лежит ссылка на новый элемент
            }
            Length++;
        }

        public void AddToBeginning(int value)
        {
            Node tmp = _root; //сохраняем рут во временную переменную чтобы не потерять
            _root = new Node(value); //новый рут
            _root.Next = tmp; //новый рут теперь ссылается на старый
            Length++;
        }

        public void AddByIndex(int index, int value)
        {
            if (index == 0) //отдельная обработка рута
            {
                Node tmp = _root; //сохраняем рут во временную переменную чтобы не потерять
                _root = new Node(value); //новый рут
                _root.Next = tmp; //новый рут теперь ссылается на старый
            }
            else
            {
                Node current = _root; //временная переменная чтобы от начала списка бежать по нему до определённого индекса
                for (int i = 1; i < index; i++) //нужно прибежать на одну клетку раньше, чтобы с этой клетки кинуть ссылку на новый нод
                {
                    current = current.Next;
                }
                Node tmp = current.Next; //временная переменная чтобы сохранить ссылку на элемент который будет после добавленного
                current.Next = new Node(value); //новый нод с нужным значением на месте следующего за тем, до которого мы дошли в цикле
                                                //в каррент.Некст теперь лежит ссылка на новый элемент

                //current - ссылка на элемент перед нужным индексом, на котором остановился цикл
                //каррент.Некст - ссылка на теперь уже новый нод
                //каррент.Некст.Некст = тмп - в следующий элемент кидается ссылка из тмп на весь оставшийся список
                current.Next.Next = tmp;
            }
            Length++;
        }

        public void RemoveLastElement()
        {
            if (Length != 0)
            {
                Node current = _root; //временная переменная чтобы от начала списка бежать по нему до определённого индекса
                for (int i = 1; i < Length; i++) //нужно прибежать на одну клетку раньше, чтобы с этой клетки удалить ссылку на последний нод
                {
                    current = current.Next;
                }
                current.Next = null;
                Length--;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void RemoveFirstElement()
        {
            if (Length != 0)
            {
                _root = _root.Next;
                Length--;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void RemoveElementByIndex(int index)
        {
            if (Length != 0)
            {
                if (index == 0)
                {
                    RemoveFirstElement();
                }
                else
                {
                    Node current = _root; //временная переменная чтобы от начала списка бежать по нему до определённого индекса
                    for (int i = 1; i < index; i++) //нужно прибежать на одну клетку раньше, чтобы с этой клетки кинуть ссылку на новый нод
                    {
                        current = current.Next;
                    }
                   
                    //current - ссылка на элемент перед нужным индексом, на котором остановился цикл
                    //каррент.Некст - ссылка на теперь уже новый нод
                    //каррент.Некст.Некст - в следующий элемент кидается ссылка на весь оставшийся список
                    current.Next = current.Next.Next;
                    Length--;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }



        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;
            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";

            if (_root != null)
            {
                Node tmp = _root;

                while (tmp != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;
                }
            }
            return s;
        }

    }
}

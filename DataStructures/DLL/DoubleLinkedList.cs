using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DLL
{
    public class DoubleLinkedList //: ILists
    {
        public int Length { get; set; }

        private Node _root; //ссылка на первый элемент списка
                            //рут - не нода, а место для хранения ссылки
                            //это переменная, а не объект

        private Node _tail;

        public int this[int index]
        {
            get //достаёт значение по индексу
            {
                if (index > Length/2 + 1)
                {
                    Node tmp = _tail;
                    for (int i = Length; i > index + 1; i--) 
                    {
                        tmp = tmp.Prev;
                    }
                    return tmp.Value;
                }
                else
                {
                    Node tmp = _root; //ссылка которая лежит в тмп теперь такая же как в руте

                    for (int i = 1; i <= index; i++) //не с нуля, потому что нулевой элемент и так в руте/тмп
                    {
                        tmp = tmp.Next;
                    }
                    return tmp.Value;
                }
            }

            set //с помощью сеттера можно менять значение по индексу
            {
                if (index > Length / 2 + 1)
                {
                    Node tmp = _tail;
                    for (int i = Length; i > index + 1; i--)
                    {
                        tmp = tmp.Prev;
                    }
                    tmp.Value = value;
                }
                else
                {
                    Node tmp = _root; //ссылка которая лежит в тмп теперь такая же как в руте

                    for (int i = 1; i <= index; i++) //не с нуля, потому что нулевой элемент и так в руте/тмп
                    {
                        tmp = tmp.Next;
                    }
                    tmp.Value = value;
                }               
            }
        }

        public DoubleLinkedList() //пустой конструктор ЛЛ не должен обращаться к руту, 
                            //потому что если в руте будет ссылка на какой-то объект, 
                            //то это будет значить что нулевой объект уже создан
        {
            Length = 0;
            _root = null; //тк конструктор пустой, в руте ничего нет
            _tail = null;
        }

        public DoubleLinkedList(int value)
        {
            _root = new Node(value); //в руте вызвается конструктор ноды на основе одного эл-та
                                     //и теперь в руте ссылка на новую ноду, само значение лежит где-то там по ссылке
            //_tail = _root;
            Length = 1;
        }

        public DoubleLinkedList(int[] array) //конструктор на основе массива
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
                    tmp.Next.Prev = tmp;
                    
                    tmp = tmp.Next; //переопределение временной переменной в следующий элемент
                }
                _tail = tmp;
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
        }

        public void AddToEnd(int value)
        {
            if (Length == 0) 
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                Node tmp = new Node(value);
                _tail.Next = tmp;
                tmp.Prev = _tail;
                _tail = tmp;
            }
            Length++;
        }

        public void AddToFirst(int value)
        {
            if (Length == 0) //отдельная обработка пустого списка
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                Node tmp = _root; 
                _root = new Node(value); 
                _root.Next = tmp;
                tmp.Prev = _root;
            }
            Length++;
        }

        //сделать метод который выдаёт ноду по нужному индексу, в котором условия 
        //как в индексаторе чтобы или бежать сначала, или с конца
        public void AddToIndex(int value, int index)
        {
            if (Length == 0) //отдельная обработка пустого списка
            {
                _root = new Node(value);
                _tail = _root;
                Length++;
            }
            else
            {
                if (index == 0)
                {
                    AddToFirst(value);
                }
                else
                {
                    Node val = new Node(value);
                    Node cur = _root;
                    for (int i = 1; i < index; i++) //дойти до значения перед нужным индексом
                    {
                        cur = cur.Next;
                    }
                    Node tmp = cur.Next;
                    cur.Next = val;
                    val.Prev = cur;
                    val.Next = tmp;
                    tmp.Prev = val;
                    Length++;
                }
            }
        }

        public void RemoveFirstElement()
        {
            if (Length != 0)
            {
                if (_root.Next != null)
                {
                    _root.Next.Prev = null;
                }
                _root = _root.Next;
                Length--;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void RemoveLastElement()
        {
            if (Length != 0)
            {
                if (_tail.Prev != null)
                {
                    _tail.Prev.Next = null;
                }
                _tail = _tail.Prev;
                Length--;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void RemoveElementByIndex(int index)
        {

        }

        public override bool Equals(object obj)
        {
            DoubleLinkedList linkedList = (DoubleLinkedList)obj;

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
            tmp1 = _tail;
            tmp2 = linkedList._tail;
            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Prev;
                tmp2 = tmp2.Prev;
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

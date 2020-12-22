using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DLL
{
    public class DoubleLinkedList : ILists
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
                    if (index <= Length/2)
                    {
                        Node cur = ForwardCounter(index);
                        Node tmp = cur.Next;
                        cur.Next = val;
                        val.Prev = cur;
                        val.Next = tmp;
                        tmp.Prev = val;
                        Length++;
                    }
                    else
                    {
                        Node cur = BackwardsCounter(index);
                        Node tmp = cur.Next;
                        cur.Next = val;
                        val.Prev = cur;
                        val.Next = tmp;
                        tmp.Prev = val;
                        Length++;
                    }
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
            if (Length != 0)
            {
                if (index == 0)
                {
                    RemoveFirstElement();
                }
                else if (index == Length - 1)
                {
                    RemoveLastElement();
                }
                else if (index <= Length / 2)
                {
                    Node cur = ForwardCounter(index);
                    cur.Next = cur.Next.Next;
                    cur.Next.Prev = cur;
                    Length--;
                }
                else
                {
                    Node cur = BackwardsCounter(index);
                    cur.Next = cur.Next.Next;
                    cur.Next.Prev = cur;
                    Length--;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int GetValueByIndex(int index)
        {
            return this[index];
        }

        public int GetIndexByValue(int value)
        {
            if (Length != 0)
            {
                int index = -1;
                Node cur = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (cur.Value == value)
                    {
                        index = i;
                        break;
                    }
                    else
                    {
                        cur = cur.Next;
                    }
                }
                if (index == -1)
                {
                    throw new Exception();
                }
                return index;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void ChangeValueByIndex(int index, int value)
        {
            if (Length != 0)
            {
                Node val = new Node(value);
                Node cur = new Node();
                if (index == 0)
                {
                    RemoveFirstElement();
                    AddToFirst(value);
                }
                else if (index == Length -1)
                {
                    RemoveLastElement();
                    AddToEnd(value);
                }
                else if (index <= Length / 2)
                {
                    cur = ForwardCounter(index);
                    Node tmp = cur.Next.Next;
                    cur.Next = val;
                    val.Prev = cur;
                    val.Next = tmp;
                    tmp.Prev = val;
                }
                else
                {
                    cur = BackwardsCounter(index);
                    Node tmp = cur.Next.Next;
                    cur.Next = val;
                    val.Prev = cur;
                    val.Next = tmp;
                    tmp.Prev = val;
                }
                
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public int GetMaxValue()
        {
            throw new NotImplementedException();
        }

        public int GetMinValue()
        {
            throw new NotImplementedException();
        }

        public int GetMaxValueIndex()
        {
            throw new NotImplementedException();
        }

        public int GetMinValueIndex()
        {
            throw new NotImplementedException();
        }

        public void SortByAscending()
        {
            throw new NotImplementedException();
        }

        public void SortByDescending()
        {
            throw new NotImplementedException();
        }

        public void RemoveAllValues(int value)
        {
            throw new NotImplementedException();
        }

        public void RemoveFirstValue(int value)
        {
            throw new NotImplementedException();
        }

        public void AddArrayToBeginning(int[] values)
        {
            throw new NotImplementedException();
        }

        public void AddArrayToEnd(int[] values)
        {
            throw new NotImplementedException();
        }

        public void AddArrayToIndex(int[] values, int index)
        {
            throw new NotImplementedException();
        }

        public void RemoveNElementsFromEnd(int amount)
        {
            throw new NotImplementedException();
        }

        public void RemoveNElementsFromBeginning(int amount)
        {
            throw new NotImplementedException();
        }

        public void RemoveNElementsFromIndex(int amount, int index)
        {
            throw new NotImplementedException();
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

        private Node ForwardCounter(int index)
        {
            Node cur = _root;
            for (int i = 0; i < index - 1; i++) //дойти до значения перед нужным индексом
            {
                cur = cur.Next;
            }
            return cur;
        }

        private Node BackwardsCounter(int index)
        {
            Node cur = _tail;
            for (int i = Length; i > index; i--)
            {
                cur = cur.Prev;
            }
            return cur;
        }
    }
}

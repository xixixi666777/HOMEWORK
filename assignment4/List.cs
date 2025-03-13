namespace _3_13C__1
{
    internal class List
    {
        static void Swap<T>(ref T left, ref T right)
        {
            T temp;
            temp = left;
            left = right;
            right = temp;
        }

        static void Main(string[] args)
        {
            GenericList<int>intlist=new GenericList<int>();
            for(int i = 0; i < 10; i++)
            {
                intlist.Add(i);
            }
            Action<int> PrintElement = (m) => { Console.Write(m+" "); };
            Console.WriteLine();
            intlist.ForEach(PrintElement);
            //calculate the sum
            int sum = 0;
            intlist.ForEach(m=>sum+=m);
            Console.WriteLine($"the sum of the list is {sum}");
            //calculate the maximum
            int max = -10;
            intlist.ForEach(m =>
            {
                if (m > max)
                    max = m;
            });
            Console.WriteLine($"the maximum of the list is {max}");
            //calculate the minimum
            int min = 100000;
            intlist.ForEach(m =>
            {
                if (m<min)
                    min = m;
            });
            Console.WriteLine($"the minimum of the list is {min}");
        }
    }
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t) {
            Node<T> n = new Node<T>(t);
            if (tail == null) {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }

        }
        public void ForEach(Action<T> action){
            for (Node<T> node = this.Head; node != null; node = node.Next)
            {

              action(node.Data);
            }


        }
        
    }
}



    


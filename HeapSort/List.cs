using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    public class MyDataList : DataList
    {
        public class Node
        {
            public Node nextNode { get; set; }
            public Data data { get; set; }

            public Node(Data data)
            {
                this.data = data;
            }
        }

        Node headNode;
        Node prevNode;
        Node currentNode;

        public MyDataList(int n, int seed)
        {
            length = n;
            Random rand = new Random(seed);
            headNode = new Node(new Data(seed*0));
            currentNode = headNode;
            for (int i = 1; i < length; i++)
            {
                prevNode = currentNode;
                currentNode.nextNode = new Node(new Data(seed*i));
                currentNode = currentNode.nextNode;
            }

            currentNode.nextNode = null;
        }

        public override Data Head()
        {
            currentNode = headNode;
            prevNode = null;
            return currentNode.data;
        }

        public override Data Next()
        {
            prevNode = currentNode;
            currentNode = currentNode.nextNode;
            return currentNode.data;
        }

        public override void Swap(int index1, int index2)
        {
            var temp1 = IndexAt(index1).data;
            var temp2 = IndexAt(index2).data;
            IndexAt(index1).data = temp2;
            IndexAt(index2).data = temp1;
        }

        public override Node Find(Data data)
        {
            // No list or data to find
            if (headNode != null || data != null)
            {
                Node tmp = headNode;
                // Try to find the data in the list
                while (tmp != null)
                {
                    // Data was found
                    if (tmp.data.Equals(data))
                        return tmp;
                    tmp = tmp.nextNode;
                }
            }
            // Data was not found in the list
            return null;
        }

        public override Node IndexAt(int index)
        {
            //Index was negative or larger then the amount of Nodes in the list
            if (index < 0 || index > length)
                return null;

            Node tmp = headNode;
            // Move to index
            for (int i = 0; i < index; i++)
            {
                tmp = tmp.nextNode;
            }
            // return the node at the index position
            return tmp;
        }

    }
}
using System;

namespace InsertingNodeToSortedDoublyLinkedList
{
    class DoublyLinkedListNode
    {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }

    class DoublyLinkedList
    {
        public DoublyLinkedListNode head;
        public DoublyLinkedListNode tail;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
                node.prev = this.tail;
            }

            this.tail = node;
        }
    }

    class Program
    {
        static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode llist, int data)
        {
            var node = llist;
            var newNode = new DoublyLinkedListNode(data);

            while (true)
            {
                if (node.data > newNode.data)
                {
                    if (node.prev != null)
                    {
                        node.prev.next = newNode;
                    }
                    else
                    {
                        llist = newNode;
                    }

                    newNode.prev = node.prev;
                    newNode.next = node;
                    node.prev = newNode;
                    break;
                }
                if (node.next == null)
                {
                    newNode.prev = node;
                    node.next = newNode;
                    break;
                }
                node = node.next;
            }

            return llist;
        }

        static void Main(string[] args)
        {
            var massStr = "1,2,4".Split(",");

            DoublyLinkedList llist = new DoublyLinkedList();

            foreach (var it in massStr)
            {
                llist.InsertNode(int.Parse(it));
            }

            llist.head = sortedInsert(llist.head, 0);

            Console.ReadLine();
        }
    }
}

using System;

namespace ReverseDoublyLinkedList
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
        static DoublyLinkedListNode reverse(DoublyLinkedListNode llist)
        {
            var node = llist;
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(llist.data);

            while(node != null)
            {
                if (node.next != null)
                {
                    newNode.prev = new DoublyLinkedListNode(node.next.data);
                    newNode.prev.next = newNode;
                }
                else
                    break;

                newNode = newNode.prev;
                    

                node = node.next;
            }

            return newNode;
        }

        static void Main(string[] args)
        {
            var massStr = "1,2,4".Split(",");

            DoublyLinkedList llist = new DoublyLinkedList();

            foreach (var it in massStr)
            {
                llist.InsertNode(int.Parse(it));
            }

            var ff = reverse(llist.head);

            Console.ReadLine();
        }
    }
}

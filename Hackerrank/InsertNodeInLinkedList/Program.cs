using System;
using System.Collections.Generic;


namespace InsertNodeInLinkedList
{
    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    class Program
    {
        public static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
        {
            var node = llist;

            var newNode = new SinglyLinkedListNode(data);

            for(int i = 1; i < position; i++)
            {
                node = node.next;
            }
            newNode.next = node.next;
            node.next = newNode;

            return newNode;
        }

        static void Main(string[] args)
        {
            var massStr = "16,13,7".Split(",");

            SinglyLinkedList llist = new SinglyLinkedList();

            foreach (var it in massStr)
            {
                llist.InsertNode(int.Parse(it));
            }

            insertNodeAtPosition(llist.head, 1, 2);

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections;
class Program {
    static void Main() {
        Queue queue = new Queue();
        queue.Enqueue("A");
        queue.Enqueue("B");
        queue.Enqueue("C");
        queue.Enqueue("C");
        queue.Enqueue("E");
        
        Stack stack = new Stack();
        while(queue.Count>0){
            stack.Push(queue.Dequeue());
        }
        
        foreach(object i in queue){
            Console.WriteLine(i);
        }
        
        foreach(object j in stack){
            Console.WriteLine(j);
        }
        
    }

}
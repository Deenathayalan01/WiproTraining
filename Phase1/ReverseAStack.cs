using System;
using System.Collections;
class Program {
    static void Main() {
        Stack stack = new Stack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        
        foreach (var i in stack){
            Console.WriteLine(i);
        }
        Stack a = new Stack();
        while(stack.Count>0){
            a.Push(stack.Pop());
        }
        Console.WriteLine("Break");
        foreach (object j in a){
            
            Console.WriteLine(j);
        }
        
    }
}
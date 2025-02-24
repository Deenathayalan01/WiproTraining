using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        int rem,rev=0;
        int temp=number;
        while(temp>0){
            rem=temp%10; // % = remainder
            rev=rev+(rem*rem*rem);
            temp=temp/10; // / =Quotient
        }
        Console.WriteLine(rev);
        if (number==rev){
            Console.WriteLine("Armstrong Number");
        }else{
            Console.WriteLine("Not an Armstrong Number");
        }

    }
}
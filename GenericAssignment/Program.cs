// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
namespace GenericAssignment;

public class program
{
    public static void Main()
    {
        //Test stack
        //MyStack<string> myStack = new MyStack<string>();
        //myStack.Push("111");
        //myStack.Push("222");
        //Console.WriteLine(myStack.top);
        //myStack.Pop();
        //Console.WriteLine(myStack.top);

        //Test list
        MyList<string> myList = new MyList<string>();
        myList.Add("111");
        myList.Add("222");
        myList.Add("333");
        myList.Add("444");
        myList.GetAllElement();
        Console.WriteLine("\n");

        //myList.Remove(2);
        //myList.GetAllElement();
        //Console.WriteLine("\n");

        Console.WriteLine(myList.Contains("111"));

        myList.InsertAt("333", 1);
        myList.GetAllElement();
        Console.WriteLine("\n");

        myList.DeletAt(1);
        myList.GetAllElement();
        Console.WriteLine("\n");

        Console.WriteLine(myList.Find(2));


    }
}


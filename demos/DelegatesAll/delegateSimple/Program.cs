using System;

namespace delegateSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegateClass myDelegateClass = new DelegateClass();
            MethodsClass myMethodsClass = new MethodsClass();
            
            // myDelegateClass.mySimpleDelegate = myMethodsClass.Method1;
            // myDelegateClass.mySimpleDelegate += myMethodsClass.Method2;
            // myDelegateClass.mySimpleDelegate += myMethodsClass.Method3;

            //cannot assign method4, signature does not match
            //myDelegateClass.mySimpleDelegate = myMethodsClass.method4;

            //calls the delegate
            //myDelegateClass.mySimpleDelegate();

            //can remove methods from delegate also
            //myDelegateClass.mySimpleDelegate -= myMethodsClass.Method3;

            // myDelegateClass.myNotSimpleDelegate = myMethodsClass.Method4;
            // myDelegateClass.myNotSimpleDelegate += myMethodsClass.Method5;
            // myDelegateClass.myNotSimpleDelegate += myMethodsClass.Method6;

            // string myString = "This ";
            // int result = myDelegateClass.myNotSimpleDelegate(myString);
            // Console.WriteLine($"the result is -> {result}\n {myString}");

            #region Action<> Delegates
            // myDelegateClass.MyActionWithParam = myMethodsClass.Method11;
            // myDelegateClass.MyActionWithParam += myMethodsClass.Method22;
            // myDelegateClass.MyActionWithParam += myMethodsClass.Method33;
            // myDelegateClass.MyActionWithParam(5);

            myDelegateClass.myFuncDelegate = myMethodsClass.Method7;
            int myint = myDelegateClass.myFuncDelegate();
            Console.WriteLine($"The int returned is {myint}");

            #endregion

        }
    }
}

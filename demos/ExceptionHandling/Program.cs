using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            int five = 5;
            try{
                int a = five/0;
            }
            // catch(ArithmeticException ex){
            //     Console.WriteLine("cannot divide by 0 ya nob\n" + ex.Message);
            // }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally{
                Console.WriteLine("This is the finally block");
            }
        }
    }
}

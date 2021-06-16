using System;

namespace delegateSimple
{
    public class MethodsClass{
        public void Method1(){
            Console.WriteLine($"This is method 1.");
        }
        public void Method2(){
            Console.WriteLine($"This is method 2.");
        }
        public void Method3(){
            Console.WriteLine($"This is method 3.");
        }
        public int Method4(string message){
            Console.WriteLine($"Method 4. Add something to the message:");
            string m = Console.ReadLine();
            message +=m;
            return 0;
        }

        public int Method5(string message){            
            Console.WriteLine($"Method 5. Add something to the message:");
            string m = Console.ReadLine();
            message +=m;
            return 1;
        }

        public int Method6(string message){          
            Console.WriteLine($"Method 6. Add something to the message:");
            string m = Console.ReadLine();
            message +=m;
            return 2;  
        }
        public int Method7(){          
            Console.WriteLine($"Method 7. Give a number:");
            int usersInt;
            bool m = Int32.TryParse(Console.ReadLine(), out usersInt);
            return usersInt;  
        }
        public void Method11(int x){
            Console.WriteLine($"This is method 1. {x}");
        }
        public void Method22(int x){
            Console.WriteLine($"This is method 2. {x}");
        }
        public void Method33(int x){
            Console.WriteLine($"This is method 3. {x}");
        }
        
    }
}

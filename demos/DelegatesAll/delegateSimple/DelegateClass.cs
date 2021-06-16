using System;

namespace delegateSimple
{
    public class DelegateClass
    {
        //declare a delegate Type. This gives the method signature for any method that can be assigned to a delegate of this type
        public delegate void SimpleDelegate();
        
        //create the instance of the delegate type that you can assign methods to
        public SimpleDelegate mySimpleDelegate ;

        public delegate int NotSimpleDelegate(string msg);
        public NotSimpleDelegate myNotSimpleDelegate; 

        //action delegates "do an action" do not return value
        //Action delegate name for delegate with no parameters
        //Action<parameterType> delegateName is used when parameters are used
        public Action MyAction { get; set; }
        public Action<int> MyActionWithParam { get; set; }

        //function delegates: 
        public Func<int> myFuncDelegate;
    }
}
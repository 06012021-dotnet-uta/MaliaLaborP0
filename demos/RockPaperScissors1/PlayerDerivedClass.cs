namespace RockPaperScissors1
{
    public class PlayerDerivedClass : PersonBaseClass
    {
        private int myAge { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Wins { get; set; }
        public int Choice { get; set; }

        public int MyAge { get; set; }
        //overload constructors
        public PlayerDerivedClass() : base()
        {
            //fName = "defaultFname";
            //lName = "defaultLname";
            this.Wins = 0;
        }
        public PlayerDerivedClass(string fName, string lName, int myAge = 0) : base(fName, lName)
        {
            //this.fName = fName;
            //this.lName = lName;
            this.MyAge = myAge;
            this.Wins = 0;
        }

        public override string GetFullAddress()//all override needs to be virtual or abstract in parent
        {
            string fullAddress = $"{FName} {LName}\n{Street}\n{City}, {State}.";
            return fullAddress;
        }
    }
}
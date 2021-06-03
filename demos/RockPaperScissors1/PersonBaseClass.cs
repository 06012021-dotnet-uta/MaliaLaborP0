namespace RockPaperScissors1
{
    public class PersonBaseClass
    {
        //fields
        private string fName;
        private string lName;
        private string myCountry;
        //unmodified properties create an invisible private field that the data is stored to

        //properties
        public string LName
        {
            get
            {
                return lName;
            }
            set
            {
                if (value.Length > 20 || value.Length < 1)
                {
                    throw new System.InvalidOperationException("That name is invalid.");
                }
                lName = value;
            }
        }
        public string FName
        {
            get
            {
                return fName;
            }
            set
            {
                if (value.Length > 20 || value.Length < 1)
                {
                    throw new System.InvalidOperationException("That name is invalid.");
                }
                fName = value;
            }
        }
        public string MyCountry
        {
            get
            {
                return myCountry;
            }
            set
            {
                if (value != null)
                {
                    myCountry = value;
                }
            }
        }

        //constructors
        public PersonBaseClass() //default
        {
            FName = "default fName";
            LName = "default lName";
        }

        public PersonBaseClass(string fName, string lName) //override constructor
        {
            this.fName = fName;
            this.lName = lName;
        }

        public virtual string GetFullAddress()
        {
            string fullName = $"{fName} {lName}";
            return fullName;
        }
    }
}
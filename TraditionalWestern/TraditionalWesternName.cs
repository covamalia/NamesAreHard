using System.Collections.Generic;
using System.Linq;

namespace NamesAreHard
{
    class TraditionalWesternName : IName {
        TraditionalWesternName() {
            MiddleNames = new List<string>();
            GenderPronouns = new EnglishGenderPronouns();
        }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public List<string> MiddleNames { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }

        public string DisplayName(int charLimit)
        {
            string checkStringRevert=""; //lets keep this around to have a fallback if the next gate is too large
            string checkString="";

            //GATE 0: we have to use this if nothing else
            checkString = $"{FirstName.Substring(0,1)} {LastName}";

            //GATE 1: look at first and last names only and see if they hit the character limit
            checkStringRevert=checkString;
            checkString = $"{FirstName} {LastName}";
            
            
            if (checkString.Length>charLimit) {
                //fallback to first initial last name. trim end of last name if still requred
                 return (checkStringRevert).Substring(0,charLimit);
            }

            //GATE 2: First + last + suffix
            checkStringRevert=checkString;
            checkString=$"{FirstName} {LastName} {Suffix}";
            if (checkString.Length>charLimit) {
                 return checkStringRevert;
            }

            //GATE 3: Prefix + First + Last + suffix
            checkStringRevert=checkString;
            checkString=$"{Prefix} {FirstName} {LastName} {Suffix}";
            if (checkString.Length>charLimit) {
                 return checkStringRevert;
            }
            //GATE 4: Prefix + First + Middle Initials + Last + suffix
            checkStringRevert=checkString;
            checkString=$"{Prefix} {FirstName} {MiddleNames.Select(f=>f.Substring(0,1)).Aggregate((f,g)=>f+" "+g)} {LastName} {Suffix}";
            if (checkString.Length>charLimit) {
                 return checkStringRevert;
            }

            //GATE 5: GET ALL THE THINGS!
            checkStringRevert=checkString;
            checkString = FullName();
            if (checkString.Length>charLimit) { 
                 return checkStringRevert;
            }
            return checkString;
        }

        public string FullName()
        {
            return $"{Prefix} {FirstName} {MiddleNames.Aggregate((f,g)=>f+" "+g)} {LastName} {Suffix}";
        }

        public EnglishGenderPronouns GenderPronouns { get; set; }

        private string _knownName;
        public string KnownName
        {
            get { return _knownName; }
            set { _knownName = value; }
        }
    }
}

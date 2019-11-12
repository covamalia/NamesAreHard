namespace NamesAreHard
{
    public class EnglishGenderPronouns : IGenderPronouns
    {
        public string Ie { get; set; } // he,she,ze
        public string Im { get; set; } // him,her,zim
        public string Ir { get; set; } // his,her,zir
        public string Irs { get; set; } // his,hers,zis
        public string Self { get; set; } // himself,herself,zieself
        public string PronounList()
        {
            return $"{Ie}/{Im}/{Ir}/{Irs}/{Self}";
        }
    }
}
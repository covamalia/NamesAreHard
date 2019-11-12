namespace NamesAreHard
{
    public interface IName {
        string FullName(); //there will always be a full and definitive version of a name. this is it
        string KnownName { get; set; } //how the person is identified day-to-day, eg their first name, short version of first name, goes by middle name
        string DisplayName(int charLimit); //display name when there is a character limit. Will find the most characters that can be displayed based on logical naming convention
    }
}
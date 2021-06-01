using System.ComponentModel;

namespace Model.DBLogic
{
    public class PropChangedEventArgs : PropertyChangedEventArgs
    {
        public string Tekst { get; set; }
        public PropChangedEventArgs(string propertyName) : base(propertyName)
        {
            
        }
    }
}
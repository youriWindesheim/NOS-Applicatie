namespace Model.Model_Medewerker
{
    public class Medewerker
    {
        public int Personeelsnummer { get; private set; }
        public Medewerker(int personeelsnummer)
        {
            this.Personeelsnummer = personeelsnummer;
        }
    }
}
namespace BillettSystem.Models
{
    public class Passasjer
    {
        public string Name { get; set; }
        public string EtterNavn { get; set; }
        public string Epost { get; set; }
        public string Adresse { get; set; }
        public bool Voksen { get; set; }
        public int AntallBagasje { get; set; }
    }
}
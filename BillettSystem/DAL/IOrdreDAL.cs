using BillettSysModel;

namespace DAL
{
    public interface IOrdreDAL
    {
        Passasjer GetKunde(int passasjerId);
        OrdreDetaljer GetOrdreDetaljer(int ordreId);
        OrdreListe GetOrdrerFraDb();
        bool KansellerOrdre(int ordreId);
        bool SaveKundeEndringer(Passasjer kunde);
        bool UpdateOrdreDetaljer(OrdreDetaljer model);
    }
}
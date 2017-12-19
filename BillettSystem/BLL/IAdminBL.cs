using System.Collections.Generic;
using BillettSysModel;

namespace BLL
{
    public interface IAdminBL
    {
        bool DeleteFlyrute(int flyruteId);
        List<Flyrute> FinnTilgjengeligeFly(string fra, string til, int passasjerer);
        Flyrute GetFlyrute(int flyRuteId);
        FlyruteListe GetFlyruteListe();
        Passasjer GetKunde(int passasjerId);
        OrdreDetaljer GetOrdreDetaljer(int ordreId);
        OrdreListe GetOrdreListe();
        bool KansellerOrdre(int ordreId);
        bool SaveFlyrute(Flyrute flyruteModel);
        object SaveKundeEndringer(Passasjer kunde);
        bool UpdateOrdreDetaljer(OrdreDetaljer ordreDetaljer);
    }
}
using System.Collections.Generic;
using BillettSysModel;

namespace DAL
{
    public interface IFlyruteDAL
    {
        bool CreateFlyrute(Flyrute model);
        bool DeleteFlyRute(int flyruteId);
        List<Flyrute> FinnTilgjengeligeFly(string fra, string til, int passasjererCount);
        Flyrute GetFlyRuteFraDB(int flyRuteId);
        FlyruteListe GetRuterFraDB();
        bool UpdateFlyrute(Flyrute model);
    }
}
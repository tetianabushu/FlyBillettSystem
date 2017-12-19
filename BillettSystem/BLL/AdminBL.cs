using BillettSysModel;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class AdminBL : IAdminBL
    {
        private IFlyruteDAL _flyruteDAL;
        private IOrdreDAL _ordreDAL;
        public AdminBL()
        {
            _flyruteDAL = new FlyruteDAL();
            _ordreDAL = new OrdreDAL();
        }
        public AdminBL(IFlyruteDAL flyruteDAL, IOrdreDAL ordreDAL)
        {
            _flyruteDAL = flyruteDAL;
            _ordreDAL = ordreDAL;
        }

        public FlyruteListe GetFlyruteListe()
        {
            FlyruteListe listefraDb = _flyruteDAL.GetRuterFraDB();
            return listefraDb;
        }

        public Flyrute GetFlyrute(int flyRuteId)
        {
            Flyrute flyrute = _flyruteDAL.GetFlyRuteFraDB(flyRuteId);
            return flyrute;
        }

        public OrdreListe GetOrdreListe()
        {
            OrdreListe ordrerfraDb = _ordreDAL.GetOrdrerFraDb();
            return ordrerfraDb;
        }

        public OrdreDetaljer GetOrdreDetaljer(int ordreId)
        {
            OrdreDetaljer ordreDetaljer = _ordreDAL.GetOrdreDetaljer(ordreId);
            return ordreDetaljer;
        }

        public bool DeleteFlyrute(int flyruteId)
        {
            return _flyruteDAL.DeleteFlyRute(flyruteId);
        }

        public bool SaveFlyrute(Flyrute flyruteModel)
        {
            if (flyruteModel.Id == 0)
            {
                return _flyruteDAL.CreateFlyrute(flyruteModel);
            }
            else
            {
                return _flyruteDAL.UpdateFlyrute(flyruteModel);
            }                
        }

        public Passasjer GetKunde(int passasjerId)
        {
            return _ordreDAL.GetKunde(passasjerId);
        }

        public bool KansellerOrdre(int ordreId)
        {
            return _ordreDAL.KansellerOrdre(ordreId);
        }

        public object SaveKundeEndringer(Passasjer kunde)
        {
            return _ordreDAL.SaveKundeEndringer(kunde);
        }

        public bool UpdateOrdreDetaljer(OrdreDetaljer ordreDetaljer)
        {
            return _ordreDAL.UpdateOrdreDetaljer(ordreDetaljer);
        }

        public List<Flyrute> FinnTilgjengeligeFly(string fra, string til, int passasjerer)
        {
            return _flyruteDAL.FinnTilgjengeligeFly(fra, til, passasjerer);
        }
    }
}

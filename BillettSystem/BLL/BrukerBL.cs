using BillettSysModel;
using DAL;

namespace BLL
{
    public class BrukerBL
    {
        public bool VerifiserBrukerIdb(BrukerModel brukerFraView)
        {
            var brukerDal = new BrukerDAL();
            var result = brukerDal.VerifiserBrukerIdb(brukerFraView);
            return result;
        }
    }
}

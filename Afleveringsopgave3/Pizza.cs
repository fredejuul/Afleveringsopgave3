using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Afleveringsopgave3.Constants;

namespace Afleveringsopgave3
{
    class RejerMedTun
    {
        public const int prisAlm = 64;
        public const int ekstraLoeg = 5;
        public const int ekstraRejer = 10;
        public const int ekstraTun = 7;
        public const int KalorierAlm = 231;
        public const double KalorierFam = KalorierAlm * almTilFam;
        public const double prisFam = prisAlm * almTilFam;

        public int GetPriceAlm(int alm, int loeg, int rejer, int tun)
        {
            int subtotalAlm = prisAlm * alm;
            int subLoeg = ekstraLoeg * loeg;
            int subRejer = ekstraRejer * rejer;
            int subTun = ekstraTun * tun;
            int rejerMedTunAlmSubtotal = subtotalAlm + subLoeg + subRejer + subTun;
            return rejerMedTunAlmSubtotal;
        }
        public double GetPriceFam(int fam, int loeg, int rejer, int tun)
        {
            double subtotalFam = prisFam * fam;
            double subLoeg = ekstraLoeg * loeg * almTilFam;
            double subRejer = ekstraRejer * rejer * almTilFam;
            double subTun = ekstraTun * tun * almTilFam;
            double rejerMedTunFamSubtotal = subtotalFam + subLoeg + subRejer + subTun;
            return rejerMedTunFamSubtotal;
        }
    }

    class Pepperoni
    {
        public const int pepperoniAlmPris = 59;
        public const int ekstraPepperoni = 8;
        public const int ekstraChampignon = 11;
        public const int ekstraOst = 6;
        public const int KalorierAlm = 253;
        public const double KalorierFam = KalorierAlm * almTilFam;
        public const double pepperoniFamPris = pepperoniAlmPris * almTilFam;

        public int GetPriceAlm(int alm, int pep, int cham, int ost)
        {
            int subtotalAlm = pepperoniAlmPris * alm;
            int subPep = ekstraPepperoni * pep;
            int subCham = ekstraChampignon * cham;
            int subOst = ekstraOst * ost;
            int pepperoniAlmSubtotal = subtotalAlm + subPep + subCham + subOst;
            return pepperoniAlmSubtotal;
        }
        public double GetPriceFam(int fam, int pep, int cham, int ost)
        {
            double subtotalFam = pepperoniFamPris * fam;
            double subPep = ekstraPepperoni * pep * almTilFam;
            double subCham = ekstraChampignon * cham * almTilFam;
            double subOst = ekstraOst * ost * almTilFam;
            double pepperoniFamSubtotal = subtotalFam + subPep + subCham + subOst;
            return pepperoniFamSubtotal;
        }
    }

    public static class Constants
    {
        public const double almTilFam = 1.5;
    }
}

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
            int rejerMedTunSubtotal = subtotalAlm + subLoeg + subRejer + subTun;
            return rejerMedTunSubtotal;
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
    }

    public static class Constants
    {
        public const double almTilFam = 1.5;
    }
}

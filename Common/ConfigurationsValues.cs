using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FeeSettings
    {
        public double CommonBuyerFeeMinValue { get; set; }
        public double CommonBuyerFeeMaxValue { get; set; }
        public double LuxuryBuyerFeeMinValue { get; set; }
        public double LuxuryBuyerFeeMaxValue { get; set; }
        public double CommonSellerFeePercent { get; set; }
        public double LuxurySellerFeePercent { get; set; }
        public double Association1And500 { get; set; }
        public double Association500And1000 { get; set; }
        public double Association1000And3000 { get; set; }
        public double AssociationOver3000 { get; set; }
        public double FixedFee { get; set; }
        public double BuyerFeePercent { get; set; }
    }
}

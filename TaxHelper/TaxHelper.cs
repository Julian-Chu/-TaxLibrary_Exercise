using System.Collections.Generic;
using System.Linq;

namespace TaxLib
{
    public class TaxHelper
    {
        public static decimal GetTaxResult(decimal income) {
            var levels = TaxLevelsGenerator.getTaxTable(
                new List<int>() { 540000, 1210000, 2420000, 4530000, 10310000, int.MaxValue },
                new List<decimal>() { 0.05m, 0.12m, 0.2m, 0.3m, 0.4m, 0.5m }
                );

            var result = 0m;
            for (int i = 0; i < levels.Count; i++) {
                var lastLevelUpper = i == 0 ? 0 : levels[i - 1].upper;
                if (income > levels[i].upper)
                    result += (levels[i].upper - lastLevelUpper) * levels[i].rate;
                else {
                    result += (income - lastLevelUpper) * levels[i].rate;
                    break;
                }
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxLib
{
    public class TaxLevelsGenerator {

        public static List<TaxLevel> getTaxTable(List<int> uppers, List<decimal> rates) {
            var table = new List<TaxLevel>();
            for (int i = 0; i < rates.Count; i++) {
                table.Add(new TaxLevel()
                {
                    upper = uppers[i],
                    rate = rates[i]
                });
            }
            return table;
        }
    }

    public class TaxLevel{
        public int upper { get; set; }
        public decimal rate { get; set; }
    }

}

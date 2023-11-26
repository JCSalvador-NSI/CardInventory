using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventory.Enum
{
    public enum CardFormat
    {
        [Description("TCG-EN")]
        TCG = 1,

        [Description("OCG-JP")]
        OCG = 2,

        [Description("OCG-AE")]
        OCG_AsianEnglish = 3,
    }
}

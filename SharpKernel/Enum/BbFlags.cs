using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKernel.Enum
{
    [Flags]
    public enum BbFlags : byte //Blur Behind Flags
    {
        DwmBbEnable = 1,
        DwmBbBlurregion = 2,
        DwmBbTransitiononmaximized = 4,
    }
}

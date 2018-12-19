using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpKernel.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_COLORIZATION_PARAMS
    {
        public int clrColor;
        public int clrAfterGlow;
        public int nIntensity;
        public int clrAfterGlowBalance;
        public int clrBlurBalance;
        public int clrGlassReflectionIntensity;
        public bool fOpaque;
    }
}

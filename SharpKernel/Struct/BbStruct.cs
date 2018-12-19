using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpKernel.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BbStruct //Blur Behind Structure
    {
        public LIBFLAGS Flags;
        public bool Enable;
        public IntPtr Region;
        public bool TransitionOnMaximized;
    }
}

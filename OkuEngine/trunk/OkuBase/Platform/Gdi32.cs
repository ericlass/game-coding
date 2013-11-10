using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace OkuBase.Platform
{
  public static class Gdi32
  {
    public const int ANSI_CHARSET = 0;
    public const int ANTIALIASED_QUALITY = 4;
    public const int CLEARTYPE_NATURAL_QUALITY = 6;
    public const int CLEARTYPE_QUALITY = 5;
    public const int CLIP_DEFAULT_PRECIS = 0;
    public const int DEFAULT_CHARSET = 1;
    public const int DEFAULT_PITCH = 0;
    public const int DEFAULT_QUALITY = 0;
    public const int DM_BITSPERPEL = 262144;
    public const int DM_DISPLAYFLAGS = 2097152;
    public const int DM_DISPLAYFREQUENCY = 4194304;
    public const int DM_PELSHEIGHT = 1048576;
    public const int DM_PELSWIDTH = 524288;
    public const int DRAFT_QUALITY = 1;
    public const int FF_DONTCARE = 0;
    public const int FIXED_PITCH = 1;
    public const int FW_BOLD = 700;
    public const int LPD_DOUBLEBUFFER = 1;
    public const int LPD_SHARE_ACCUM = 256;
    public const int LPD_SHARE_DEPTH = 64;
    public const int LPD_SHARE_STENCIL = 128;
    public const int LPD_STEREO = 2;
    public const int LPD_SUPPORT_GDI = 16;
    public const int LPD_SUPPORT_OPENGL = 32;
    public const int LPD_SWAP_COPY = 1024;
    public const int LPD_SWAP_EXCHANGE = 512;
    public const int LPD_TRANSPARENT = 4096;
    public const int LPD_TYPE_COLORINDEX = 1;
    public const int LPD_TYPE_RGBA = 0;
    public const int MONO_FONT = 8;
    public const int NONANTIALIASED_QUALITY = 3;
    public const int OUT_TT_PRECIS = 4;
    public const int PFD_DEPTH_DONTCARE = 536870912;
    public const int PFD_DOUBLEBUFFER = 1;
    public const int PFD_DOUBLEBUFFER_DONTCARE = 1073741824;
    public const int PFD_DRAW_TO_BITMAP = 8;
    public const int PFD_DRAW_TO_WINDOW = 4;
    public const int PFD_GENERIC_ACCELERATED = 4096;
    public const int PFD_GENERIC_FORMAT = 64;
    public const int PFD_MAIN_PLANE = 0;
    public const int PFD_NEED_PALETTE = 128;
    public const int PFD_NEED_SYSTEM_PALETTE = 256;
    public const int PFD_OVERLAY_PLANE = 1;
    public const int PFD_STEREO = 2;
    public const int PFD_STEREO_DONTCARE = -2147483648;
    public const int PFD_SUPPORT_DIRECTDRAW = 8192;
    public const int PFD_SUPPORT_GDI = 16;
    public const int PFD_SUPPORT_OPENGL = 32;
    public const int PFD_SWAP_COPY = 1024;
    public const int PFD_SWAP_EXCHANGE = 512;
    public const int PFD_SWAP_LAYER_BUFFERS = 2048;
    public const int PFD_TYPE_COLORINDEX = 1;
    public const int PFD_TYPE_RGBA = 0;
    public const int PFD_UNDERLAY_PLANE = -1;
    public const int PROOF_QUALITY = 2;
    public const int SHIFTJIS_CHARSET = 128;
    public const int SYMBOL_CHARSET = 2;
    public const int VARIABLE_PITCH = 2;

    [StructLayout(LayoutKind.Sequential)]
    public struct PIXELFORMATDESCRIPTOR
    {
      public ushort nSize;
      public ushort nVersion;
      public uint dwFlags;
      public byte iPixelType;
      public byte cColorBits;
      public byte cRedBits;
      public byte cRedShift;
      public byte cGreenBits;
      public byte cGreenShift;
      public byte cBlueBits;
      public byte cBlueShift;
      public byte cAlphaBits;
      public byte cAlphaShift;
      public byte cAccumBits;
      public byte cAccumRedBits;
      public byte cAccumGreenBits;
      public byte cAccumBlueBits;
      public byte cAccumAlphaBits;
      public byte cDepthBits;
      public byte cStencilBits;
      public byte cAuxBuffers;
      public byte iLayerType;
      public byte bReserved;
      public uint dwLayerMask;
      public uint dwVisibleMask;
      public uint dwDamageMask;
    }

    [DllImport("gdi32.dll")]
    public static extern int ChoosePixelFormat(IntPtr hdc, [In] ref PIXELFORMATDESCRIPTOR ppfd);

    [DllImport("gdi32.dll")]
    public static extern bool SetPixelFormat(IntPtr hdc, int iPixelFormat, ref PIXELFORMATDESCRIPTOR ppfd);

    [DllImport("gdi32.dll")]
    public static extern bool SwapBuffers(IntPtr hdc);

  }
}

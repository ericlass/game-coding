using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OkuEngine.Rendering
{
  /// <summary>
  /// Handles getting and setting display modes.
  /// </summary>
  public class Display
  {
    #region Interop

    struct POINTL
    {
      public Int32 x;
      public Int32 y;
    }

    [Flags()]
    enum DM : int
    {
      Orientation = 0x1,
      PaperSize = 0x2,
      PaperLength = 0x4,
      PaperWidth = 0x8,
      Scale = 0x10,
      Position = 0x20,
      NUP = 0x40,
      DisplayOrientation = 0x80,
      Copies = 0x100,
      DefaultSource = 0x200,
      PrintQuality = 0x400,
      Color = 0x800,
      Duplex = 0x1000,
      YResolution = 0x2000,
      TTOption = 0x4000,
      Collate = 0x8000,
      FormName = 0x10000,
      LogPixels = 0x20000,
      BitsPerPixel = 0x40000,
      PelsWidth = 0x80000,
      PelsHeight = 0x100000,
      DisplayFlags = 0x200000,
      DisplayFrequency = 0x400000,
      ICMMethod = 0x800000,
      ICMIntent = 0x1000000,
      MediaType = 0x2000000,
      DitherType = 0x4000000,
      PanningWidth = 0x8000000,
      PanningHeight = 0x10000000,
      DisplayFixedOutput = 0x20000000
    }

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    struct DEVMODE
    {
      public const int CCHDEVICENAME = 32;
      public const int CCHFORMNAME = 32;

      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
      [System.Runtime.InteropServices.FieldOffset(0)]
      public string dmDeviceName;
      [System.Runtime.InteropServices.FieldOffset(32)]
      public Int16 dmSpecVersion;
      [System.Runtime.InteropServices.FieldOffset(34)]
      public Int16 dmDriverVersion;
      [System.Runtime.InteropServices.FieldOffset(36)]
      public Int16 dmSize;
      [System.Runtime.InteropServices.FieldOffset(38)]
      public Int16 dmDriverExtra;
      [System.Runtime.InteropServices.FieldOffset(40)]
      public DM dmFields;

      [System.Runtime.InteropServices.FieldOffset(44)]
      Int16 dmOrientation;
      [System.Runtime.InteropServices.FieldOffset(46)]
      Int16 dmPaperSize;
      [System.Runtime.InteropServices.FieldOffset(48)]
      Int16 dmPaperLength;
      [System.Runtime.InteropServices.FieldOffset(50)]
      Int16 dmPaperWidth;
      [System.Runtime.InteropServices.FieldOffset(52)]
      Int16 dmScale;
      [System.Runtime.InteropServices.FieldOffset(54)]
      Int16 dmCopies;
      [System.Runtime.InteropServices.FieldOffset(56)]
      Int16 dmDefaultSource;
      [System.Runtime.InteropServices.FieldOffset(58)]
      Int16 dmPrintQuality;

      [System.Runtime.InteropServices.FieldOffset(44)]
      public POINTL dmPosition;
      [System.Runtime.InteropServices.FieldOffset(52)]
      public Int32 dmDisplayOrientation;
      [System.Runtime.InteropServices.FieldOffset(56)]
      public Int32 dmDisplayFixedOutput;

      [System.Runtime.InteropServices.FieldOffset(60)]
      public short dmColor;
      [System.Runtime.InteropServices.FieldOffset(62)]
      public short dmDuplex;
      [System.Runtime.InteropServices.FieldOffset(64)]
      public short dmYResolution;
      [System.Runtime.InteropServices.FieldOffset(66)]
      public short dmTTOption;
      [System.Runtime.InteropServices.FieldOffset(68)]
      public short dmCollate;
      [System.Runtime.InteropServices.FieldOffset(72)]
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
      public string dmFormName;
      [System.Runtime.InteropServices.FieldOffset(102)]
      public Int16 dmLogPixels;
      [System.Runtime.InteropServices.FieldOffset(104)]
      public Int32 dmBitsPerPel;
      [System.Runtime.InteropServices.FieldOffset(108)]
      public Int32 dmPelsWidth;
      [System.Runtime.InteropServices.FieldOffset(112)]
      public Int32 dmPelsHeight;
      [System.Runtime.InteropServices.FieldOffset(116)]
      public Int32 dmDisplayFlags;
      [System.Runtime.InteropServices.FieldOffset(116)]
      public Int32 dmNup;
      [System.Runtime.InteropServices.FieldOffset(120)]
      public Int32 dmDisplayFrequency;
    };

    [DllImport("user32.dll")]
    private static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

    [DllImport("user32.dll")]
    private static extern int ChangeDisplaySettings(ref DEVMODE devMode, int flags);

    private const int ENUM_CURRENT_SETTINGS = -1;
    private const int CDS_UPDATEREGISTRY = 0x01;
    private const int CDS_TEST = 0x02;
    private const int DISP_CHANGE_SUCCESSFUL = 0;
    private const int DISP_CHANGE_RESTART = 1;
    private const int DISP_CHANGE_FAILED = -1;
    private const int DISP_CHANGE_BADMODE = -2;

    #endregion

    private List<DisplayMode> _supportedModes = null;

    /// <summary>
    /// Creates a new display handler.
    /// </summary>
    public Display()
    {
    }

    /// <summary>
    /// Gets the display mode that is currently set.
    /// </summary>
    public DisplayMode CurrentMode
    {
      get
      {
        DEVMODE dm = new DEVMODE();
        dm.dmSize = (short)Marshal.SizeOf(dm);
        if (EnumDisplaySettings(null, -1, ref dm))
          return new DisplayMode(dm.dmPelsWidth, dm.dmPelsHeight, dm.dmDisplayFrequency, dm.dmBitsPerPel, dm.dmDisplayOrientation * 90);
        else
          return null;
      }
    }

    /// <summary>
    /// Gets all displaymodes that are supported by the current graphics device - monitor - combination.
    /// </summary>
    /// <returns>A list of all supported display modes.</returns>
    public List<DisplayMode> GetSupportedModes()
    {
      if (_supportedModes == null)
      {
        DEVMODE dm = new DEVMODE();
        dm.dmSize = (short)Marshal.SizeOf(dm);

        _supportedModes = new List<DisplayMode>();

        int mode = 0;
        while (EnumDisplaySettings(null, mode, ref dm))
        {
          _supportedModes.Add(new DisplayMode(dm.dmPelsWidth, dm.dmPelsHeight, dm.dmDisplayFrequency, dm.dmBitsPerPel, dm.dmDisplayOrientation * 90));
          mode++;
        }
      }

      return _supportedModes;
    }

    /// <summary>
    /// Sets the given display mode. Throws an exception if an error occurrs while doing so.
    /// </summary>
    /// <param name="mode">The display mode to be set.</param>
    public void SetDisplayMode(DisplayMode mode)
    {
      DEVMODE dm = new DEVMODE();
      dm.dmSize = (short)Marshal.SizeOf(dm);
      if (EnumDisplaySettings(null, -1, ref dm))
      {
        dm.dmPelsWidth = mode.Width;
        dm.dmPelsHeight = mode.Height;
        dm.dmDisplayFrequency = mode.Frequency;
        dm.dmBitsPerPel = mode.BitsPerPixel;
        dm.dmDisplayOrientation = mode.Orientation / 90;

        //Test if given mode can be set
        int ret = ChangeDisplaySettings(ref dm, CDS_TEST);
        if (ret == DISP_CHANGE_BADMODE)
          throw new Exception("OKUERR-005: The display mode \"" + mode + "\" is not supported! Only use modes returned by Display.GetSupportedModes().");
        else if (ret == DISP_CHANGE_RESTART)
          throw new Exception("OKUERR-006: Settings the display mode to \"" + mode + "\" requires a restart!");
        else if (ret != 0)
          throw new Exception("OKUERR-007: Error while setting display mode! Windows error code: " + ret + ".");

        //Really set the display mode now
        ret = ChangeDisplaySettings(ref dm, CDS_UPDATEREGISTRY);
        if (ret != 0)
          throw new Exception("OKUERR-007: Error while setting display mode! Windows error code: " + ret + ".");
      }
      else
        throw new Exception("OKUERR-004: Error while setting display mode!");
    }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Scrabble
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAY_DEVICE
    {
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        public int StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;

        public DISPLAY_DEVICE(int flags)
        {
            cb = 0;
            StateFlags = flags;
            DeviceName = new string((char)32, 32);
            DeviceString = new string((char)32, 128);
            DeviceID = new string((char)32, 128);
            DeviceKey = new string((char)32, 128);
            cb = Marshal.SizeOf(this);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DEVMODE
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;
        public short dmSpecVersion;
        public short dmDriverVersion;
        public short dmSize;
        public short dmDriverExtra;
        public int dmFields;
        public short dmOrientation;
        public short dmPaperSize;
        public short dmPaperLength;
        public short dmPaperWidth;
        public short dmScale;
        public short dmCopies;
        public short dmDefaultSource;
        public short dmPrintQuality;
        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;
        public short dmUnusedPadding;
        public short dmBitsPerPel;
        public int dmPelsWidth;
        public int dmPelsHeight;
        public int dmDisplayFlags;
        public int dmDisplayFrequency;
    }

    public class DisplaySettings
    {        

        public DisplaySettings()
        {
            GetCurrentMode();

        }

        private void GetCurrentMode()
        {
        }

        public DEVMODE GetDevmodeFor(int devNum, int width,int height)
        {
            DEVMODE current = GetCurrentSettings(devNum);
            string devName = GetDeviceName(devNum);
            DEVMODE devMode = new DEVMODE();
            int modeNum = 0;
            bool result = true;
            do
            {
                result = EnumDisplaySettings(devName,
                    modeNum, ref devMode);

                if (result)
                {   
                    if(devMode.dmPelsWidth==width && devMode.dmPelsHeight==height && devMode.dmBitsPerPel==current.dmBitsPerPel)
                    {
                        return devMode;
                    }
                }
                modeNum++;
            } while (result);
            return current;
        }
        public DEVMODE GetDevmode(int devNum, int modeNum)
        { //populates DEVMODE for the specified device and mode
            DEVMODE devMode = new DEVMODE();
            string devName = GetDeviceName(devNum);
            EnumDisplaySettings(devName, modeNum, ref devMode);
            return devMode;
        }

        public string DevmodeToString(DEVMODE devMode)
        {
            return devMode.dmPelsWidth.ToString() +
                " x " + devMode.dmPelsHeight.ToString() +
                ", " + devMode.dmBitsPerPel.ToString() +
                " bits, " +
                devMode.dmDisplayFrequency.ToString() + " Hz";
        }

        public string GetDeviceName(int devNum)
        {
            DISPLAY_DEVICE d = new DISPLAY_DEVICE(0);
            bool result = EnumDisplayDevices(IntPtr.Zero,
                devNum, ref d, 0);
            return (result ? d.DeviceName.Trim() : "#error#");
        }

        public bool MainDevice(int devNum)
        { //whether the specified device is the main device
            DISPLAY_DEVICE d = new DISPLAY_DEVICE(0);
            if (EnumDisplayDevices(IntPtr.Zero, devNum, ref d, 0))
            {
                return ((d.StateFlags & 4) != 0);
            } return false;
        }

        public DEVMODE GetCurrentSettings(int devNum)
        {
            return GetDevmode(devNum, -1); 
        }
 
        [DllImport("User32.dll")]
        private static extern bool EnumDisplayDevices(
            IntPtr lpDevice, int iDevNum,
            ref DISPLAY_DEVICE lpDisplayDevice, int dwFlags);

        [DllImport("User32.dll")]
        private static extern bool EnumDisplaySettings(
            string devName, int modeNum, ref DEVMODE devMode);

        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings(
            ref DEVMODE devMode, int flags);

    }
}

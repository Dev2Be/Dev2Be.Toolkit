using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Dev2Be.Toolkit
{
    public static class SystemIcons
    {
        public static BitmapSource GetBitmapSource(StockIconIdentifier identifier) => StockIcon.GetBitmapSource(identifier, 0);

        public static BitmapSource DocumentNotAssociated { get { return GetBitmapSource(StockIconIdentifier.DocumentNotAssociated); } }
        public static BitmapSource DocumentAssociated { get { return GetBitmapSource(StockIconIdentifier.DocumentAssociated); } }
        public static BitmapSource Application { get { return GetBitmapSource(StockIconIdentifier.Application); } }
        public static BitmapSource Folder { get { return GetBitmapSource(StockIconIdentifier.Folder); } }
        public static BitmapSource FolderOpen { get { return GetBitmapSource(StockIconIdentifier.FolderOpen); } }
        public static BitmapSource Drive525 { get { return GetBitmapSource(StockIconIdentifier.Drive525); } }
        public static BitmapSource Drive35 { get { return GetBitmapSource(StockIconIdentifier.Drive35); } }
        public static BitmapSource DriveRemove { get { return GetBitmapSource(StockIconIdentifier.DriveRemove); } }
        public static BitmapSource DriveFixed { get { return GetBitmapSource(StockIconIdentifier.DriveFixed); } }
        public static BitmapSource DriveNetwork { get { return GetBitmapSource(StockIconIdentifier.DriveNetwork); } }
        public static BitmapSource DriveNetworkDisabled { get { return GetBitmapSource(StockIconIdentifier.DriveNetworkDisabled); } }
        public static BitmapSource DriveCD { get { return GetBitmapSource(StockIconIdentifier.DriveCD); } }
        public static BitmapSource DriveRAM { get { return GetBitmapSource(StockIconIdentifier.DriveRAM); } }
        public static BitmapSource World { get { return GetBitmapSource(StockIconIdentifier.World); } }
        public static BitmapSource Server { get { return GetBitmapSource(StockIconIdentifier.Server); } }
        public static BitmapSource Printer { get { return GetBitmapSource(StockIconIdentifier.Printer); } }
        public static BitmapSource MyNetwork { get { return GetBitmapSource(StockIconIdentifier.MyNetwork); } }
        public static BitmapSource Find { get { return GetBitmapSource(StockIconIdentifier.Find); } }
        public static BitmapSource Help { get { return GetBitmapSource(StockIconIdentifier.Help); } }
        public static BitmapSource Share { get { return GetBitmapSource(StockIconIdentifier.Share); } }
        public static BitmapSource Link { get { return GetBitmapSource(StockIconIdentifier.Link); } }
        public static BitmapSource SlowFile { get { return GetBitmapSource(StockIconIdentifier.SlowFile); } }
        public static BitmapSource Recycler { get { return GetBitmapSource(StockIconIdentifier.Recycler); } }
        public static BitmapSource RecyclerFull { get { return GetBitmapSource(StockIconIdentifier.RecyclerFull); } }
        public static BitmapSource MediaCDAudio { get { return GetBitmapSource(StockIconIdentifier.MediaCDAudio); } }
        public static BitmapSource Lock { get { return GetBitmapSource(StockIconIdentifier.Lock); } }
        public static BitmapSource AutoList { get { return GetBitmapSource(StockIconIdentifier.AutoList); } }
        public static BitmapSource PrinterNet { get { return GetBitmapSource(StockIconIdentifier.PrinterNet); } }
        public static BitmapSource ServerShare { get { return GetBitmapSource(StockIconIdentifier.ServerShare); } }
        public static BitmapSource PrinterFax { get { return GetBitmapSource(StockIconIdentifier.PrinterFax); } }
        public static BitmapSource PrinterFaxNet { get { return GetBitmapSource(StockIconIdentifier.PrinterFaxNet); } }
        public static BitmapSource PrinterFile { get { return GetBitmapSource(StockIconIdentifier.PrinterFile); } }
        public static BitmapSource Stack { get { return GetBitmapSource(StockIconIdentifier.Stack); } }
        public static BitmapSource MediaSVCD { get { return GetBitmapSource(StockIconIdentifier.MediaSVCD); } }
        public static BitmapSource StuffedFolder { get { return GetBitmapSource(StockIconIdentifier.StuffedFolder); } }
        public static BitmapSource DriveUnknown { get { return GetBitmapSource(StockIconIdentifier.DriveUnknown); } }
        public static BitmapSource DriveDVD { get { return GetBitmapSource(StockIconIdentifier.DriveDVD); } }
        public static BitmapSource MediaDVD { get { return GetBitmapSource(StockIconIdentifier.MediaDVD); } }
        public static BitmapSource MediaDVDRAM { get { return GetBitmapSource(StockIconIdentifier.MediaDVDRAM); } }
        public static BitmapSource MediaDVDRW { get { return GetBitmapSource(StockIconIdentifier.MediaDVDRW); } }
        public static BitmapSource MediaDVDR { get { return GetBitmapSource(StockIconIdentifier.MediaDVDR); } }
        public static BitmapSource MediaDVDROM { get { return GetBitmapSource(StockIconIdentifier.MediaDVDROM); } }
        public static BitmapSource MediaCDAudioPlus { get { return GetBitmapSource(StockIconIdentifier.MediaCDAudioPlus); } }
        public static BitmapSource MediaCDRW { get { return GetBitmapSource(StockIconIdentifier.MediaCDRW); } }
        public static BitmapSource MediaCDR { get { return GetBitmapSource(StockIconIdentifier.MediaCDR); } }
        public static BitmapSource MediaCDBurn { get { return GetBitmapSource(StockIconIdentifier.MediaCDBurn); } }
        public static BitmapSource MediaBlankCD { get { return GetBitmapSource(StockIconIdentifier.MediaBlankCD); } }
        public static BitmapSource MediaCDROM { get { return GetBitmapSource(StockIconIdentifier.MediaCDROM); } }
        public static BitmapSource AudioFiles { get { return GetBitmapSource(StockIconIdentifier.AudioFiles); } }
        public static BitmapSource ImageFiles { get { return GetBitmapSource(StockIconIdentifier.ImageFiles); } }
        public static BitmapSource VideoFiles { get { return GetBitmapSource(StockIconIdentifier.VideoFiles); } }
        public static BitmapSource MixedFiles { get { return GetBitmapSource(StockIconIdentifier.MixedFiles); } }
        public static BitmapSource FolderBack { get { return GetBitmapSource(StockIconIdentifier.FolderBack); } }
        public static BitmapSource FolderFront { get { return GetBitmapSource(StockIconIdentifier.FolderFront); } }
        public static BitmapSource Shield { get { return GetBitmapSource(StockIconIdentifier.Shield); } }
        public static BitmapSource Warning { get { return GetBitmapSource(StockIconIdentifier.Warning); } }
        public static BitmapSource Info { get { return GetBitmapSource(StockIconIdentifier.Info); } }
        public static BitmapSource Error { get { return GetBitmapSource(StockIconIdentifier.Error); } }
        public static BitmapSource Key { get { return GetBitmapSource(StockIconIdentifier.Key); } }
        public static BitmapSource Software { get { return GetBitmapSource(StockIconIdentifier.Software); } }
        public static BitmapSource Rename { get { return GetBitmapSource(StockIconIdentifier.Rename); } }
        public static BitmapSource Delete { get { return GetBitmapSource(StockIconIdentifier.Delete); } }
        public static BitmapSource MediaAudioDVD { get { return GetBitmapSource(StockIconIdentifier.MediaAudioDVD); } }
        public static BitmapSource MediaMovieDVD { get { return GetBitmapSource(StockIconIdentifier.MediaMovieDVD); } }
        public static BitmapSource MediaEnhancedCD { get { return GetBitmapSource(StockIconIdentifier.MediaEnhancedCD); } }
        public static BitmapSource MediaEnhancedDVD { get { return GetBitmapSource(StockIconIdentifier.MediaEnhancedDVD); } }
        public static BitmapSource MediaHDDVD { get { return GetBitmapSource(StockIconIdentifier.MediaHDDVD); } }
        public static BitmapSource MediaBluRay { get { return GetBitmapSource(StockIconIdentifier.MediaBluRay); } }
        public static BitmapSource MediaVCD { get { return GetBitmapSource(StockIconIdentifier.MediaVCD); } }
        public static BitmapSource MediaDVDPlusR { get { return GetBitmapSource(StockIconIdentifier.MediaDVDPlusR); } }
        public static BitmapSource MediaDVDPlusRW { get { return GetBitmapSource(StockIconIdentifier.MediaDVDPlusRW); } }
        public static BitmapSource DesktopPC { get { return GetBitmapSource(StockIconIdentifier.DesktopPC); } }
        public static BitmapSource MobilePC { get { return GetBitmapSource(StockIconIdentifier.MobilePC); } }
        public static BitmapSource Users { get { return GetBitmapSource(StockIconIdentifier.Users); } }
        public static BitmapSource MediaSmartMedia { get { return GetBitmapSource(StockIconIdentifier.MediaSmartMedia); } }
        public static BitmapSource MediaCompactFlash { get { return GetBitmapSource(StockIconIdentifier.MediaCompactFlash); } }
        public static BitmapSource DeviceCellPhone { get { return GetBitmapSource(StockIconIdentifier.DeviceCellPhone); } }
        public static BitmapSource DeviceCamera { get { return GetBitmapSource(StockIconIdentifier.DeviceCamera); } }
        public static BitmapSource DeviceVideoCamera { get { return GetBitmapSource(StockIconIdentifier.DeviceVideoCamera); } }
        public static BitmapSource DeviceAudioPlayer { get { return GetBitmapSource(StockIconIdentifier.DeviceAudioPlayer); } }
        public static BitmapSource NetworkConnect { get { return GetBitmapSource(StockIconIdentifier.NetworkConnect); } }
        public static BitmapSource Internet { get { return GetBitmapSource(StockIconIdentifier.Internet); } }
        public static BitmapSource ZipFile { get { return GetBitmapSource(StockIconIdentifier.ZipFile); } }
        public static BitmapSource Settings { get { return GetBitmapSource(StockIconIdentifier.Settings); } }
    }

    public class StockIcon : MarkupExtension
    {
        StockIconIdentifier stockIconIdentifier;

        StockIconOptions stockIconOptions;

        BitmapSource bitmapSource = null;

        public StockIcon(StockIconIdentifier identifier) : this(identifier, 0) { }

        public StockIcon(StockIconIdentifier identifier, StockIconOptions flags)
        {
            Identifier = identifier;

            Selected = (flags & StockIconOptions.Selected) == StockIconOptions.Selected;

            LinkOverlay = (flags & StockIconOptions.LinkOverlay) == StockIconOptions.LinkOverlay;

            ShellSize = (flags & StockIconOptions.ShellSize) == StockIconOptions.ShellSize;

            Small = (flags & StockIconOptions.Small) == StockIconOptions.Small;
        }

        protected void Check()
        {
            if (bitmapSource != null)
                throw new InvalidOperationException("The BitmapSource has already been created");
        }

        public bool Selected
        {
            get { return (stockIconOptions & StockIconOptions.Selected) == StockIconOptions.Selected; }

            set
            {
                Check();

                if (value)
                    stockIconOptions |= StockIconOptions.Selected;
                else
                    stockIconOptions &= ~StockIconOptions.Selected;
            }
        }

        public bool LinkOverlay
        {
            get { return (stockIconOptions & StockIconOptions.LinkOverlay) == StockIconOptions.LinkOverlay; }

            set
            {
                Check();

                if (value)
                    stockIconOptions |= StockIconOptions.LinkOverlay;
                else
                    stockIconOptions &= ~StockIconOptions.LinkOverlay;
            }
        }

        public bool ShellSize
        {
            get { return (stockIconOptions & StockIconOptions.ShellSize) == StockIconOptions.ShellSize; }

            set
            {
                Check();

                if (value)
                    stockIconOptions |= StockIconOptions.ShellSize;
                else
                    stockIconOptions &= ~StockIconOptions.ShellSize;
            }
        }

        public bool Small
        {

            get { return (stockIconOptions & StockIconOptions.Small) == StockIconOptions.Small; }

            set
            {
                Check();

                if (value)
                    stockIconOptions |= StockIconOptions.Small;
                else
                    stockIconOptions &= ~StockIconOptions.Small;
            }
        }

        public StockIconIdentifier Identifier
        {
            get { return stockIconIdentifier; }

            set
            {
                Check();

                stockIconIdentifier = value;
            }
        }

        public override Object ProvideValue(IServiceProvider serviceProvider)
        {
            return Bitmap;
        }

        public BitmapSource Bitmap
        {
            get
            {
                if (bitmapSource == null)
                    bitmapSource = GetBitmapSource(stockIconIdentifier, stockIconOptions);

                return bitmapSource;
            }
        }

        protected internal static BitmapSource GetBitmapSource(StockIconIdentifier identifier, StockIconOptions flags)
        {
            BitmapSource bitmapSource = (BitmapSource)InteropHelper.MakeImage(identifier, StockIconOptions.Handle | flags);

            bitmapSource.Freeze();

            return bitmapSource;
        }
    }

    [Flags]
    public enum StockIconOptions : uint
    {
        Small = 0x000000001,
        ShellSize = 0x000000004,
        Handle = 0x000000100,
        SystemIndex = 0x000004000,
        LinkOverlay = 0x000008000, 
        Selected = 0x000010000
    }

    public enum StockIconIdentifier : uint
    {
        DocumentNotAssociated = 0,
        DocumentAssociated = 1,
        Application = 2,
        Folder = 3,
        FolderOpen = 4,
        Drive525 = 5,
        Drive35 = 6,
        DriveRemove = 7,
        DriveFixed = 8,
        DriveNetwork = 9,
        DriveNetworkDisabled = 10,
        DriveCD = 11,  
        DriveRAM = 12,
        World = 13,
        Server = 15,
        Printer = 16,
        MyNetwork = 17,
        Find = 22,
        Help = 23,
        Share = 28,
        Link = 29,
        SlowFile = 30,
        Recycler = 31,
        RecyclerFull = 32,
        MediaCDAudio = 40,
        Lock = 47,
        AutoList = 49,
        PrinterNet = 50,
        ServerShare = 51,
        PrinterFax = 52,
        PrinterFaxNet = 53,
        PrinterFile = 54,
        Stack = 55,
        MediaSVCD = 56,
        StuffedFolder = 57,
        DriveUnknown = 58,
        DriveDVD = 59,
        MediaDVD = 60,
        MediaDVDRAM = 61,
        MediaDVDRW = 62,
        MediaDVDR = 63,
        MediaDVDROM = 64,
        MediaCDAudioPlus = 65,
        MediaCDRW = 66,
        MediaCDR = 67,
        MediaCDBurn = 68,
        MediaBlankCD = 69,
        MediaCDROM = 70,
        AudioFiles = 71,
        ImageFiles = 72,
        VideoFiles = 73,
        MixedFiles = 74,
        FolderBack = 75,
        FolderFront = 76,
        Shield = 77,
        Warning = 78,
        Info = 79,
        Error = 80,
        Key = 81,
        Software = 82,
        Rename = 83,
        Delete = 84,
        MediaAudioDVD = 85,
        MediaMovieDVD = 86,
        MediaEnhancedCD = 87,
        MediaEnhancedDVD = 88,
        MediaHDDVD = 89,
        MediaBluRay = 90,
        MediaVCD = 91,
        MediaDVDPlusR = 92,
        MediaDVDPlusRW = 93,
        DesktopPC = 94,
        MobilePC = 95,
        Users = 96,
        MediaSmartMedia = 97,
        MediaCompactFlash = 98,
        DeviceCellPhone = 99,
        DeviceCamera = 100,
        DeviceVideoCamera = 101,
        DeviceAudioPlayer = 102,
        NetworkConnect = 103,
        Internet = 104,
        ZipFile = 105,
        Settings = 106
    }

    internal static class InteropHelper
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct StockIconInfo
        {
            internal uint StuctureSize;

            internal IntPtr Handle;

            internal uint ImageIndex;

            internal int Identifier;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]

            internal string Path;
        }

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false)]
        internal static extern int SHGetStockIconInfo(StockIconIdentifier identifier, StockIconOptions flags, ref StockIconInfo info);

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern bool DestroyIcon(IntPtr handle);

        internal static ImageSource MakeImage(StockIconIdentifier identifier, StockIconOptions flags)
        {
            IntPtr iconHandle = GetIcon(identifier, flags);

            ImageSource imageSource;

            try
            {
                imageSource = Imaging.CreateBitmapSourceFromHIcon(iconHandle, Int32Rect.Empty, null);
            }
            finally
            {
                DestroyIcon(iconHandle);
            }

            return imageSource;
        }

        internal static IntPtr GetIcon(StockIconIdentifier identifier, StockIconOptions flags)
        {
            StockIconInfo info = new StockIconInfo() { StuctureSize = (uint)Marshal.SizeOf(typeof(StockIconInfo)) };

            int hResult = SHGetStockIconInfo(identifier, flags, ref info);

            if (hResult < 0)
                throw new COMException("SHGetStockIconInfo execution failure", hResult);

            return info.Handle;
        }
    }
}
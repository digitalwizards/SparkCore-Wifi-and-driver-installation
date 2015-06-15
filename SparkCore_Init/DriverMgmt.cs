using System;
using System.Runtime.InteropServices;

namespace SparkCore_Init
{
    class DriverMgmt
    {
        enum ReenumerateFlags : uint
        {
            CM_REENUMERATE_NORMAL         = 0x00000000,
            CM_REENUMERATE_SYNCHRONOUS    = 0x00000001,
                // XP and later versions 
            CM_REENUMERATE_RETRY_INSTALLATION = 0x00000002,
            CM_REENUMERATE_ASYNCHRONOUS       = 0x00000004,
            // result
            CR_SUCCESS = 0x00000000
        }

        enum OemSourceMediaType
        {
            //No source media information is stored in the .pnf file. 
            //The value of OEMSourceMediaLocation is ignored in this case.
            SPOST_NONE = 0,
            // OEMSourceMediaLocation contains a path to the source media.
            // For example, if the media is on a floppy, this path might be "A:\". If OEMSourceMediaLocation is NULL, 
            // the path is assumed to be the path where the .inf is located. 
            // If the .inf has a corresponding .pnf in that location, the .pnf file's source media information is transferred to the destination .pnf file.
            SPOST_PATH = 1,
            // OEMSourceMediaLocation contains a universal resource locator (URL)
            // that specifies the Internet location from where the .inf/driver files were retrieved. 
            // If OEMSourceMediaLocation is NULL, it is assumed that the default Code Download Manager location was used.
            SPOST_URL = 2
        }

        enum OemCopyStyle
        {
            SP_NONE = 0x0000000,
            SP_COPY_DELETESOURCE = 0x0000001,   // delete source file on successful copy
            SP_COPY_REPLACEONLY = 0x0000002,   // copy only if target file already present
            SP_COPY_NEWER = 0x0000004,   // copy only if source newer than or same as target
            SP_COPY_NEWER_OR_SAME = SP_COPY_NEWER,
            SP_COPY_NOOVERWRITE = 0x0000008,   // copy only if target doesn't exist
            SP_COPY_NODECOMP = 0x0000010,   // don't decompress source file while copying
            SP_COPY_LANGUAGEAWARE = 0x0000020,   // don't overwrite file of different language
            SP_COPY_SOURCE_ABSOLUTE = 0x0000040,   // SourceFile is a full source path
            SP_COPY_SOURCEPATH_ABSOLUTE = 0x0000080,   // SourcePathRoot is the full path
            SP_COPY_IN_USE_NEEDS_REBOOT = 0x0000100,   // System needs reboot if file in use
            SP_COPY_FORCE_IN_USE = 0x0000200,   // Force target-in-use behavior
            SP_COPY_NOSKIP = 0x0000400,   // Skip is disallowed for this file or section
            SP_FLAG_CABINETCONTINUATION = 0x0000800,   // Used with need media notification
            SP_COPY_FORCE_NOOVERWRITE = 0x0001000,   // like NOOVERWRITE but no callback nofitication
            SP_COPY_FORCE_NEWER = 0x0002000,   // like NEWER but no callback nofitication
            SP_COPY_WARNIFSKIP = 0x0004000,   // system critical file: warn if user tries to skip
            SP_COPY_NOBROWSE = 0x0008000,   // Browsing is disallowed for this file or section
            SP_COPY_NEWER_ONLY = 0x0010000,   // copy only if source file newer than target
            SP_COPY_SOURCE_SIS_MASTER = 0x0020000,   // source is single-instance store master
            SP_COPY_OEMINF_CATALOG_ONLY = 0x0040000,   // (SetupCopyOEMInf only) don't copy INF--just catalog
            SP_COPY_REPLACE_BOOT_FILE = 0x0080000,   // file must be present upon reboot (i.e., it's needed by the loader), this flag implies a reboot
            SP_COPY_NOPRUNE = 0x0100000   // never prune this file
        }

        /// <summary>
        /// Preinstalling driver
        /// </summary>
        public static void InstallDriver(string infPath)
        {
            SetupCopyOEMInf(infPath, null, OemSourceMediaType.SPOST_PATH, OemCopyStyle.SP_NONE, null, 0, IntPtr.Zero, null);
            RescanDevices();
        }

        /// <summary>
        /// Equivalent to Device Manager's "Scan for hadrware changes"
        /// </summary>
        public static bool RescanDevices()
        {
            UInt32 devRoot;

            if (CM_Locate_DevNode_Ex(out devRoot, IntPtr.Zero, 0, IntPtr.Zero) != (uint)ReenumerateFlags.CR_SUCCESS) return false;
            if (CM_Reenumerate_DevNode_Ex(devRoot, ReenumerateFlags.CM_REENUMERATE_RETRY_INSTALLATION, IntPtr.Zero) != (uint)ReenumerateFlags.CR_SUCCESS) return false;

            return true;
        }

        // http://pinvoke.net/default.aspx/setupapi/CM_Reenumerate_DevNode_Ex.html
        [DllImport("setupapi.dll")]
        static extern UInt32 CM_Locate_DevNode_Ex(out UInt32 dnDevInst, IntPtr deviceID, 
            UInt32 ulFlags, IntPtr hMachine);
        [DllImport("setupapi.dll")]
        static extern UInt32 CM_Reenumerate_DevNode_Ex(UInt32 dnDevInst, ReenumerateFlags ulFlags, IntPtr hMachine);

        // http://pinvoke.net/default.aspx/setupapi/SetupCopyOEMInf.html
        // https://msdn.microsoft.com/en-us/library/aa376990.aspx
        [DllImport("setupapi.dll")]
        static extern bool SetupCopyOEMInf(
            string SourceInfFileName,
            string OEMSourceMediaLocation,
            OemSourceMediaType OEMSourceMediaType,
            OemCopyStyle CopyStyle,
            string DestinationInfFileName,
            int DestinationInfFileNameSize,
            IntPtr RequiredSize,
            string DestinationInfFileNameComponent
            );
    }
}

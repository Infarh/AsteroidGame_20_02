using System;
using System.IO;
using System.ServiceModel;
using FileManagerService.Interfaces;

namespace FileManagerService.Services
{
    [ServiceBehavior(
        //InstanceContextMode = InstanceContextMode.PerSession,
        //ConcurrencyMode = ConcurrencyMode.Multiple
        //AutomaticSessionShutdown = false
        IncludeExceptionDetailInFaults = true,
        MaxItemsInObjectGraph = 100000
        )]
    class FileService : IFileService
    {
        public DriveInfo[] GetDrives() => DriveInfo.GetDrives();

        public FileInfo[] GetFiles(string Path) => new DirectoryInfo(Path).GetFiles();

        public DirectoryInfo[] GetDirectories(string Path) => new DirectoryInfo(Path).GetDirectories();
    }
}

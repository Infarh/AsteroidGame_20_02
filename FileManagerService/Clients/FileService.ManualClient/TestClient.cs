using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using FileManagerService.Interfaces;

namespace FileService.ManualClient
{
    class TestClient : ClientBase<IFileService>, IFileService
    {
        public TestClient(Binding binding, EndpointAddress endpoint) : base(binding, endpoint) { }

        public DateTime GetServiceTime() => Channel.GetServiceTime();

        public DriveInfo[] GetDrives() => Channel.GetDrives();

        public FileInfo[] GetFiles(string Path) => Channel.GetFiles(Path);

        public DirectoryInfo[] GetDirectories(string Path) => GetDirectories(Path);
    }
}

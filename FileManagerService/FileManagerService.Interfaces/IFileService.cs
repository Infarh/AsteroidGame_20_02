﻿using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using FileManagerService.Interfaces.DataItems;

namespace FileManagerService.Interfaces
{
    [ServiceContract/*(SessionMode = SessionMode.Required)*/]
    public interface IFileService
    {
        [OperationContract]
        DateTime GetServiceTime();

        [OperationContract/*(Name = "Drives", IsInitiating = true, IsOneWay = true, IsTerminating = false)*/]
        DriveInfo[] GetDrives();

        [OperationContract]
        FileInfo[] GetFiles(string Path);

        [OperationContract]
        DirectoryInfo[] GetDirectories(string Path);

        //[OperationContract(IsTerminating = true, IsOneWay = true)]
        //void Disconnect();

        //[OperationContract]
        //IEnumerable<EmployyesData> GetEmployees();

        //[OperationContract(IsOneWay = true)]
        //void AddEmployee(EmployyesData Employee);
    }
}

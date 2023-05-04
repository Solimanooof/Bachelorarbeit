using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection.Metadata;
using ResultBridge.Core.Core.TestImport.Impl;
using ResultBridge.Core.Core.Windchill;
using ResultBridge.Core.Model.Import;
using ResultBridge.Core.Model.TestResults;

namespace ResultBridge.Core.Core.Controller;

//public class Controller : IController
//{


//    private string hostName { get; set; }

//    private int port { get; set; }
//    WindchillConnector WindchillConnector;
//    private TestResultImporter testResultImporter = new TestResultImporter();

//    public Controller(string hostName, int port)
//    {
//        this.hostName = hostName;
//        this.port = port;
//        WindchillConnector = new WindchillConnector(hostName, port);
//    }

//    public void ConnectToWindChill(string userName, string passWord)
//    {
//        WindchillConnector.Connect(userName, passWord);
//    }



//    public void ImportResultsToWindChill(IList<TestCase> testCases, string sesseionID)
//    {
//        bool onConnectedevent = false;
//        WindchillConnector.OnConnected += (sender, args) => onConnectedevent = true;
//        if (onConnectedevent)
//        {
//            testResultImporter.SyncResultsToWindchill(testCases, sesseionID);
//        }
//        else
//        {
//            WindchillConnector.OnCommandFailed += ((sender, args) => { });
//        }
//    }


//}
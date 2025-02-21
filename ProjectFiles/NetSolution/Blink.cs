#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.RAEtherNetIP;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
using FTOptix.NetLogic;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.DataLogger;
using FTOptix.Report;
using FTOptix.ODBCStore;
using FTOptix.Alarm;
using FTOptix.EventLogger;
using FTOptix.OPCUAServer;
using FTOptix.Recipe;
using FTOptix.AuditSigning;
#endregion

public class Blink : BaseNetLogic
{
    public override void Start()
    {
        periodicTask = new PeriodicTask(UpdateFast, 500, LogicObject);
        periodicTask.Start();

    }

    public override void Stop()
    {
        periodicTask.Dispose();
        periodicTask = null;
    }

    private void UpdateFast()
    {
        if (LogicObject.GetVariable("Blink_Fast").Value)
        {
            LogicObject.GetVariable("Blink_Fast").Value = 0;
        }
        else
        {
            LogicObject.GetVariable("Blink_Fast").Value = 1;
        }


    }

    private PeriodicTask periodicTask;
}

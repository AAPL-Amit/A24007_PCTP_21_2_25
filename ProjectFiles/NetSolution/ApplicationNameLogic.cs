#region Using directives
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.SerialPort;
using FTOptix.OPCUAClient;
using FTOptix.CODESYS;
using FTOptix.CommunicationDriver;
using FTOptix.RAEtherNetIP;
using FTOptix.MelsecFX3U;
using FTOptix.Modbus;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.DataLogger;
using FTOptix.Report;
using FTOptix.AuditSigning;
using FTOptix.ODBCStore;
using FTOptix.EventLogger;
using FTOptix.Alarm;
using FTOptix.Recipe;
using FTOptix.OPCUAServer;
#endregion

public class ApplicationNameLogic : BaseNetLogic
{
    public override void Start()
    {
        Label label = Owner as Label;
        label.Text = Project.Current.BrowseName;
    }

    public override void Stop()
    {
    }
}

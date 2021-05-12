using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchedulerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.scheduler.AppointmentEditorClosing += OnSchedulerAppointmentEditorClosing;
        }

        private void OnSchedulerAppointmentEditorClosing(object sender, AppointmentEditorClosingEventArgs e)
        {
            if (e.Action == AppointmentEditorAction.Add)
            {
                string sqlAdd = "INSERT INTO Meetings ([Subject],[StartTime],[EndTime]) VALUES('" + e.Appointment.Subject + "', '" + e.Appointment.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' , '" + e.Appointment.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                ConnectDB.ExecuteSQLQuery(sqlAdd);
            }
            else if (e.Action == AppointmentEditorAction.Delete)
            {
                string sqlDelete = "DELETE from Meetings where Subject ='" + e.Appointment.Subject + "';";
                ConnectDB.ExecuteSQLQuery(sqlDelete);
            }
            else if (e.Action == AppointmentEditorAction.Edit)
            {
                string sqlUpdate = "UPDATE Meetings set StartTime='" + e.Appointment.StartTime + "',EndTime='" + e.Appointment.EndTime + "' where Subject='" + e.Appointment.Subject + "';";
                ConnectDB.ExecuteSQLQuery(sqlUpdate);
            }
        }
    }

    public class Employee
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public Brush BackgroundColor { get; set; }

        public Brush ForegroundColor { get; set; }
    }
}

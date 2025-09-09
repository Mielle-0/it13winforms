using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using it13Project.Data;

namespace it13Project.Pages
{
    // private  lvAlerts;
    // private ListView lvReports;
    public partial class DashboardPage : UserControl
    {
        public DashboardPage()
        {
            InitializeComponent();

        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            PopulateSampleData();
        }

        private void LoadAlerts(ListView listView)
        {
            string query = "SELECT GameName, AlertMessage, AlertDate FROM Alerts ORDER BY AlertDate DESC";
            var dt = DatabaseHelper.ExecuteQuery(query);

            listView.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListViewItem(row["GameName"].ToString());
                item.SubItems.Add(row["AlertMessage"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["AlertDate"]).ToString("yyyy-MM-dd"));
                listView.Items.Add(item);
            }
        }

        private void LoadReports(ListView listView)
        {
            string query = "SELECT ReportName, Schedule FROM Reports ORDER BY Schedule ASC";
            var dt = DatabaseHelper.ExecuteQuery(query);

            listView.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListViewItem(row["ReportName"].ToString());
                item.SubItems.Add(row["Schedule"].ToString());
                listView.Items.Add(item);
            }
        }
        
        private void PopulateSampleData()
        {
            // --- Alerts List ---
            alertsListView.Items.Clear();

            var alert1 = new ListViewItem("Cyberpunk 2077");
            alert1.SubItems.Add("Players reporting crashes");
            alert1.SubItems.Add(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
            alertsListView.Items.Add(alert1);

            var alert2 = new ListViewItem("Elden Ring");
            alert2.SubItems.Add("Negative reviews about difficulty");
            alert2.SubItems.Add(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd"));
            alertsListView.Items.Add(alert2);

            var alert3 = new ListViewItem("Call of Duty");
            alert3.SubItems.Add("Server downtime complaints");
            alert3.SubItems.Add(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));
            alertsListView.Items.Add(alert3);


            // --- Reports List ---
            reportsListView.Items.Clear();

            var report1 = new ListViewItem("Weekly Sales Report");
            report1.SubItems.Add("Every Monday, 9 AM");
            reportsListView.Items.Add(report1);

            var report2 = new ListViewItem("Monthly Engagement Report");
            report2.SubItems.Add("1st of the month, 10 AM");
            reportsListView.Items.Add(report2);

            var report3 = new ListViewItem("Quarterly Financial Report");
            report3.SubItems.Add("Next: " + DateTime.Now.AddMonths(1).ToString("MMMM yyyy"));
            reportsListView.Items.Add(report3);
        }




    }
}

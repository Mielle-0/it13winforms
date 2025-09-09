using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using it13Project.UI;

namespace it13Project.Pages
{
    public partial class ReportsPage : UserControl
    {
        public ReportsPage()
        {
            InitializeComponent();

            string[] months = { "Jan", "Feb", "Mar", "Apr", "May" };
            int[] positive = { 60, 70, 65, 80, 75 };
            int[] neutral  = { 20, 15, 18, 10, 12 };
            int[] negative = { 20, 15, 17, 10, 13 };

            LoadDemoData(months, positive, neutral, negative);
        }

        public void LoadDemoData(string[] dates, int[] positiveCounts, int[] neutralCounts, int[] negativeCounts)
        {
            // === Templates ===
            cboTemplate.SelectedIndex = 0; // e.g., "Weekly"

            // === Date range ===
            dtFrom.Value = DateTime.Today.AddDays(-30);
            dtTo.Value = DateTime.Today;

            // === ScottPlot chart ===
            chartPreview.Plot.Clear();
            double[] xs = Enumerable.Range(0, dates.Length).Select(i => (double)i).ToArray();
            double[] total = positiveCounts.Zip(neutralCounts, (p, n) => p + n)
                                        .Zip(negativeCounts, (pn, neg) => pn + neg)
                                        .Select(v => (double)v)
                                        .ToArray();

            double[] posPct = positiveCounts.Zip(total, (v, t) => v / t * 100).ToArray();
            double[] neuPct = neutralCounts.Zip(total, (v, t) => v / t * 100).ToArray();
            double[] negPct = negativeCounts.Zip(total, (v, t) => v / t * 100).ToArray();

            chartPreview.Plot.Add.Scatter(xs, posPct).LegendText = "Positive";
            chartPreview.Plot.Add.Scatter(xs, neuPct).LegendText = "Neutral";
            chartPreview.Plot.Add.Scatter(xs, negPct).LegendText = "Negative";


            chartPreview.Plot.Legend.IsVisible = true;
            chartPreview.Plot.Title("Sentiment Trend (Demo)");
            chartPreview.Plot.XLabel("Days");
            chartPreview.Plot.YLabel("Sentiment Score");
            chartPreview.Refresh();

            // === Scheduled Reports Table ===
            dgvSchedules.Rows.Clear();
            dgvSchedules.Rows.Add("Weekly Sentiment", "PDF", "qa@studio.com", "Weekly", DateTime.Today.AddDays(7).ToShortDateString());
            dgvSchedules.Rows.Add("Monthly Overview", "Excel", "execs@studio.com", "Monthly", DateTime.Today.AddMonths(1).ToShortDateString());
            dgvSchedules.Rows.Add("Quarterly Report", "PDF", "stakeholders@studio.com", "Quarterly", DateTime.Today.AddMonths(3).ToShortDateString());
        }

    }
}

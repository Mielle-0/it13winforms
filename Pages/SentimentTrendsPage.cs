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
using ScottPlot;

namespace it13Project.Pages
{
    public partial class SentimentTrendsPage : UserControl
    {
        public SentimentTrendsPage()
        {
            InitializeComponent();

            string[] months = { "Jan", "Feb", "Mar", "Apr", "May" };
            int[] positive = { 60, 70, 65, 80, 75 };
            int[] neutral  = { 20, 15, 18, 10, 12 };
            int[] negative = { 20, 15, 17, 10, 13 };

            LoadSentimentData(months, positive, neutral, negative);
        }


        public void LoadSentimentData(string[] dates, int[] positiveCounts, int[] neutralCounts, int[] negativeCounts)
        {
            // --- KPI update ---
            int totalReviews = positiveCounts.Sum() + neutralCounts.Sum() + negativeCounts.Sum();
            lblTotalReviews.Text = $"Total Reviews: {totalReviews}";
            lblPositive.Text = $"Positive: {positiveCounts.Sum() * 100 / totalReviews}%";
            lblNeutral.Text = $"Neutral: {neutralCounts.Sum() * 100 / totalReviews}%";
            lblNegative.Text = $"Negative: {negativeCounts.Sum() * 100 / totalReviews}%";

            // --- Trend Chart ---
            sentimentTrendPlot.Plot.Clear();
            double[] xs = Enumerable.Range(0, dates.Length).Select(i => (double)i).ToArray();
            double[] total = positiveCounts.Zip(neutralCounts, (p, n) => p + n)
                                        .Zip(negativeCounts, (pn, neg) => pn + neg)
                                        .Select(v => (double)v)
                                        .ToArray();

            double[] posPct = positiveCounts.Zip(total, (v, t) => v / t * 100).ToArray();
            double[] neuPct = neutralCounts.Zip(total, (v, t) => v / t * 100).ToArray();
            double[] negPct = negativeCounts.Zip(total, (v, t) => v / t * 100).ToArray();

            sentimentTrendPlot.Plot.Add.Scatter(xs, posPct).LegendText = "Positive";
            sentimentTrendPlot.Plot.Add.Scatter(xs, neuPct).LegendText = "Neutral";
            sentimentTrendPlot.Plot.Add.Scatter(xs, negPct).LegendText = "Negative";

            sentimentTrendPlot.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(xs, dates);
            sentimentTrendPlot.Plot.Axes.Bottom.Label.Text = "Month";
            sentimentTrendPlot.Plot.Axes.Left.Label.Text = "Sentiment (%)";
            sentimentTrendPlot.Plot.Title("Sentiment Trends");
            sentimentTrendPlot.Plot.Legend.IsVisible = true;
            sentimentTrendPlot.Refresh();

            // --- Pie Chart ---
            sentimentPiePlot.Plot.Clear();
            var totals = new[] { positiveCounts.Sum(), neutralCounts.Sum(), negativeCounts.Sum() };
            var labels = new[] { "Positive", "Neutral", "Negative" };
            var colors = new[] { Colors.Green, Colors.GoldenRod, Colors.Red };

            var slices = totals.Select((val, i) => new PieSlice(val, colors[i], labels[i])).ToList();
            sentimentPiePlot.Plot.Add.Pie(slices).ExplodeFraction = 0.05;
            sentimentPiePlot.Plot.Title("Overall Sentiment Distribution");
            // Hide all ticks and axis lines
            sentimentPiePlot.Plot.Axes.Left.IsVisible = false;
            sentimentPiePlot.Plot.Axes.Right.IsVisible = false;
            sentimentPiePlot.Plot.Axes.Top.IsVisible = false;
            sentimentPiePlot.Plot.Axes.Bottom.IsVisible = false;
            sentimentPiePlot.Refresh();

            // --- Review Feed ---
            reviewListView.Items.Clear();

            reviewListView.Items.Add(new ListViewItem(new[] 
            { 
                "Great gameplay, loved the new update!", 
                "Positive", 
                "92" 
            }));

            reviewListView.Items.Add(new ListViewItem(new[] 
            { 
                "Graphics are okay, but nothing special.", 
                "Neutral", 
                "75" 
            }));

            reviewListView.Items.Add(new ListViewItem(new[] 
            { 
                "Matchmaking is broken and full of cheaters.", 
                "Negative", 
                "88" 
            }));
            // reviewGrid.Rows.Clear();
            // reviewGrid.Rows.Add("Great gameplay, loved the new update!", "Positive", 92);
            // reviewGrid.Rows.Add("Graphics are okay, but nothing special.", "Neutral", 75);
            // reviewGrid.Rows.Add("Matchmaking is broken and full of cheaters.", "Negative", 88);
        }

    }
}

using System.Drawing.Drawing2D;
using Krypton.Toolkit;
using it13Project.UI;
using ScottPlot.WinForms;
using System.Data;
using it13Project.Data;

namespace it13Project.Pages
{
    partial class DashboardPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            rootLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = ThemeColors.ContentBackground

            };
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120)); // KPI row
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 55));   // Charts
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 45));   // Alerts / Reports

            // KPI Row
            kpiLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1
            };
            kpiLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            kpiLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            kpiLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            kpiLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));

            kpiLayout.Controls.Add(CreateModernStatPanel(Properties.Resources.iconGame, "Total Games", "1,235", Color.FromArgb(52, 152, 219)));
            kpiLayout.Controls.Add(CreateModernStatPanel(Properties.Resources.iconReviews, "Total Reviews", "1,245,678", Color.FromArgb(46, 204, 113)));
            kpiLayout.Controls.Add(CreateModernStatPanel(Properties.Resources.iconSentiment, "Avg. Sentiment", "82%", Color.FromArgb(155, 89, 182)));
            kpiLayout.Controls.Add(CreateModernStatPanel(Properties.Resources.iconRecommend, "% Recommended", "76%", Color.FromArgb(241, 196, 15)));

            // Charts Row 
            chartsLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1
            };

            chartsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            chartsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            chartsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            chartsLayout.Controls.Add(CreateModernSectionPanel("Sentiment Trend", graphType: GraphType.Signal), 0, 0);
            chartsLayout.Controls.Add(CreateModernSectionPanel("Review Volume", graphType: GraphType.Bar), 1, 0);
            chartsLayout.Controls.Add(CreateModernSectionPanel("Top 5 Games", graphType: GraphType.Pie), 2, 0);

            // Bottom Row 
            bottomLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            var alertsPanel = CreateStyledListView(
                "Negative Sentiment Alerts",
                new[] { "Game", "Alert", "Date" },
                out alertsListView);
            var reportsPanel = CreateStyledListView(
                "Upcoming Scheduled Reports",
                new[] { "Report", "Schedule" },
                out reportsListView);

            bottomLayout.Controls.Add(alertsPanel, 0, 0);
            bottomLayout.Controls.Add(reportsPanel, 1, 0);

            // Assemble Layout
            rootLayout.Controls.Add(chartsLayout, 0, 1);
            rootLayout.Controls.Add(bottomLayout, 0, 2);
            rootLayout.Controls.Add(kpiLayout, 0, 0);

            this.Controls.Add(rootLayout);
            this.Load += DashboardControl_Load;
            this.AutoScroll = true;
            this.ResumeLayout(false);
        }

        public enum GraphType { Scatter, Signal, Bar, Pie }

        // KPI Card
        private Control CreateModernStatPanel(Image icon, string title, string value, Color accentColor)
        {
            var group = new Krypton.Toolkit.KryptonGroup
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                MaximumSize = new Size(0, 90),
                StateCommon =
                {
                    Back = { Color1 = ThemeColors.ContentBackground },
                    Border =
                    {
                        DrawBorders = PaletteDrawBorders.All,
                        Rounding = 12,
                        Width = 1,
                        Color1 = ThemeColors.MenuHover
                    }
                }
            };

            // Main layout: 2 columns (icon + text stack)
            var container = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(8)
            };
            container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));   // icon column
            container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));   // text column
            container.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // Icon 
            var picIcon = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = icon,
                Margin = new Padding(0, 0, 8, 0),
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom
            };

            // Value  
            var lblValue = new Krypton.Toolkit.KryptonLabel
            {
                Text = value,
                Dock = DockStyle.Top,
                StateCommon = { ShortText = {
                    Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                    Color1 = accentColor
                }}
            };

            // Title 
            var lblTitle = new Krypton.Toolkit.KryptonLabel
            {
                Text = title,
                Dock = DockStyle.Top,
                StateCommon = { ShortText = {
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    Color1 = Color.Gray
                }}
            };

            var textPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true
            };
            textPanel.Controls.Add(lblValue);
            textPanel.Controls.Add(lblTitle);

            // Assemble
            container.Controls.Add(picIcon, 0, 0);
            container.Controls.Add(textPanel, 1, 0);

            group.Panel.Controls.Add(container);
            return group;
        }


        // Section Panel
        private Control CreateModernSectionPanel(
            string title,
            double[] dataX = null,
            double[] dataY = null,
            GraphType graphType = GraphType.Scatter,
            bool showLegend = false)
        {
            var group = new Krypton.Toolkit.KryptonGroup
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                StateCommon =
                {
                    Back = { Color1 = ThemeColors.ContentBackground },
                    Border =
                    {
                        DrawBorders = PaletteDrawBorders.All,
                        Rounding = 10,
                        Width = 0,
                        Color1 = ThemeColors.MenuHover
                    }
                }
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 1,
                ColumnCount = 1
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var formsPlot = new ScottPlot.WinForms.FormsPlot
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(6),
                BackColor = ThemeColors.ContentBackground
            };

            // Example data if none provided
            dataX ??= Enumerable.Range(0, 50).Select(i => (double)i).ToArray();
            dataY ??= dataX.Select(x => Math.Sin(x * 0.1)).ToArray();

            // 🔹 Select graph type
            switch (graphType)
            {
                case GraphType.Scatter:
                    formsPlot.Plot.Add.Scatter(dataX, dataY,
                        color: ScottPlot.Color.FromColor(ThemeColors.AccentPrimary));
                    break;

                case GraphType.Signal:
                    formsPlot.Plot.Add.Signal(dataY,
                        color: ScottPlot.Color.FromColor(ThemeColors.AccentSecondary));
                    break;

                case GraphType.Bar:
                    var bars = dataX.Zip(dataY, (x, y) => new ScottPlot.Bar
                    {
                        Position = x,
                        Value = y,
                        FillColor = ScottPlot.Color.FromColor(ThemeColors.AccentPrimary)
                    }).ToArray();
                    formsPlot.Plot.Add.Bars(bars);
                    break;

                case GraphType.Pie:
                    var pie = formsPlot.Plot.Add.Pie(dataY);
                    // pie.ShowLabels = true;
                    break;
            }

            // Apply title
            formsPlot.Plot.Title(title);
            formsPlot.ForeColor = ThemeColors.TextColor;

            // Show legend if requested
            // if (showLegend)
            //     formsPlot.ShowLegend();

            formsPlot.Refresh();

            layout.Controls.Add(formsPlot, 0, 0);
            group.Panel.Controls.Add(layout);

            return group;
        }


        // Alerts / Reports
        private Krypton.Toolkit.KryptonGroup CreateStyledListView(
            string title, 
            string[] columns, 
            out ListView listView)
        {
            var group = new Krypton.Toolkit.KryptonGroup
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                StateCommon =
                {
                    Back = { Color1 = ThemeColors.ContentBackground },
                    Border =
                    {
                        DrawBorders = PaletteDrawBorders.All,
                        Rounding = 10,
                        Width = 1,
                        Color1 = ThemeColors.MenuHover
                    }
                }
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var lblTitle = new Krypton.Toolkit.KryptonLabel
            {
                Text = title,
                Dock = DockStyle.Fill,
                StateCommon =
                {
                    ShortText =
                    {
                        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                        Color1 = Color.Black
                    }
                },
                Padding = new Padding(6, 3, 6, 3),
            };

            // 👇 local variable
            var lv = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                HideSelection = false,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 9F),
                BackColor = ThemeColors.ContentBackground,
                ForeColor = ThemeColors.MenuBackground,
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };

            foreach (var column in columns)
            {
                lv.Columns.Add(column, 140);
            }

            // Double buffering
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(lv, true, null);

            lv.OwnerDraw = true;
            lv.DrawColumnHeader += (s, e) =>
            {
                e.Graphics.FillRectangle(new SolidBrush(ThemeColors.MenuHover), e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, lv.Font, e.Bounds, ThemeColors.TextColor);
            };

            lv.DrawItem += (s, e) => e.DrawDefault = true;
            lv.DrawSubItem += (s, e) =>
            {
                var bgColor = e.Item.Selected ? ThemeColors.AccentPrimary : lv.BackColor;
                var textColor = e.Item.Selected ? ThemeColors.TextColor : lv.ForeColor;

                e.Graphics.FillRectangle(new SolidBrush(bgColor), e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lv.Font, e.Bounds, textColor);
            };

            layout.Controls.Add(lblTitle, 0, 0);
            layout.Controls.Add(lv, 0, 1);

            group.Panel.Controls.Add(layout);

            // 👇 assign after lambdas are done
            listView = lv;

            return group;
        }





        #endregion


        private TableLayoutPanel rootLayout;
        private TableLayoutPanel kpiLayout;
        private TableLayoutPanel chartsLayout;
        private TableLayoutPanel bottomLayout;
        private ListView alertsListView;
        private ListView reportsListView;
        // alertsListView, reportsListView
    }
}

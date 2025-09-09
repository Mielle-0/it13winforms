
using ScottPlot.WinForms;
using Krypton.Toolkit;
using it13Project.UI;

namespace it13Project.Pages
{
    partial class SentimentTrendsPage
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
            this.Name = "SentimentTrendsPage";
            this.Size = new Size(1000, 700);
            this.Padding = new Padding(20);
            this.Font = new Font("Segoe UI", 9.75F);

            // Filter Panel
            filterPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                Padding = new Padding(5),
                FlowDirection = FlowDirection.LeftToRight
            };

            lblFilter = new KryptonLabel
            {
                Text = "Select Games:",
                AutoSize = true,
                StateCommon = { ShortText = { Font = new Font("Segoe UI", 10F, FontStyle.Regular) } }
            };

            clbGames = new KryptonCheckedListBox
            {
                Width = 250,
                Height = 25
            };

            // Date range controls
            lblDateRange = new KryptonLabel
            {
                Text = "Date Range:",
                AutoSize = true,
                Margin = new Padding(15, 5, 0, 0), // spacing from game selector
                StateCommon = { ShortText = { Font = new Font("Segoe UI", 10F, FontStyle.Regular) } }
            };

            dtpStart = new KryptonDateTimePicker
            {
                Width = 120,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today.AddMonths(-3) // default: 3 months back
            };

            lblTo = new KryptonLabel
            {
                Text = "to",
                AutoSize = true,
                Margin = new Padding(5, 5, 5, 0)
            };

            dtpEnd = new KryptonDateTimePicker
            {
                Width = 120,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today
            };

            // Add controls to filter panel
            filterPanel.Controls.Add(lblFilter);
            filterPanel.Controls.Add(clbGames);
            filterPanel.Controls.Add(lblDateRange);
            filterPanel.Controls.Add(dtpStart);
            filterPanel.Controls.Add(lblTo);
            filterPanel.Controls.Add(dtpEnd);

            // KPI Summary Panel
            kpiPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 80,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(5)
            };

            lblTotalReviews = new KryptonLabel { Text = "Total Reviews: 0", Width = 200, StateCommon = { ShortText = { Font = new Font("Segoe UI", 11F, FontStyle.Bold) } } };
            lblPositive = new KryptonLabel { Text = "Positive: 0%", Width = 200 };
            lblNeutral = new KryptonLabel { Text = "Neutral: 0%", Width = 200 };
            lblNegative = new KryptonLabel { Text = "Negative: 0%", Width = 200 };

            kpiPanel.Controls.Add(lblTotalReviews);
            kpiPanel.Controls.Add(lblPositive);
            kpiPanel.Controls.Add(lblNeutral);
            kpiPanel.Controls.Add(lblNegative);

            // Charts Split
            var chartSplit = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 600
            };

            sentimentTrendPlot = new FormsPlot { Dock = DockStyle.Fill };
            sentimentPiePlot = new FormsPlot { Dock = DockStyle.Fill };

            chartSplit.Panel1.Controls.Add(sentimentTrendPlot);
            chartSplit.Panel2.Controls.Add(sentimentPiePlot);

            // Review Feed (Bottom)
            // reviewGrid = new KryptonDataGridView
            // {
            //     Dock = DockStyle.Bottom,
            //     Height = 200,
            //     AllowUserToAddRows = false,
            //     ReadOnly = true,
            //     AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            // };
            // reviewGrid.Columns.Add("ReviewText", "Review");
            // reviewGrid.Columns.Add("Sentiment", "Sentiment");
            // reviewGrid.Columns.Add("Confidence", "Confidence (%)");
            // --- Review Feed (Bottom) ---
            reviewGroup = CreateStyledListView(
                "Recent Reviews",
                new[] { "Review", "Sentiment", "Confidence (%)" },
                out reviewListView
            );

            reviewGroup.Dock = DockStyle.Bottom;
            reviewGroup.Height = 250; // taller to match bigger font
            reviewGroup.Width = this.ClientSize.Width; // take full width

            filterPanel.BackColor = ThemeColors.ContentBackground;
            kpiPanel.BackColor = ThemeColors.ContentBackground;

            // Add everything to the control
            this.Controls.Add(chartSplit);
            // this.Controls.Add(reviewGrid);
            
            this.Controls.Add(reviewGroup);
            this.Controls.Add(kpiPanel);
            this.Controls.Add(filterPanel);

            this.BackColor = ThemeColors.ContentBackground;
            this.ResumeLayout(false);
        }


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
                        Font = new Font("Segoe UI", 14F, FontStyle.Bold),
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
                Font = new Font("Segoe UI", 11F),
                BackColor = ThemeColors.ContentBackground,
                ForeColor = ThemeColors.MenuBackground,
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };

            for (int i = 0; i < columns.Length; i++)
            {
                var col = lv.Columns.Add(columns[i]);
                if (i == 0)
                    col.Width = -2; // auto-size Review column to fill
                else
                    col.Width = 140; // fixed width for Sentiment and Confidence
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


        private KryptonLabel lblTotalReviews, lblPositive,
                            lblNeutral, lblNegative,
                            lblFilter, lblDateRange, lblTo;
        private FormsPlot sentimentTrendPlot, sentimentPiePlot;
        // KPI Labels
        private FlowLayoutPanel filterPanel, kpiPanel;
        private KryptonDateTimePicker dtpStart, dtpEnd;
        private KryptonDataGridView reviewGrid;
        private KryptonCheckedListBox clbGames;
        private KryptonGroup reviewGroup;
        private ListView reviewListView;

    }
}

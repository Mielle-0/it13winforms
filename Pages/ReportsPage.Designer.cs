
using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit;
using ScottPlot.WinForms;
using it13Project.UI;

namespace it13Project.Pages
{
    partial class ReportsPage
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
        this.Name = "ReportsPage";
        this.Size = new Size(1000, 700);
        this.Padding = new Padding(10);
        this.BackColor = ThemeColors.ContentBackground;

        // === Top Filters / Templates Bar ===
        var topBar = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 60,
            BackColor = ThemeColors.MenuBackground,
            Padding = new Padding(10, 10, 10, 10),
            FlowDirection = FlowDirection.LeftToRight
        };

        cboTemplate = new KryptonComboBox
        {
            Width = 150,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        cboTemplate.Items.AddRange(new object[] { "Weekly", "Monthly", "Quarterly" });

        dtFrom = new KryptonDateTimePicker { Width = 150 };
        dtTo = new KryptonDateTimePicker { Width = 150 };

        btnApplyFilters = new KryptonButton
        {
            Text = "Apply",
            OverrideDefault = { Back = { Color1 = ThemeColors.AccentPrimary } },
            StateCommon = { Content = { ShortText = { Color1 = ThemeColors.TextColor } } },
            Margin = new Padding(10, 0, 0, 0)
        };

        topBar.Controls.Add(new KryptonLabel { Text = "Template:", StateCommon = { ShortText = { Color1 = ThemeColors.TextColor } } });
        topBar.Controls.Add(cboTemplate);
        topBar.Controls.Add(new KryptonLabel { Text = "From:", StateCommon = { ShortText = { Color1 = ThemeColors.TextColor } } });
        topBar.Controls.Add(dtFrom);
        topBar.Controls.Add(new KryptonLabel { Text = "To:", StateCommon = { ShortText = { Color1 = ThemeColors.TextColor } } });
        topBar.Controls.Add(dtTo);
        topBar.Controls.Add(btnApplyFilters);

        // === Main Split Area ===
        tableLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 2
        };
        tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250)); // left = filters
        tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));  // right = preview
        tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70));         // top = main content
        tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30));         // bottom = schedules

        // === Left Filters Panel ===
        filterPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            FlowDirection = FlowDirection.TopDown,
            Padding = new Padding(10),
            BackColor = ThemeColors.MenuBackground
        };

        filterPanel.Controls.Add(new KryptonLabel { Text = "Filters", StateCommon = { ShortText = { Font = new Font("Segoe UI", 10, FontStyle.Bold), Color1 = ThemeColors.TextColor } } });
        filterPanel.Controls.Add(new KryptonCheckBox { Text = "Include Charts", StateCommon = { ShortText = { Color1 = ThemeColors.TextColor } } });
        filterPanel.Controls.Add(new KryptonCheckBox { Text = "Include Metadata", StateCommon = { ShortText = { Color1 = ThemeColors.TextColor } } });
        filterPanel.Controls.Add(new KryptonCheckBox { Text = "Summary Only", StateCommon = { ShortText = { Color1 = ThemeColors.TextColor } } });

        // === Right Report Preview ===
        var previewPanel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = ThemeColors.ContentBackground,
            Padding = new Padding(10)
        };

        chartPreview = new FormsPlot
        {
            Dock = DockStyle.Fill
        };

        btnExportPdf = new KryptonButton
        {
            Text = "Export PDF",
            Width = 100,
            Margin = new Padding(0, 5, 10, 5),
            OverrideDefault = { Back = { Color1 = ThemeColors.AccentSecondary } },
            StateCommon = { Content = { ShortText = { Color1 = ThemeColors.TextColor } } }
        };

        btnExportExcel = new KryptonButton
        {
            Text = "Export Excel",
            Width = 100,
            Margin = new Padding(0, 5, 0, 5),
            OverrideDefault = { Back = { Color1 = ThemeColors.AccentPrimary } },
            StateCommon = { Content = { ShortText = { Color1 = ThemeColors.TextColor } } }
        };

        var exportBar = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 40,
            FlowDirection = FlowDirection.LeftToRight,
            Padding = new Padding(0, 5, 0, 5)
        };
        exportBar.Controls.Add(btnExportPdf);
        exportBar.Controls.Add(btnExportExcel);

        previewPanel.Controls.Add(chartPreview);
        previewPanel.Controls.Add(exportBar);

        // === Bottom Scheduled Reports ===
        dgvSchedules = new KryptonDataGridView
        {
            Dock = DockStyle.Fill,
            BackgroundColor = ThemeColors.ContentBackground,
            ForeColor = ThemeColors.TextColor,
            EnableHeadersVisualStyles = false,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };

        dgvSchedules.ColumnHeadersDefaultCellStyle.BackColor = ThemeColors.MenuBackground;
        dgvSchedules.ColumnHeadersDefaultCellStyle.ForeColor = ThemeColors.TextColor;

        dgvSchedules.Columns.Add("Name", "Report Name");
        dgvSchedules.Columns.Add("Format", "Format");
        dgvSchedules.Columns.Add("Recipients", "Recipients");
        dgvSchedules.Columns.Add("Frequency", "Frequency");
        dgvSchedules.Columns.Add("NextRun", "Next Run");

        btnSchedule = new KryptonButton
        {
            Text = "+ Schedule New Report",
            Dock = DockStyle.Top,
            OverrideDefault = { Back = { Color1 = ThemeColors.AccentPrimary } },
            StateCommon = { Content = { ShortText = { Color1 = ThemeColors.TextColor } } },
            Height = 35
        };

        var schedulePanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
        schedulePanel.Controls.Add(dgvSchedules);
        schedulePanel.Controls.Add(btnSchedule);

        // === Assemble Layout ===
        tableLayout.Controls.Add(filterPanel, 0, 0);
        tableLayout.Controls.Add(previewPanel, 1, 0);
        tableLayout.SetColumnSpan(schedulePanel, 2);
        tableLayout.Controls.Add(schedulePanel, 0, 1);

        // === Add to root ===
        this.Controls.Add(tableLayout);
        this.Controls.Add(topBar);


        this.ResumeLayout(false);
        }

        #endregion

        
        private KryptonComboBox cboTemplate;
        private KryptonDateTimePicker dtFrom, dtTo;
        private KryptonButton btnApplyFilters, btnExportPdf, btnExportExcel, btnSchedule;
        private FormsPlot chartPreview;
        private FlowLayoutPanel filterPanel;
        private TableLayoutPanel tableLayout;
        private KryptonDataGridView dgvSchedules;
    }
}

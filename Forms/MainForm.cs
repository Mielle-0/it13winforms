using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;
using it13Project.Pages;
using it13Project.UI;

namespace it13Project.Forms
{
    public partial class MainForm : Form
    {
        private KryptonButton? currentButton;

        public MainForm()
        {
            InitializeComponent();
            // Load the default page
            ActivateButton(btnDashboard);
            LoadPage(new DashboardPage());

            SidebarControl();
        }


        // Button is active
        private void ActivateButton(object btnSender)
        {
            if (btnSender == null) return;
            
            if (currentButton != (KryptonButton)btnSender)
            {
                DisableButton();
                currentButton = (KryptonButton)btnSender;
                currentButton.StateCommon.Back.Color1 = ThemeColors.AccentPrimary;
                currentButton.StateCommon.Back.Color2 = ThemeColors.AccentPrimary;
                currentButton.StateCommon.Content.ShortText.Color1 = ThemeColors.TextColor;
                currentButton.StateCommon.Content.ShortText.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);

            }
        }

        // Button not active
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn is KryptonButton btn)
                {
                    btn.StateCommon.Back.Color1 = ThemeColors.MenuBackground;
                    btn.StateCommon.Content.ShortText.Color1 = ThemeColors.TextColor;
                    btn.StateCommon.Content.ShortText.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Regular);
                }
            }
        }

        // Load user control
        private void LoadPage(UserControl page)
        {
            panelContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Add(page);
            page.BringToFront();
        }


        // Simple Access Control
        private void SidebarControl()
        {

            btnInfluentialReviewers.Visible = false;
            btnModelManagement.Visible = false;
        }


        // --- Navigation Button Click Events ---
        private void btnDashboard_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            LoadPage(new DashboardPage());
        }

        private void btnGameList_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            LoadPage(new GameListPage());
        }

        private void btnSentimentTrends_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            LoadPage(new SentimentTrendsPage());
        }

        private void btnInfluentialReviewers_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            LoadPage(new InfluentialReviewersPage());
        }

        private void btnAlerts_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            LoadPage(new AlertsNotificationsPage());
        }

        private void btnReports_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            LoadPage(new ReportsPage());
        }

        private void btnModelManagement_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            LoadPage(new ModelManagementPage());
        }

        private void btnAdminSettings_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            LoadPage(new AdminSettingsPage());
        }

        private void btnUserManagement_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            LoadPage(new UserManagement());
        }
    }
}

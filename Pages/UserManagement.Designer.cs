namespace it13Project.Pages
{
    partial class UserManagement
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
            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(15);
            this.Font = new Font("Segoe UI", 10F);

            // === Toolbar ===
            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 40,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(5)
            };

            txtSearch = new TextBox { Width = 200, PlaceholderText = "Search users..." };
            cmbFilterRole = new ComboBox { Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbFilterRole.Items.AddRange(new[] { "All Roles", "Admin", "Analyst", "Marketing" });
            cmbFilterRole.SelectedIndex = 0;

            cmbFilterStatus = new ComboBox { Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbFilterStatus.Items.AddRange(new[] { "All Statuses", "Active", "Inactive" });
            cmbFilterStatus.SelectedIndex = 0;

            btnRefresh = new Button { Text = "Refresh", Width = 90 };
            btnRefresh.Click += btnRefresh_Click;

            btnAddUser = new Button { Text = "Add User", Width = 100 };
            btnAddUser.Click += btnAddUser_Click;

            btnEditUser = new Button { Text = "Edit User", Width = 100 };
            btnEditUser.Click += btnEditUser_Click;

            btnDeactivateUser = new Button { Text = "Deactivate", Width = 110 };
            btnDeactivateUser.Click += btnDeactivateUser_Click;

            toolbar.Controls.AddRange(new Control[]
            {
                txtSearch,
                cmbFilterRole,
                cmbFilterStatus,
                btnRefresh,
                btnAddUser,
                btnEditUser,
                btnDeactivateUser
            });

            // === Users Grid ===
            dgvUsers = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // === Layout ===
            this.Controls.Add(dgvUsers);
            this.Controls.Add(toolbar);
        }

        private TextBox txtSearch;
        private ComboBox cmbFilterRole;
        private ComboBox cmbFilterStatus;
        private DataGridView dgvUsers;
        private Button btnAddUser, btnEditUser, btnDeactivateUser, btnRefresh;

        #endregion
    }
}

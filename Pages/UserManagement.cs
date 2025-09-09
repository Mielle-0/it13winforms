using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using it13Project.Data;
using it13Project.Forms;
using Microsoft.Data.SqlClient;

namespace it13Project.Pages
{
    public partial class UserManagement : UserControl
    {
        public UserManagement()
        {
            InitializeComponent();
            // LoadSampleData();
            LoadUsers();
        }


        private void LoadUsers()
        {
            string query = @"
                SELECT 
                    user_id,
                    name AS FullName,
                    email AS Email,
                    role AS Role
                FROM dbo.Users";  // 👈 always use dbo schema in SQL Server

            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            dgvUsers.DataSource = dt;

            var userIdColumn = dgvUsers.Columns["user_id"];
            if (userIdColumn != null)
            {
                userIdColumn.Visible = false;
            }

        }
        
        private void LoadSampleData()
        {
            dgvUsers.Rows.Clear();
            dgvUsers.Rows.Add("jdoe", "John Doe", "jdoe@email.com", "Admin", "Active", "2025-09-04 09:15");
            dgvUsers.Rows.Add("asmith", "Alice Smith", "asmith@email.com", "Manager", "Active", "2025-09-03 16:40");
            dgvUsers.Rows.Add("bjones", "Bob Jones", "bjones@email.com", "Reviewer", "Inactive", "2025-08-28 11:20");
        }



        // Button Clicks

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
        }

        private void btnAddUser_Click(object sender, System.EventArgs e)
        {

            using (var form = new AddUser())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                }
            }
        }

        private void btnEditUser_Click(object sender, System.EventArgs e)
        {

            if (dgvUsers.SelectedRows.Count > 0)
            {
                var row = dgvUsers.SelectedRows[0];

                int userId = Convert.ToInt32(row.Cells["user_id"].Value);

                var nameCell = row.Cells["FullName"].Value;
                var emailCell = row.Cells["Email"].Value;
                var roleCell = row.Cells["Role"].Value;

                if (nameCell == null || emailCell == null || roleCell == null)
                {
                    MessageBox.Show("Selected user has incomplete data.");
                    return;
                }

                string name = nameCell.ToString()!;
                string email = emailCell.ToString()!;
                string role = roleCell.ToString()!;



                using (var form = new AddUser(userId, name, email, role))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadUsers();
                    }
                }
            }

        }

        private void btnDeactivateUser_Click(object sender, System.EventArgs e)
        {
        }
    }
}

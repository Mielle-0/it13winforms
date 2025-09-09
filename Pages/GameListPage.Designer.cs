using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit;
using it13Project.UI;

namespace it13Project.Pages
{
    partial class GameListPage
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
            this.Name = "GameListPage";
            this.Size = new Size(800, 600);
            this.Padding = new Padding(20);
            this.BackColor = ThemeColors.ContentBackground;

            tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50)); // filter row
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // cards row

            filterPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                Padding = new Padding(0, 5, 0, 5),
                BackColor = ThemeColors.MenuBackground,
                ForeColor = ThemeColors.TextColor
            };

            filterPanel.Controls.Add(new KryptonLabel
            {
                Text = "Genre:",
                StateCommon = { ShortText = { Color1 = ThemeColors.TextColor } },
                Margin = new Padding(5, 10, 0, 0)
            });

            cboGenre = new KryptonComboBox { Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            filterPanel.Controls.Add(cboGenre);

            filterPanel.Controls.Add(new KryptonLabel
            {
                Text = "Sentiment:",
                StateCommon = { ShortText = { Color1 = ThemeColors.TextColor } },
                Margin = new Padding(10, 10, 0, 0)
            });

            cboSentiment = new KryptonComboBox { Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
            filterPanel.Controls.Add(cboSentiment);

            btnApplyFilters = new KryptonButton
            {
                Text = "Apply Filters",
                OverrideDefault = { Back = { Color1 = ThemeColors.AccentPrimary } },
                StateCommon = { Content = { ShortText = { Color1 = ThemeColors.TextColor } } },
                Margin = new Padding(10, 5, 0, 0)
            };
            filterPanel.Controls.Add(btnApplyFilters);

            // Card Container (instead of DataGridView)
            flpCards = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                Padding = new Padding(10),
                BackColor = ThemeColors.ContentBackground
            };

            // Example: add placeholder cards (later replace with dynamic data)
            for (int i = 0; i < 5; i++)
            {
                flpCards.Controls.Add(CreateGameCard(
                    "Game Title " + (i + 1),
                    "This is a short description of the game. It will be truncated to fit inside the card."
                ));
            }

            // Add to controls
            tableLayout.Controls.Add(filterPanel, 0, 0);
            tableLayout.Controls.Add(flpCards, 0, 1);
            this.Controls.Add(tableLayout);
            this.Load += GameListControl_Load;
            this.ResumeLayout(false);
        }


        private Control CreateGameCard(string title, string description, Image image = null)
        {
            var group = new KryptonGroup
            {
                Width = 230,
                Height = 150, // taller to fit image
                Margin = new Padding(10),
                StateCommon =
                {
                    Back = { Color1 = ThemeColors.ContentBackground },
                    Border =
                    {
                        DrawBorders = PaletteDrawBorders.All,
                        Rounding = 8,
                        Width = 1,
                        Color1 = ThemeColors.MenuHover
                    }
                }
            };

            // TableLayout: 2 columns (image + text)
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 1,
                ColumnCount = 2,
                Padding = new Padding(8)
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80)); // image column
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); // text column

            // PictureBox
            var pic = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = image ?? Properties.Resources.list1 // configure placeholder image in your resources
            };

            // Text layout
            var textLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            textLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // title
            textLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // description

            var lblTitle = new KryptonLabel
            {
                Text = title,
                Dock = DockStyle.Fill,
                StateCommon = { ShortText = { Font = new Font("Segoe UI", 11F, FontStyle.Bold), Color1 = ThemeColors.MenuBackground } }
            };

            var lblDesc = new KryptonLabel
            {
                Text = description.Length > 80 ? description.Substring(0, 77) + "..." : description,
                Dock = DockStyle.Fill,
                StateCommon = { ShortText = { Font = new Font("Segoe UI", 9F), Color1 = ThemeColors.MenuBackground } },
                AutoSize = false
            };

            textLayout.Controls.Add(lblTitle, 0, 0);
            textLayout.Controls.Add(lblDesc, 0, 1);

            // Add image and text to main layout
            layout.Controls.Add(pic, 0, 0);
            layout.Controls.Add(textLayout, 1, 0);

            group.Panel.Controls.Add(layout);
            return group;
        }







        #endregion

        private TableLayoutPanel tableLayout;
        private KryptonComboBox cboGenre;
        private KryptonComboBox cboSentiment;
        private KryptonButton btnApplyFilters;
        private KryptonDataGridView dgvGames;
        private FlowLayoutPanel flpCards, filterPanel;
    }
}

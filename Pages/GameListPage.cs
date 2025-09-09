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
using Microsoft.Data.SqlClient;

namespace it13Project.Pages
{
    public partial class GameListPage : UserControl
    {
        public GameListPage()
        {
            InitializeComponent();
        }

        private void GameListControl_Load(object sender, EventArgs e)
        {

            var sampleGames = new List<GameData>
            {
                new GameData { Title = "Counter-Strike 2", Description = "Fast-paced tactical shooter with competitive matchmaking.", Image = null },
                new GameData { Title = "Dota 2", Description = "MOBA game with deep strategy and huge esports scene.", Image = null },
                new GameData { Title = "Stardew Valley", Description = "Relaxing farming simulator with charming characters.", Image = null }
            };

            LoadGames(sampleGames);
        }

        public void LoadGames(IEnumerable<GameData> games)
        {
            flpCards.Controls.Clear(); // remove existing cards

            foreach (var game in games)
            {
                var card = CreateGameCard(
                    game.Title,
                    game.Description,
                    game.Image // can be null
                );

                flpCards.Controls.Add(card);
            }
        }
        

        public void LoadGamesFromDatabase(string? genreFilter = null, string? sentimentFilter = null)
        {
            var query = @"SELECT Title, Description, ImageUrl, AvgSentiment, TotalReviews, RecommendedPct, Genre
                        FROM Games
                        WHERE (@Genre IS NULL OR Genre = @Genre)";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Genre", genreFilter ?? (object)DBNull.Value)
            };

            var dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());

            // Clear existing cards
            flpCards.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string? title = row["Title"].ToString();
                string? desc = row["Description"].ToString();

                // Handle optional image
                Image? img = null;
                string? imageUrl = row["ImageUrl"] as string;
                if (!string.IsNullOrEmpty(imageUrl) && File.Exists(imageUrl))
                    img = Image.FromFile(imageUrl); 
                else
                    img = Properties.Resources.list1; 

                // Optional metrics (can be shown on the card later)
                double avgSentiment = row["AvgSentiment"] != DBNull.Value ? Convert.ToDouble(row["AvgSentiment"]) : 0;
                int totalReviews = row["TotalReviews"] != DBNull.Value ? Convert.ToInt32(row["TotalReviews"]) : 0;
                double recommendedPct = row["RecommendedPct"] != DBNull.Value ? Convert.ToDouble(row["RecommendedPct"]) : 0;

                // Create card
                var card = CreateGameCard(title, desc, img);
                flpCards.Controls.Add(card);
            }
        }

    }

    public class GameData
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Image? Image { get; set; } // optional
    }

}

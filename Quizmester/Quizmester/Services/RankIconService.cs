using Quizmester.Models;

namespace Quizmester.Services
{
    public class RankIconService
    {
        public Image? GetRankIcon(Rank rank)
        {
            string fileName;

            if (rank.Name.StartsWith("Iron"))
            {
                fileName = "iron.png";
            }
            else if (rank.Name.StartsWith("Bronze"))
            {
                fileName = "bronze.png";
            }
            else if (rank.Name.StartsWith("Silver"))
            {
                fileName = "silver.png";
            }
            else if (rank.Name.StartsWith("Gold"))
            {
                fileName = "gold.png";
            }
            else if (rank.Name.StartsWith("Platinum"))
            {
                fileName = "platinum.png";
            }
            else if (rank.Name.StartsWith("Diamond"))
            {
                fileName = "diamond.png";
            }
            else if (rank.Name.StartsWith("Master"))
            {
                fileName = "master.png";
            }
            else
            {
                return null;
            }

            string path = Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                "Ranks",
                fileName
            );

            if (!File.Exists(path))
            {
                return null;
            }

            return Image.FromFile(path);
        }
    }
}
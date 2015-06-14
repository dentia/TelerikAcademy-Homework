namespace Minesweeper
{
    public class ScoreInfo
    {
        public ScoreInfo(string name, int points)
        {
            this.PlayerName = name;
            this.PlayerPoints = points;
        }

        public string PlayerName { get; set; }

        public int PlayerPoints { get; set; }
    }
}
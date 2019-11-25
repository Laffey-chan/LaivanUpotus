namespace LaivanUpotus
{
    internal class Player
    {
        public int Xp { get; set; }

        public int WinLoss { get; set; }

        public int Shoot { get; set; }

        public int Sink { get; set; }

        public int Earnings { get; set; }
        public Player(int xp = 0, int winLoss = 0, int shoot = 0, int sink = 0, int earnings = 0)
        {
            Xp = xp;
            WinLoss = winLoss;
            Shoot = shoot;
            Sink = sink;
            Earnings = earnings;
        }

        public override string ToString()
        {
            return "xp: " + Xp + " WinLoss: " + WinLoss + " Shoot: " + Shoot + " Sink: " + Sink + " Earnings: " + Earnings;
        }
    }
}
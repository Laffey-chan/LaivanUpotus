namespace LaivanUpotus
{
    internal class Player
    {
        public string Name { get; set; }
        public int Xp { get; set; }

        public int WinLoss { get; set; }

        public int Shoot { get; set; }

        public int Sink { get; set; }

        public int Earnings { get; set; }
        public Player(string name = "Steave", int xp = 0, int winLoss = 0, int shoot = 0, int sink = 0, int earnings = 0)
        {
            Name = name;
            Xp = xp;
            WinLoss = winLoss;
            Shoot = shoot;
            Sink = sink;
            Earnings = earnings;
        }

        public override string ToString()
        {
            return Name + "\n" + Xp + "\n" + WinLoss + "\n" + Shoot + "\n" + Sink + "\n" + Earnings;
        }
    }
}
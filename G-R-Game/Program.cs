using System;

namespace test
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new G_R_Game.Game1())
                game.Run();
        }
    }
}

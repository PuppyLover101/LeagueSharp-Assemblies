using System;
using LeagueSharp;
using LeagueSharp.Common;

namespace PuppyStandAloneOrbwalker
{
    class StandaloneOrbwalker
    {

        private Menu Config;

        private Orbwalking.Orbwalker _orbwalker;

        private StandaloneOrbwalker()
        {
            CustomEvents.Game.OnGameLoad += OnGameLoad;
        }

        private void OnGameLoad(EventArgs args)
        {
            Config = new Menu("PuppyStandalone Orbwalker", "PuppyStandalone Orbwalker", true);
            Menu orbwalkerConfig = new Menu("Orbwalker", "orbwalker");
            _orbwalker = new Orbwalking.Orbawlker(orbwalkerConfig);
            Config.AddSubMenu(orbwalkerConfig);
            Config.AddToMainMenu();
        }

        public static void Main(string[] args)
        {
            new StandaloneOrbwalker();
        }
    }
}


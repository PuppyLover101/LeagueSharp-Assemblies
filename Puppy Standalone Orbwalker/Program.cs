
using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using SPrediction;

namespace PuppyStandaloneOrbwalker
{
    internal class Program
    {
        public const string ChampionName = "balblabll";
        static Orbwalking.Orbwalker Orbwalker;
        static Menu Menu;
        public static Spell Q;
        public static Spell W;
        public static Spell E;
        public static Spell R;
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            Menu = new Menu("PuppyStandaloneOrbwalker (OP)", ObjectManager.Player.ChampionName, true);

            Menu OrbwalkerMenu = Menu.AddSubMenu(new Menu("Orbwalker", "Orbwalker"));
            Orbwalker = new Orbwalking.Orbwalker(OrbwalkerMenu);

            Menu TargetSelectorMenu = Menu.AddSubMenu(new Menu("Target Selector", "TargetSelector"));
            TargetSelector.AddToMenu(TargetSelectorMenu);

            Menu.AddToMainMenu();
            Q = new Spell(SpellSlot.Q, 1);
            W = new Spell(SpellSlot.W, 1);
            E = new Spell(SpellSlot.E, 1);
            R = new Spell(SpellSlot.R, 1);

            Game.OnUpdate += Game_OnGameUpdate;

        }
        private static void Game_OnGameUpdate(EventArgs args)
        {
            switch (Orbwalker.ActiveMode)
            {
                case Orbwalking.OrbwalkingMode.Combo:

                    var Target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Magical);

                    if (Q.IsReady()) Q.Cast(Target);
                    if (W.IsReady()) W.Cast(Target);
                    if (E.IsReady()) E.Cast(Target);
                    if (R.IsReady()) R.Cast(Target);
                    break;
            }
        }
    }
}
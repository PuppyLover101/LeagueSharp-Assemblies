
using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace Pup_Warwick
{
    internal class Program
    {
        public const string ChampionName = "Warwick";
        static Orbwalking.Orbwalker Orbwalker;
        static Menu Menu;
        public static Spell Q;
        public static Spell W;
        public static Spell R;
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            Menu = new Menu("PupWarwick (OP)", ObjectManager.Player.ChampionName, true);

            Menu OrbwalkerMenu = Menu.AddSubMenu(new Menu("Orbwalker", "Orbwalker"));
            Orbwalker = new Orbwalking.Orbwalker(OrbwalkerMenu);

            Menu TargetSelectorMenu = Menu.AddSubMenu(new Menu("Target Selector", "TargetSelector"));
            TargetSelector.AddToMenu(TargetSelectorMenu);

            Menu.AddToMainMenu();
            Q = new Spell(SpellSlot.Q, 400);
            W = new Spell(SpellSlot.W, 400);
            R = new Spell(SpellSlot.R, 700);

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
                    if (R.IsReady()) R.Cast(Target);
                    break;
            }
        }
    }
}
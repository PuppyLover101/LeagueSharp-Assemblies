
using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using SPrediction;

namespace PupAmumu
{
    internal class Program
    {
        public const string ChampionName = "Amumu";
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
            Menu = new Menu("PupAmumu (OP)", ObjectManager.Player.ChampionName, true);

            Menu OrbwalkerMenu = Menu.AddSubMenu(new Menu("Orbwalker", "Orbwalker"));
            Orbwalker = new Orbwalking.Orbwalker(OrbwalkerMenu);

            Menu TargetSelectorMenu = Menu.AddSubMenu(new Menu("Target Selector", "TargetSelector"));
            TargetSelector.AddToMenu(TargetSelectorMenu);

            Menu.AddToMainMenu();
            Q = new Spell(SpellSlot.Q, 1080);
            W = new Spell(SpellSlot.W, 300);
            E = new Spell(SpellSlot.E, 350);
            R = new Spell(SpellSlot.R, 550);

            Q.SetSkillshot(.25f, 90, 2000, true, SkillshotType.SkillshotLine);
            W.SetSkillshot(0f, W.Range, float.MaxValue, false, SkillshotType.SkillshotCircle);
            E.SetSkillshot(.5f, E.Range, float.MaxValue, false, SkillshotType.SkillshotCircle);
            R.SetSkillshot(.25f, R.Range, float.MaxValue, false, SkillshotType.SkillshotCircle);

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
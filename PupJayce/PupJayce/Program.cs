
using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace Pup
{
    internal class Program
    {
        public const string ChampionName = "Brand";
        static Orbwalking.Orbwalker Orbwalker;
        static Menu Menu;

        //spells
        public static Spell QMelee;
        public static Spell WMelee;
        public static Spell EMelee;
        public static Spell QRanged;
        public static Spell WRanged;
        public static Spell ERanged;
        public static Spell R;
 
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            Menu = new Menu("PupJayce (OP)", ObjectManager.Player.ChampionName, true);

            Menu OrbwalkerMenu = Menu.AddSubMenu(new Menu("Orbwalker", "Orbwalker"));
            Orbwalker = new Orbwalking.Orbwalker(OrbwalkerMenu);

            Menu TargetSelectorMenu = Menu.AddSubMenu(new Menu("Target Selector", "TargetSelector"));
            TargetSelector.AddToMenu(TargetSelectorMenu);

            Menu.AddToMainMenu();

            QMelee = new Spell(SpellSlot.Q, 600);
            WMelee = new Spell(SpellSlot.Q, 285);
            EMelee = new Spell(SpellSlot.W, 240);
            QRanged= new Spell(SpellSlot.E, 1050);
            WRanged= new Spell(SpellSlot.Q, 285);
            ERanged= new Spell(SpellSlot.W, 650);
            R = new Spell(SpellSlot.R, 0);
    
            QRanged.SetSkillshot(0.25f, 70f, 1450f, true, SkillshotType.SkillshotLine);
            Game.OnUpdate += Game_OnGameUpdate;
        }
        private static void Game_OnGameUpdate(EventArgs args)
        {
            switch (Orbwalker.ActiveMode)
            {
                case Orbwalking.OrbwalkingMode.Combo:

                    var Target = TargetSelector.GetTarget(E.Range, TargetSelector.DamageType.Magical);

                    if (Q.IsReady()) Q.Cast(Target);
                    if (W.IsReady()) W.Cast(Target);
                    if (E.IsReady()) E.Cast(Target);

                    break;
            }
        }
    }
}
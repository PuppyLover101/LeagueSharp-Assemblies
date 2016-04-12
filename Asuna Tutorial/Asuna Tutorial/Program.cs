using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace Asuna_Tutorial
{
    class Program
    {
        public static Obj_AI_Hero Player;
        public static String ChampionName = "Ezreal";
        public static Menu _Menu;
        public static Orbwalking.Orbwalker _Orbwalker;
        public static Spell Q, W, E, R;

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
            Game.PrintChat("Thanks for using my scripts :D");
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            Player = ObjectManager.Player;
            if (Player.ChampionName != ChampionName)
            {
                return;
            }

            //When game is loaded up and Player.ChampionName != ChampionName)

            Q = new Spell(SpellSlot.Q, 1150);
            W = new Spell(SpellSlot.W, 1000);
            E = new Spell(SpellSlot.E, 475);
            R = new Spell(SpellSlot.R);


            _Menu = new Menu("Asuna Tutorial", "Asuna Tutorial", true);
            var OrbwalkerMenu = new Menu("Orbwalker", "Asuna Tutorial Orbwalker");
            _Orbwalker = new Orbwalking.Orbwalker(OrbwalkerMenu);

            _Menu.AddSubMenu(OrbwalkerMenu);

            var ComboMenu = new Menu("Combo", "Asuna.Tutorial.Ezreal.Combo");

            {
                ComboMenu.AddItem(new MenuItem("Asuna.Tutorial.Ezreal.Combo.UseQ", "Use Q").SetValue(true));
                ComboMenu.AddItem(new MenuItem("Asuna.Tutorial.Ezreal.Combo.UseW", "Use W").SetValue(true));
                ComboMenu.AddItem(new MenuItem("Asuna.Tutorial.Ezreal.Combo.UseE", "Use E").SetValue(false));
                ComboMenu.AddItem(new MenuItem("Asuna.Tutorial.Ezreal.Combo.UseR", "Use R").SetValue(true));
            }
            _Menu.AddSubMenu(ComboMenu);

            var HarassMenu = new Menu("Harass", "Asuna.Tutorial.Ezreal.Harass");
            {
                HarassMenu.AddItem(new MenuItem("Asuna.Tutorial.Ezreal.Harass.UseQ", "Use Q").SetValue(true));
                HarassMenu.AddItem(new MenuItem("Asuna.Tutorial.Ezreal.Harass.UseW", "Use W").SetValue(true));
                HarassMenu.AddItem(new MenuItem("Asuna.Tutorial.Ezreal.Harass.UseE", "Use E").SetValue(false));
                HarassMenu.AddItem(new MenuItem("Asuna.Tutorial.Ezreal.Harass.UseR", "Use R").SetValue(false));
            }
            _Menu.AddSubMenu(HarassMenu);


            _Menu.AddToMainMenu();

            //Made by PuppyLover101

        }
    }
}

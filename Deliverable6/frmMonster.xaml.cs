// Kalen Williams
// CS 1182
// 28 April 2016
// Deliverable 6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BaseObjects;
using CoreObjectsLibrary;

namespace Deliverable6 {
    /// <summary>
    /// Interaction logic for frmMonster.xaml
    /// </summary>
    public partial class frmMonster : Window {
        //Class level variables
        private Monster battlingMonster = null;

        public frmMonster(Monster newMonster) {
            InitializeComponent();
            battlingMonster = newMonster;
            displayMonsterInfo(battlingMonster);
            displayPlayerInfo();
        }

        /// <summary>
        /// Closes window on ESCAPE or ENTER press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyUp(object sender, KeyEventArgs e) {
            if (e.Key == Key.Escape || e.Key == Key.Enter) {
                this.Close();
            }
            switch (e.Key) {
                case Key.A:
                    bool battling = Game.Map.Adventurer + battlingMonster;

                    displayPlayerInfo();
                    displayMonsterInfo(battlingMonster);

                    if (!Game.Map.Adventurer.isAlive()) {
                        //Hero died
                        Game.GameState = Game.GameStateEnum.Lost;
                        Close();
                    }
                    if (!battlingMonster.isAlive()) {
                        //hero slayed monster
                        Game.Map.Cells[Game.Map.Adventurer.PositionX, Game.Map.Adventurer.PositionY].Monster = null;
                        Close();
                    }
                    break;

                case Key.R:
                    Game.Map.Adventurer.RunningAway = true;
                    bool ranAway = Game.Map.Adventurer + battlingMonster;
                    if (ranAway) {
                        this.Close();
                    }
                    else {
                        //hero died
                        if (!Game.Map.Adventurer.isAlive()) {
                            Game.GameState = Game.GameStateEnum.Lost;
                        }
                        this.Close();
                    }
                    displayPlayerInfo();
                    displayMonsterInfo(battlingMonster);
                    break;
            }
        }

        /// <summary>
        /// Display's the monster's info
        /// </summary>
        /// <param name="newMonster"></param>
        //From Deliverable 5
        public void displayMonsterInfo(Monster newMonster) {
            TextBlock monsterInfo = new TextBlock();
            monsterInfo.TextWrapping = TextWrapping.Wrap;
            //A/an
            string monsterName = newMonster.Name(false);
            char monsterNameFirstLetter = monsterName[0];
            if (monsterNameFirstLetter == 'A' || monsterNameFirstLetter == 'a' || monsterNameFirstLetter == 'E' || monsterNameFirstLetter == 'e'
                || monsterNameFirstLetter == 'I' || monsterNameFirstLetter == 'i' || monsterNameFirstLetter == 'O' || monsterNameFirstLetter == 'o'
                || monsterNameFirstLetter == 'U' || monsterNameFirstLetter == 'u') {
                monsterInfo.Text = "Name: " + newMonster.Name(true) + "\r\n"
                    + "HP: " + newMonster.CurrentHitPoints + "/" + newMonster.MaximumHitPoints;
                tbMonsterDisplay.Text = monsterInfo.Text;
            }
            else {
                monsterInfo.Text = "Name: " + newMonster.Name(true) + "\r\n"
                    + "HP: " + newMonster.CurrentHitPoints + "/" + newMonster.MaximumHitPoints;
                tbMonsterDisplay.Text = monsterInfo.Text;
            }
        }

        /// <summary>
        /// Displays infor for player stats
        /// </summary>
        public void displayPlayerInfo() {
            tbPlayerDisplay.Text = "Name: " + Game.Map.Adventurer.Name(true) + "\r\n" +
                "HP: " + Game.Map.Adventurer.CurrentHitPoints + "/" + Game.Map.Adventurer.MaximumHitPoints;
        }

        /// <summary>
        /// Button to run away
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunAway_Click(object sender, RoutedEventArgs e) {

            Game.Map.Adventurer.RunningAway = true;
            bool ranAway = Game.Map.Adventurer + battlingMonster;
            if (ranAway) {
                this.Close();
            }
            else {
                //hero died
                if (!Game.Map.Adventurer.isAlive()) {
                    Game.GameState = Game.GameStateEnum.Lost;
                }
                this.Close();
            }
            displayPlayerInfo();
            displayMonsterInfo(battlingMonster);
        }

        /// <summary>
        /// Button to attack monster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAttack_Click(object sender, RoutedEventArgs e) {

            bool battling = Game.Map.Adventurer + battlingMonster;

            displayPlayerInfo();
            displayMonsterInfo(battlingMonster);

            if (!Game.Map.Adventurer.isAlive()) {
                //Hero died
                Game.GameState = Game.GameStateEnum.Lost;
                Close();
            }
            if (!battlingMonster.isAlive()) {
                //hero slayed monster
                Game.Map.Cells[Game.Map.Adventurer.PositionX, Game.Map.Adventurer.PositionY].Monster = null;
                Close();
            }
        }
    }
}

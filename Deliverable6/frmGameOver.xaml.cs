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
using CoreObjectsLibrary;

namespace Deliverable6 {
    /// <summary>
    /// Interaction logic for frmGameOver.xaml
    /// </summary>
    public partial class frmGameOver : Window {
        public frmGameOver() {
            InitializeComponent();
            //Set all buttons on
            btnRestart.IsEnabled = true;
            btnExit.IsEnabled = true;
            btnOk.IsEnabled = true;

            int heroX = Game.Map.Adventurer.PositionX;
            int heroY = Game.Map.Adventurer.PositionY;
            if (Game.Map.Cells[heroX, heroY].HasItem) {
                if (Game.Map.Cells[heroX, heroY].Item is Door) {
                    //Cast to door to compare
                    Door mapDoor = (Door)Game.Map.Cells[heroX, heroY].Item;
                    //Has key
                    if (Game.Map.Adventurer.DoorKey != null) {
                        //Has correct key
                        if (Game.Map.Adventurer.DoorKey.KeyCode == mapDoor.DoorCode) {
                            Game.GameState = Game.GameStateEnum.Won;
                        }
                    }
                    //no key or password doesn't match
                    else {
                        Game.GameState = Game.GameStateEnum.Running;
                    }
                }
            }

            if (Game.GameState == Game.GameStateEnum.Won) {
                tbGameOverDisplay.Text = "Congrats you won!";
                btnRestart.Visibility = System.Windows.Visibility.Visible;
                btnExit.Visibility = System.Windows.Visibility.Visible;
                btnOk.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Game.GameState == Game.GameStateEnum.Lost) {
                tbGameOverDisplay.Text = "Sorry, you lost!";
                btnRestart.Visibility = System.Windows.Visibility.Visible;
                btnExit.Visibility = System.Windows.Visibility.Visible;
                btnOk.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Game.GameState == Game.GameStateEnum.Running) {
                tbGameOverDisplay.Text = "Keep playing!";
                btnRestart.Visibility = System.Windows.Visibility.Hidden;
                btnExit.Visibility = System.Windows.Visibility.Hidden;
                btnOk.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void Window_KeyUp(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.R:
                    Game.ResetGame(8, 8);
                    break;
                case Key.E:
                    App.Current.Shutdown();
                    break;
                case Key.O:
                    Close();
                    break;
            }
        }

        /// <summary>
        /// Restart button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestart_Click(object sender, RoutedEventArgs e) {
            Game.ResetGame(8, 8);
        }

        /// <summary>
        /// Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e) {
            //Close entire game
            App.Current.Shutdown();
        }

        /// <summary>
        /// Ok button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, RoutedEventArgs e) {
            //close winodw
            Close();
        }
    }
}

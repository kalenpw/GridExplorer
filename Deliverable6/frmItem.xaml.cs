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
using BaseObjects;

namespace Deliverable6 {
    /// <summary>
    /// Interaction logic for frmItem.xaml
    /// </summary>
    //http://stackoverflow.com/questions/36440663/c-sharp-comparing-first-char-of-string-to-array-of-chars-for-a-an-usage
    public partial class frmItem : Window {
        public frmItem(Item newItem) {
            InitializeComponent();
            //Proper a/an display item
            tbItemDisplay.Text = string.Format("You found {0}: {1}", "aeiouAEIOU".IndexOf(newItem.Name[0]) >= 0 ? "an" : "a", newItem.Name);

        }

        /// <summary>
        /// Event handler on key up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyUp(object sender, KeyEventArgs e) {
            //Not used but game doesn't run when deleted and I'm not sure which KeyUp event to delete to allow me to remove this one
            switch (e.Key) {
                case Key.E:
                    Weapon heroOriginalWeapon = null;
                    if (Game.Map.Adventurer.HasWeapon) {
                        heroOriginalWeapon = Game.Map.Adventurer.Weapon;
                    }
                    Game.Map.Adventurer.ApplyItem(Game.Map.Cells[Game.Map.Adventurer.PositionX, Game.Map.Adventurer.PositionY].Item);
                    Game.Map.Cells[Game.Map.Adventurer.PositionX, Game.Map.Adventurer.PositionY].Item = heroOriginalWeapon;
                    Close();
                    break;
                case Key.D:
                    Close();
                    break;
            }


        }

        /// <summary>
        /// Button to not equip item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDontEquip_Click(object sender, RoutedEventArgs e) {
            //close window if item isn't applied
            Close();
        }

        /// <summary>
        /// Button to equip item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEquip_Click_1(object sender, RoutedEventArgs e) {
            Weapon heroOriginalWeapon = null;
            if (Game.Map.Adventurer.HasWeapon) {
                heroOriginalWeapon = Game.Map.Adventurer.Weapon;
            }
            Game.Map.Adventurer.ApplyItem(Game.Map.Cells[Game.Map.Adventurer.PositionX, Game.Map.Adventurer.PositionY].Item);
            Game.Map.Cells[Game.Map.Adventurer.PositionX, Game.Map.Adventurer.PositionY].Item = heroOriginalWeapon;
            Close();
        }
    }
}

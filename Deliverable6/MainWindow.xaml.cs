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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BaseObjects;
using CoreObjectsLibrary;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Deliverable6 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        //Class level variables
        static int boardWidth = 8;
        static int boardHeight = 8;
        Random rnd = new Random();

        public MainWindow() {
            InitializeComponent();
            //Set column & row definitions
            for (int i = 0; i < boardWidth; i++) {
                grdGameBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < boardHeight; i++) {
                grdGameBoard.RowDefinitions.Add(new RowDefinition());
            }
            //Fill the board
            Game.Map = new Map(boardHeight, boardWidth);
            Game.PlaceHero(Game.Map);
            displayMap(Game.Map);

            updateHeroDetails();
        }

        /// <summary>
        /// Event handler on key up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyUp(object sender, KeyEventArgs e) {
            //Checks which key was pressed
            switch (e.Key) {
                case Key.Up:
                    bool requiresAction = Game.Map.MoveHero("UP");
                    if (requiresAction) {
                        HandleCell(Game.Map.HeroLocation);
                    }
                    displayMap(Game.Map);
                    break;
                case Key.Down:
                    requiresAction = Game.Map.MoveHero("DOWN");
                    if (requiresAction) {
                        HandleCell(Game.Map.HeroLocation);
                    }
                    displayMap(Game.Map);
                    break;
                case Key.Left:
                    requiresAction = Game.Map.MoveHero("LEFT");
                    if (requiresAction) {
                        HandleCell(Game.Map.HeroLocation);
                    }
                    displayMap(Game.Map);
                    break;
                case Key.Right:
                    requiresAction = Game.Map.MoveHero("RIGHT");
                    if (requiresAction) {
                        HandleCell(Game.Map.HeroLocation);
                    }
                    displayMap(Game.Map);
                    break;
                case Key.F5:
                    Game.ResetGame(boardHeight, boardWidth);
                    Game.PlaceHero(Game.Map);
                    displayMap(Game.Map);
                    break;
                case Key.Escape:
                    this.Close();
                    break;
                case Key.S:
                    saveGame();
                    break;
                case Key.L:
                    loadGame();
                    break;
            }
        }

        /// <summary>
        /// If button to refresh the map is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshMap_Click(object sender, RoutedEventArgs e) {
            //ResetMap(boardWidth, boardHeight);       
            Game.ResetGame(8, 8);
            Game.PlaceHero(Game.Map);
            displayMap(Game.Map);
        }

        /// <summary>
        /// If left is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, RoutedEventArgs e) {
            bool requiresAction = Game.Map.MoveHero("LEFT");
            if (requiresAction) {
                HandleCell(Game.Map.HeroLocation);
            }
            displayMap(Game.Map);
        }

        /// <summary>
        /// If  up is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, RoutedEventArgs e) {
            bool requiresAction = Game.Map.MoveHero("UP");
            if (requiresAction) {
                HandleCell(Game.Map.HeroLocation);
            }
            displayMap(Game.Map);
        }

        /// <summary>
        /// If down is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, RoutedEventArgs e) {
            bool requiresAction = Game.Map.MoveHero("DOWN");
            if (requiresAction) {
                HandleCell(Game.Map.HeroLocation);
            }
            displayMap(Game.Map);
        }

        /// <summary>
        /// If right is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, RoutedEventArgs e) {
            bool requiresAction = Game.Map.MoveHero("RIGHT");
            if (requiresAction) {
                HandleCell(Game.Map.HeroLocation);
            }
            displayMap(Game.Map);
        }

        /// <summary>
        /// Displays all of a map's cells with buttons
        /// </summary>
        /// <param name="toDisplay">Map to be displayed</param>
        //http://stackoverflow.com/questions/4517170/create-a-grid-in-wpf-as-template-programmatically
        public void displayMap(Map toDisplay) {
            //Start by clearing map
            grdGameBoard.Children.Clear();
            //Map gameMap = new Map(8, 8);
            for (int i = 0; i < boardHeight; i++) {
                for (int j = 0; j < boardWidth; j++) {
                    Button btnCell = new Button();
                    btnCell.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    btnCell.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                    TextBlock cellDisplay = new TextBlock();
                    cellDisplay.TextWrapping = TextWrapping.Wrap;
                    btnCell.SetValue(Grid.ColumnProperty, i);
                    btnCell.SetValue(Grid.RowProperty, j);
                    //if cell has been discovered
                    if (toDisplay.Cells[i, j].HasBeenSeen) {
                        if (!(toDisplay.Cells[i, j].HasMonster) && !(toDisplay.Cells[i, j].HasItem)) {
                            //cellDisplay.Text = "X";
                            btnCell.Content = cellDisplay;
                        }
                    }
                    //If cell contains an item
                    if (toDisplay.Cells[i, j].HasItem) {
                        //If door
                        if (toDisplay.Cells[i, j].Item is Door) {
                            cellDisplay.Text = toDisplay.Cells[i, j].Item.Name;
                            btnCell.Background = Brushes.SaddleBrown;
                            btnCell.Foreground = Brushes.White;
                            btnCell.Content = cellDisplay;
                        }
                        //if doorkey
                        if (toDisplay.Cells[i, j].Item is DoorKey) {
                            cellDisplay.Text = toDisplay.Cells[i, j].Item.Name;
                            btnCell.Background = Brushes.Yellow;
                            btnCell.Content = cellDisplay;
                        }
                        //if potion
                        if (toDisplay.Cells[i, j].Item is Potion) {
                            cellDisplay.Text = toDisplay.Cells[i, j].Item.Name;
                            btnCell.Background = Brushes.LightSkyBlue;
                            btnCell.Content = cellDisplay;
                        }
                        //if weapon
                        if (toDisplay.Cells[i, j].Item is Weapon) {
                            cellDisplay.Text = toDisplay.Cells[i, j].Item.Name;
                            btnCell.Background = Brushes.Gray;
                            btnCell.Content = cellDisplay;
                        }
                    }
                    //if cell contains monster
                    if (toDisplay.Cells[i, j].HasMonster) {
                        cellDisplay.Text = toDisplay.Cells[i, j].Monster.Name(false);
                        btnCell.Background = Brushes.Red;
                        btnCell.Foreground = Brushes.White;
                        btnCell.Content = cellDisplay;
                    }
                    //Hide cell if it hasn't been discovered
                    if (!toDisplay.Cells[i, j].HasBeenSeen) {
                        btnCell.Background = Brushes.Black;
                        btnCell.Foreground = Brushes.Black;
                        cellDisplay.Text = "";
                        btnCell.Content = cellDisplay;
                    }
                    //Sets hero
                    if (i == Game.Map.Adventurer.PositionX && j == Game.Map.Adventurer.PositionY) {
                        cellDisplay.Text = Game.Map.Adventurer.Name(true);
                        btnCell.Background = Brushes.Blue;
                        btnCell.Foreground = Brushes.White;
                        btnCell.Content = cellDisplay;
                        toDisplay.Cells[i, j].HasBeenSeen = true;
                    }
                    //Add buttons to grid
                    grdGameBoard.Children.Add(btnCell);
                }
            }
        }

        /// <summary>
        /// Displays dialogbox if needed
        /// </summary>
        /// <param name="cell"></param>
        public void HandleCell(MapCell cell) {

            if (cell.HasItem) {
                if (cell.Item is DoorKey) {
                    Game.Map.Adventurer.ApplyItem(cell.Item);
                    updateHeroDetails();
                }
                if (cell.Item is Door) {
                    //Had to cast to compare
                    Door mapDoor = (Door)cell.Item;
                    frmGameOver gameOver = new frmGameOver();
                    gameOver.ShowDialog();
                    return;
                }
                displayMap(Game.Map);
                frmItem founditem = new frmItem(cell.Item);
                founditem.ShowDialog();

                updateHeroDetails();
            }
            if (cell.HasMonster) {
                displayMap(Game.Map);
                frmMonster foundmonster = new frmMonster(cell.Monster);
                foundmonster.ShowDialog();

                updateHeroDetails();
                checkGameState();
            }
        }

        /// <summary>
        /// Save game button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            saveGame();
        }

        /// <summary>
        /// Load game button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e) {
            loadGame();
        }


        /// <summary>
        /// Saves game
        /// </summary>
        public void saveGame() {
            //Code adapted from Captain crunch in class
            SaveFileDialog sfdWhereToSave = new SaveFileDialog();
            sfdWhereToSave.Filter = "Map file | *.map";

            //If user saves or cancels
            bool? saved = sfdWhereToSave.ShowDialog();
            //Saved
            if (saved == true) {
                String fileName = sfdWhereToSave.FileName;
                //Make sure it's a .map file
                if (System.IO.Path.GetExtension(fileName) == ".map") {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                    bf.Serialize(fs, Game.Map);
                    fs.Close();
                }
            }
            else if (saved == false) {
                // cancel save
            }
            else {
                //Shouldn't happen
                MessageBox.Show("uh oh");
            }

        }

        /// <summary>
        /// Load game
        /// </summary>
        public void loadGame() {
            OpenFileDialog ofdFileToOpen = new OpenFileDialog();
            ofdFileToOpen.Filter = "Map file | *.map";
            //
            if (ofdFileToOpen.ShowDialog() == true) {
                string fileName = ofdFileToOpen.FileName;
                if (System.IO.Path.GetExtension(fileName) == ".map") {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                    Game.Map = (Map)bf.Deserialize(fs);
                    displayMap(Game.Map);
                    updateHeroDetails();
                }
            }
        }

        /// <summary>
        /// Checks game state and displays dialogbox if needed
        /// </summary>
        public void checkGameState() {
            if (Game.GameState == Game.GameStateEnum.Lost) {
                frmGameOver gameOver = new frmGameOver();
                gameOver.ShowDialog();
            }
            if (Game.GameState == Game.GameStateEnum.Won) {
                frmGameOver gameOver = new frmGameOver();
                gameOver.ShowDialog();
            }
        }

        /// <summary>
        /// Updates display of player name and health
        /// </summary>
        public void displayPlayerInfo() {
            //Clear Text
            tbPlayerDisplay.Text = "";
            //Populate textblock
            tbPlayerDisplay.Text += "Name: " + Game.Map.Adventurer.Name(true) + "\r\n";
            tbPlayerDisplay.Text += "HP: " + Game.Map.Adventurer.CurrentHitPoints + "/" + Game.Map.Adventurer.MaximumHitPoints;
        }

        /// <summary>
        /// Updates display of items in player's inventory
        /// </summary>
        public void displayInventoryInfo() {
            //Clear text
            tbInventoryDisplay.Text = "";
            //Populate textblock
            //if hero has a weapon
            if (Game.Map.Adventurer.HasWeapon) {
                tbInventoryDisplay.Text += "Weapon: " + Game.Map.Adventurer.Weapon.Name +
                     "(+" + Game.Map.Adventurer.Weapon.AffectValue + ")\r\n";
            }
            //no weapon equipped
            else {
                tbInventoryDisplay.Text += "Weapon: None" + "\r\n";
            }
            //has a key
            if (Game.Map.Adventurer.DoorKey != null) {
                tbInventoryDisplay.Text += "Key: " + Game.Map.Adventurer.DoorKey.KeyCode + "\r\n";
            }
            //no key
            else {
                tbInventoryDisplay.Text += "Key: None";
            }
        }

        /// <summary>
        /// Updates hero name and inventory
        /// </summary>
        public void updateHeroDetails() {
            displayPlayerInfo();
            displayInventoryInfo();
        }
    }
}

// CS/INFO 1182
// Jon Holmes editted by Kalen Williams for deliverable 6
// Description - Representation of our Map. It needs to know everything about what is on the Map.
using System;
using System.Collections.Generic;
using CoreObjectsLibrary;
using BaseObjects;

    namespace BaseObjects {
    [Serializable]
    public class Map {
        #region "Private Variables"
        private MapCell[,] _Cells = null;
        private List<Monster> _Monsters = new List<Monster>();
        private List<Item> _Items = new List<Item>();
        private Hero _Adventurer;
        private Random rnd = new Random();
        private int _cellWidth;
        private int _cellHeight;
        #endregion

        #region "Constructors"
        /// <summary>
        /// Create and fill the Map
        /// </summary>
        /// <param name="rows">Number of Rows the map should have</param>
        /// <param name="cols">Number of Columns the map should have</param>
        public Map(int rows, int cols) {
            _Cells = new MapCell[rows, cols];
            _cellHeight = rows;
            _cellWidth = cols;
            fillMonsters();
            fillItems();
            fillMap();
        }
        #endregion
        #region "Private Methods"
        private void fillItems() {
            _Items.Add(new Potion("Small Healing Potion", 25, Colors.Green));
            _Items.Add(new Potion("Medium Healing Potion", 50, Colors.Blue));
            _Items.Add(new Potion("Large Healing Potion", 100, Colors.Red));
            _Items.Add(new Potion("Extreme Healing Potion", 200, Colors.Purple));

            _Items.Add(new Weapon("Dagger", 10, -1));
            _Items.Add(new Weapon("Club", 20, -3));
            _Items.Add(new Weapon("Sword", 30, -2));
            _Items.Add(new Weapon("Claymore", 40, -4));
        }

        /// <summary>
        /// Fill the List of Monsters
        /// </summary>
        private void fillMonsters() {
            Monsters.Add(new Monster("Orc", "", 3, 100, 0, 0, 10));
            Monsters.Add(new Monster("Goblin", "", 1, 30, 0, 0, 5));
            Monsters.Add(new Monster("Slug", "", 5, 3, 0, 0, 2));
            Monsters.Add(new Monster("Rat", "", 0, 5, 0, 0, 1));
            Monsters.Add(new Monster("Skeleton", "", 4, 70, 0, 0, 7));
        }

        /// <summary>
        /// Fill the map with empty MapCells
        /// </summary>
        private void fillMap() {
            bool keyPlaced = false;
            bool doorPlaced = false;
            bool heroPlaced = false;
            int rows = Cells.GetLength(0);
            int cols = Cells.GetLength(1);
            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {
                    Cells[row, col] = new MapCell();
                }
            }

            //Randomly place 10 monsters
            for (int monsterCount = 0; monsterCount < 10; monsterCount++) {
                int monsterX = rnd.Next(cols);
                int monsterY = rnd.Next(rows);
                if (Cells[monsterX, monsterY].HasItem || Cells[monsterX, monsterY].HasMonster) {
                    //Do nothing if cell contains an item
                    monsterCount--;//Decrment monster count so we still get 10
                }
                else {
                    Cells[monsterX, monsterY].Monster = Monsters[rnd.Next(Monsters.Count)].CreateCopy();
                  //  Cells[monsterX, monsterY].Monster.CreateCopy();
                }
            }

            //Randomly place 15 items
            for (int itemCount = 0; itemCount < 15; itemCount++) {
                int itemX = rnd.Next(cols);
                int itemY = rnd.Next(rows);
                if (Cells[itemX, itemY].HasMonster || Cells[itemX, itemY].HasItem) {
                    //Do nothing if cell already has a monster or item
                    itemCount--;//decrement item count so we get still get 15
                }
                else {
                    Cells[itemX, itemY].Item = Items[rnd.Next(Items.Count)];
                    
                }
            }

            //randomly places one door            
            while (!doorPlaced) {
                int doorX = rnd.Next(cols);
                int doorY = rnd.Next(rows);
                if (Cells[doorX, doorY].HasItem || Cells[doorX, doorY].HasMonster) {
                    //Don't do anything if there is a monster or item
                }
                else {
                    Cells[doorX, doorY].Item = new Door("Door", 0, "hunter2");
                    doorPlaced = true;
                }
                //Randomly place key           
                while (!keyPlaced) {
                    int keyX = rnd.Next(cols);
                    int keyY = rnd.Next(rows);
                    if (Cells[keyX, keyY].HasItem || Cells[keyX, keyY].HasMonster) {
                        //Do nothing if cell has item or monster
                    }
                    else {
                        Cells[keyX, keyY].Item = new DoorKey("Door key", 0, "hunter2");
                        keyPlaced = true;
                    }
                }
            }
            //Place hero once//dont place her in map class place it in game
            if (!heroPlaced) {
                int heroX = rnd.Next(cols);
                int heroY = rnd.Next(rows);
                if (Cells[heroX, heroY].HasItem || Cells[heroX, heroY].HasMonster) {
                    //do nothing if random cell has a monster or item
                }
                else {
                    Hero _Adventurer = new Hero("Bob", "THE bestest", 12, 12, heroX, heroY);
                    
                }
            }
        }

        #endregion
        #region "Public Properties"
        /// <summary>
        /// Get all of the cells of the map
        /// </summary>
        public MapCell[,] Cells {
            get {
                if (_Cells == null) fillMap();
                return _Cells;
            }

            set {
                _Cells = value;
            }
        }
        /// <summary>
        /// Get and Set the Adventurer on the Map
        /// </summary>
        public Hero Adventurer {
            get {
                return _Adventurer;
            }

            set {
                _Adventurer = value;
            }
        }
        /// <summary>
        /// Get the List of Monsters available on our map
        /// </summary>
        public List<Monster> Monsters {
            get {
                return _Monsters;
            }
        }
        /// <summary>
        /// Get the List of Items available on our map
        /// </summary>
        public List<Item> Items {
            get {
                return _Items;
            }
        }

        public MapCell HeroLocation {
            get {
                return _Cells[_Adventurer.PositionX, _Adventurer.PositionY];
            }
        }

        #endregion

        //Methods

        /// <summary>
        /// Moves hero in a direction
        /// </summary>
        /// <param name="directionToMove">Which direction to move hero</param>
        /// <returns>Returns true if hero must take action</returns>
        public bool MoveHero(String directionToMove) {
            switch (directionToMove) {
                case "UP":
                    if (_Adventurer.PositionY > 0) {
                        _Adventurer.Move(Actor.Direction.Up);
                        Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasBeenSeen = true;
                        if(Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasItem
                            || Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasMonster) {
                            return true;
                        }                      
                    }
                    break;

                case "DOWN":
                    if (_Adventurer.PositionY < Cells.GetLength(1)-1) {
                        _Adventurer.Move(Actor.Direction.Down);
                        Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasBeenSeen = true;
                        if (Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasItem
                            || Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasMonster) {
                            return true;
                        }
                    }
                    break;

                case "RIGHT":
                    if (_Adventurer.PositionX < Cells.GetLength(0)-1) {
                        _Adventurer.Move(Actor.Direction.Right);
                        Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasBeenSeen = true;
                        if (Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasItem
                            || Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasMonster) {
                            return true;
                        }
                    }
                    break;

                case "LEFT":
                    if (_Adventurer.PositionX > 0) {
                        _Adventurer.Move(Actor.Direction.Left);
                        Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasBeenSeen = true;
                        if (Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasItem
                            || Cells[_Adventurer.PositionX, _Adventurer.PositionY].HasMonster) {
                            return true;
                        }
                    }
                    break;
            }
            return false;
        }
    }
}

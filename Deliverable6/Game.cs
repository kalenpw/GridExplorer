// Kalen Williams
// CS 1182
// 28 April 2016
// Deliverable 6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects;


namespace Deliverable6 {
    public static class Game {
        //Fields
        private static GameStateEnum _GameState;
        private static Map _GameMap;
        private static int _BoardHeight;
        private static int _BoardWidth;

        //Enums
        public enum GameStateEnum {
            Running,
            Lost,
            Won
        }

        //Properties
        public static GameStateEnum GameState {
            get {
                if (_GameMap.Adventurer.CurrentHitPoints == 0) {
                    _GameState = GameStateEnum.Lost;                    
                }
                
                return _GameState;

            }
            set {
                _GameState = value;
            }
        }

        public static Map Map {
            get {
                return _GameMap;
            }
            set {
                _GameMap = value;
            }
        }

        public static int BoardHeight {
            get {
                return _BoardHeight;
            }

            set {
                _BoardHeight = value;
            }
        }

        public static int BoardWidth {
            get {
                return _BoardWidth;
            }

            set {
                _BoardWidth = value;
            }
        }

        //Methods

        /// <summary>
        /// Resets game by creating new map 
        /// </summary>
        /// <param name="newBoardWidth">Width of game</param>
        /// <param name="newBoardHeight">Height of game</param>
        //http://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number-in-c
        public static void ResetGame(int newBoardWidth, int newBoardHeight) {
            _GameState = GameStateEnum.Running;
            Map = new Map(newBoardWidth, newBoardHeight);  
        }

        /// <summary>
        /// Reset game and passes in board size
        /// </summary>
        public static void ResetGame() {
            ResetGame(BoardHeight, BoardWidth);
        }

        /// <summary>
        /// Places hero randomly
        /// </summary>
        /// <param name="newMap">Creates a new map</param>
        public static void PlaceHero(Map newMap) {
            //Randomly place hero
            Random rnd = new Random();
            int heroX = rnd.Next(newMap.Cells.GetLength(0));
            int heroY = rnd.Next(newMap.Cells.GetLength(1));
            bool heroPlaced = false;
            while (!heroPlaced) {
                if (newMap.Cells[heroX, heroY].HasItem || newMap.Cells[heroX, heroY].HasMonster) {
                    //Don't do anything if cell has contents
                    heroX = rnd.Next(newMap.Cells.GetLength(0));
                    heroY = rnd.Next(newMap.Cells.GetLength(1));
                }
                else {
                    newMap.Adventurer = new Hero("Bob", "THE Bestest", 12, 20, heroX, heroY);
                    heroPlaced = true;
                }
            }
        }
    }
}

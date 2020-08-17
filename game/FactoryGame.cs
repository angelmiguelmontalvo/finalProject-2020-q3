using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.game
{
    public class FactoryGame
    {
        static Game CurrentGame = new Game();
        public static void CreateGame()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("*          CHECK GAME           ");
            Console.WriteLine("********************************");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            GameMenu();
            PlayNextMovement();
        }

        public static void GameMenu()
        {
            CurrentGame = new Game();
            SetPlayers();
        }

        public static void SetPlayers() {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("-        Set players data    -");
            Console.WriteLine("------------------------------");
            Color colorPlayer1 = GetRandomColor();
            Color colorPlayer2 = colorPlayer1 == Color.White ? Color.Black : Color.White;
            Console.WriteLine("Enter player1 name: ");
            String namePlayer1 = Console.ReadLine();
            int indexPlayer1 = colorPlayer1 == Color.White ? 0 : 1;
            Player player1 = new Player(namePlayer1, colorPlayer1, indexPlayer1);
            Console.WriteLine("Enter player2 name: ");
            String namePlayer2 = Console.ReadLine();
            int indexPlayer2 = colorPlayer2 == Color.White ? 0 : 1;
            Player player2 = new Player(namePlayer2, colorPlayer2, indexPlayer2);
            Console.WriteLine(player1.ToString());
            Console.WriteLine(player2.ToString());
            CurrentGame.GamePlayers.AddPlayers(player1, player2);
            CurrentGame.Turn = CurrentGame.GamePlayers[0];
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static Color GetRandomColor() {
            Random random = new Random();
            int coin = random.Next(0, 10);
            if (coin <= 5)
            {
                return Color.White;
            }
            return Color.Black;
        }

        public static void PlayNextMovement() {
            // This todo validate game status here
            while (!CurrentGame.GameOver()) {
                Console.WriteLine($"Turn of {CurrentGame.Turn.ToString()}");
                Console.WriteLine("1. Set movement");
                Console.WriteLine("2. Resignation");
                Console.WriteLine("3. More time");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        // If is the movement is a checkmat avoid set next player
                        CurrentGame.SetNextPlayer();
                        ReadCommand();
                        break;
                    case "2":
                        CurrentGame.SetResignation();
                        break;
                    case "3":
                        Console.WriteLine("Waiting....");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Bad option");
                        break;
                }
            }
            if (CurrentGame.Result == GameResult.Draw) {
                Console.WriteLine("*************DRAW GAME ************");
            } else 
            {
                Console.WriteLine($"Winner is {CurrentGame.Turn.ToString()}");
            }
        }

        public static void ReadCommand() {
            string command = CurrentGame.ReadCommand();
            Object piece = new object();
            string source = CurrentGame.GetCell(command, CellType.Source);
            string target = CurrentGame.GetCell(command, CellType.Target);
            CurrentGame.AddMovement(new Movement(piece, CurrentGame.Turn, source, target, command));
        }
    }
}

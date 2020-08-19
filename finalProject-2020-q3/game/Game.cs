using finalProject_2020_q3.game.movement;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace finalProject_2020_q3.game
{
	public class Game
	{
		String CommandRegex = @"\b[S]\([1-8][a-h]\)T\([1-8][a-h]\)";
		String CellsRegex = @"(?<=\()[1-8][a-h](?=\))";
							
		public Players GamePlayers = new Players();
		public Player Turn { set; get; }
		public GameStatus Status { set; get; }
		public GameResult Result { get; private set; }
		public Movements GameMovements = new Movements();
		public Game()
		{
			Result = GameResult.Play;
			Status = GameStatus.Draw;
		}

		public Boolean IsValidCommand(string command)
		{
			var result = Regex.IsMatch(command, CommandRegex);
			if (result) {
				var cells = Regex.Matches(command, CellsRegex);
				var source = cells[0].Value;
				var target = cells[1].Value;
				result = String.Equals(source, target, StringComparison.OrdinalIgnoreCase);
				return !result;
			}
			return result;
		}

		public string ReadCommand()
		{
			Console.WriteLine("-------------------------");
			Console.WriteLine("- Enter command format: -");
			Console.WriteLine("-      S(1a)T(2a)       -");
			Console.WriteLine("-------------------------");
			string command = Console.ReadLine();
			while (!this.IsValidCommand(command))
			{
				Console.WriteLine("Bad command try again");
				command = Console.ReadLine();
			}
			return command;
		}

		public string GetCell(string command, CellType type)
		{
			var cells = Regex.Matches(command, CellsRegex);
			var source = cells[0].Value;
			var target = cells[1].Value;
			switch (type)
			{
				case CellType.Source:
					return source;
				case CellType.Target:
					return target;
				default:
					return null;
			}
		}

		public Boolean IsValidMovement()
		{
			return true;
		}

		public void SetFirstTurn()
		{
			Turn = GamePlayers[0].PlayerTurn < GamePlayers[1].PlayerTurn ? GamePlayers[0] : GamePlayers[1];
		}

		public Player GetNextPlayer()
		{
			var index = Turn.PlayerTurn == 0 ? 1 : 0;
			return GamePlayers[index];
		}

		public void SetNextPlayer() {
			var index = Turn.PlayerTurn == 0 ? 1 : 0;
			Turn = GamePlayers[index];
		}

		public Boolean GameOver()
		{
			return Result == GameResult.BlackWin || Result == GameResult.WhiteWin || Result == GameResult.Draw;
		}

		public void SetResignation() {
			Result = Turn.PlayerColor == Color.Black ? GameResult.WhiteWin : GameResult.BlackWin;
			SetNextPlayer();
		}

		public void AddMovement(Movement nextMovement)
		{
			GameMovements.Add(nextMovement);
		}
	}
}

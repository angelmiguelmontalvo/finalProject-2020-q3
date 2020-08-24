using finalProject_2020_q3.game.movement;
using finalProject_2020_q3.code;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace finalProject_2020_q3.game
{
	public class Game
	{
		String CommandRegex = @"\b[S]\([1-8][a-h]\)T\([1-8][a-h]\)";
		String CellsRegex = @"(?<=\()[1-8][a-h](?=\))";
		String SelectRegex = @"\b[P]\([1-8][a-h]\)";

		public Players GamePlayers = new Players();
		public Player Turn { set; get; }
		public GameStatus Status { set; get; }
		public GameResult Result { get; set; }
		public Movements GameMovements = new Movements();
		public Board GameBoard = new Board();
		public Drawer GameDrawer { get; set; }
		private Color TopColor;
		public Game()
		{
			Result = GameResult.Play;
			Status = GameStatus.Draw;
			GameDrawer = new Drawer(GameBoard);
			Cell king = GameBoard.GetKingCell(Color.WHITE, GameBoard.Sets);
		}

		public void SetTopColor(Color topColor)
		{
			this.TopColor = topColor;
			this.GameBoard.TopColor = topColor;
			this.GameBoard.InitPieces();
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
			return Regex.IsMatch(command, SelectRegex);
		}

		public Boolean IsSelectCommand(string command)
        {
			return Regex.IsMatch(command, SelectRegex);
		}

		public Boolean IsMovementCommand(string command)
        {
			var result = Regex.IsMatch(command, CommandRegex);
			if (result)
			{
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
			Console.WriteLine("-      P(2a)            -");
			Console.WriteLine("-------------------------");
			string command = Console.ReadLine();
			while (!this.IsValidCommand(command))
			{
				Console.WriteLine("Bad command try again");
				command = Console.ReadLine();
			}
			return command;
		}

		public Cell GetCell(string command, CellType type)
		{
			var cells = Regex.Matches(command, CellsRegex);
			var source = cells[0].Value;
			var target = cells[0].Value;
			if (cells.Count > 1) { 
				target = cells[1].Value;
			}
			switch (type)
			{
				case CellType.Source:
					return GameBoard.GetCell(source);
				case CellType.Target:
					return GameBoard.GetCell(target);
				default:
					return null;
			}
		}

		public void ApplyMovement(Cell source, Cell target)
        {
			if (GameBoard.IsPromotion(source, target))
			{
				PieceType promotedPieceType = ReadPromotedPiece();
				GameBoard.ApplyMovement(source, target, promotedPieceType);
			}
			else
			{
				GameBoard.ApplyMovement(source, target);
			}
		}

		private PieceType ReadPromotedPiece()
		{
			string optionsPattern = @"^[1-4]$";
			Dictionary<string, PieceType> promoteOptions = new Dictionary<string, PieceType>()
            {
				{ "1", PieceType.BISHOP },
				{ "2", PieceType.KNIGHT },
				{ "3", PieceType.ROOK },
				{ "4", PieceType.QUEEN }
			};
            ShowPromotionOptions();
			string selectedOption = Console.ReadLine();
			while (!Regex.IsMatch(selectedOption, optionsPattern))
			{
				Console.WriteLine("Bad command try again");
				selectedOption = Console.ReadLine();
			}
			return promoteOptions[selectedOption];
		}

        private void ShowPromotionOptions()
		{
			Console.WriteLine("--------------------------------");
			Console.WriteLine("- Select piece to be promoted: -");
			Console.WriteLine("1. Bishop");
			Console.WriteLine("2. Knight");
			Console.WriteLine("3. Rook");
			Console.WriteLine("4. Queen");
			Console.WriteLine("--------------------------------");
		}

        public Boolean IsValidMovement()
		{
			return true;
		}

		public bool IsStatusCheck()
        {
			return Status != GameStatus.Draw;
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
			bool result = Result == GameResult.BlackWin || Result == GameResult.WhiteWin || Result == GameResult.Draw;
			if (result) {
				Console.WriteLine(ResultToString());
			}
			return result;
		}

		public void SetResignation() {
			Result = Turn.PlayerColor == Color.BLACK ? GameResult.WhiteWin : GameResult.BlackWin;
			SetNextPlayer();
		}

		public void AddMovement(Movement nextMovement)
		{
			GameMovements.Add(nextMovement);
		}

		public string PrintMovements(CellList cellList, Cell source)
        {
			StringBuilder builder = new StringBuilder();
			builder.Append("Posible movements:");
			foreach (Cell target in cellList) 
			{
				builder.Append($"\nS({source.ToString()})T({target.ToString()})");
			}
			return builder.ToString();
		}

		public void SetStatus(Color color)
        {
			Status = GameBoard.GetGameStatus(color, GameBoard.Sets);
			if (Status != GameStatus.Draw) {
				Status = GameBoard.ValidateCheckMate(Status);
			}
		}

		public string StatusToString() {
			StringBuilder result = new StringBuilder();
			Player player;
			switch (Status)
			{
				case GameStatus.Draw:
					break;
				case GameStatus.BlackInCheck:
					player = GamePlayers.GetPlayer(Color.BLACK);
					result.Append($"Player {player.ToString()} is in check");
					break;
				case GameStatus.WhiteInCheck:
				    player = GamePlayers.GetPlayer(Color.WHITE);
					result.Append($"Player {player.ToString()} is in check");
					break;
				default:
					break;
			}
			return result.ToString();
		}

		public void SetResult()
		{
			if (Status == GameStatus.Draw && GameBoard.Result == GameResult.Play)
			{
				Result = GameResult.Play;
			} else { 
				Result = GameBoard.GetGameResult(Status);
			}
		}

		public string ResultToString()
		{
			StringBuilder result = new StringBuilder();
			Player playerBlack = GamePlayers.GetPlayer(Color.BLACK);
			Player playerWhite = GamePlayers.GetPlayer(Color.WHITE);
			Console.WriteLine(Result);
			if (Result == GameResult.BlackWin)
			{
				if (Status == GameStatus.WhiteInCheckMatted) {
					result.Append($"{playerWhite.ToString()} is checkmated.");
				}
				result.Append($"\n{playerBlack.ToString()} won.");
			}
			if (Result == GameResult.WhiteWin)
			{
				if (Status == GameStatus.BlackInCheckMatted) {
					result.Append($"{playerBlack.ToString()} is checkmated.");
				}
				result.Append($"\n{playerWhite.ToString()} won.");
			}
			if (Result == GameResult.Draw)
			{
				result.Append("Draw game.");
			}
			return result.ToString();
		}
		public void Reset()
		{
			Result = GameResult.Play;
			Status = GameStatus.Draw;
			GameMovements = new Movements();
			GameBoard = new Board();
			GameDrawer = new Drawer(GameBoard);
			SetFirstTurn();
			SetTopColor(this.TopColor); 
		}
		public void Castling()
		{
			Cell king = GameBoard.GetKingCell(Turn.PlayerColor);
			bool res = GameBoard.Castling(king);
			string message;
            if (res){
				SetNextPlayer();
				message ="** Castled Sucess **";
			}
            else
            {
				message = "** No able to castle **";
			}
			Console.WriteLine("--------------------------------");
			Console.WriteLine(message);
			Console.WriteLine("--------------------------------");
		}
	}

}

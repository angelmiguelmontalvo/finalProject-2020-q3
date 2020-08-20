using finalProject_2020_q3.code;
using System;

namespace finalProject_2020_q3.game
{ 
	public class Movement
	{
		String Command { set; get; }
		Cell Source { set; get; }
		Cell Target { set; get; }
		Object Piece { set; get; }
		Player CurrentPlayer { get; set; }
		public Movement(Object currentPiece, Player player, Cell source, Cell target, string command)
		{
			Piece = currentPiece;
			CurrentPlayer = player;
			Source = source;
			Target = target;
			Command = command;
		}

		public void SetCommand(string command)
		{
		    Command = command;
		}

		public override string ToString()
        {
			return $"{CurrentPlayer.ToString()} Piece: piece {Command}";
        }
	}
}

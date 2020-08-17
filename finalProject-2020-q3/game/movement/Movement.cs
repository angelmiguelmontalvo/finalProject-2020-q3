using System;

namespace finalProject_2020_q3.game
{ 
	public class Movement
	{
		String Command { set; get; }
		String Source { set; get; }
		String Target { set; get; }
		Object Piece { set; get; }
		Object CurrentPlayer { get; set; }
		public Movement(Object currentPiece, Object player, string source, string target, string command)
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

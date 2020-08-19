using System;

namespace finalProject_2020_q3.game
{ 
	public class Player
	{
		String PlayerName { set; get; }
		public Color PlayerColor;
		public int PlayerTurn { set; get; }
		public Player(string name, Color color, int index)
		{
			PlayerName = name;
			PlayerColor = color;
			PlayerTurn = index;
		}

        public override string ToString()
        {
			return $"Player-{PlayerTurn}: {PlayerName} plays with {PlayerColor}";
        }

		public override Boolean Equals(Object playerObject)
        {
			if (playerObject is Player) {
				Player playerCompare = (Player)playerObject;
				return playerCompare.PlayerColor == PlayerColor;
			}
			return false;
        }

		public override int GetHashCode()
        {
			return PlayerColor.GetHashCode();
        }
    }
}

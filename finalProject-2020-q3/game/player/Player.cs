using System;

namespace finalProject_2020_q3.game
{ 
	public class Player
	{
		String PlayerName { set; get; }
		public Color PlayerColor;
		public int PlayerIndex { set; get; }
		public Player(string name, Color color, int index)
		{
			PlayerName = name;
			PlayerColor = color;
			PlayerIndex = index;
		}

        public override string ToString()
        {
			return $"Player-{PlayerIndex}: {PlayerName} plays with {PlayerColor}";
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

using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.game
{
    public class Players: List<Player>
    {
        public void AddPlayers(Player player1, Player player2)
        {
            if (player1.PlayerColor == Color.White)
            {
                this.Add(player1);
                this.Add(player2);
            }
            if (player2.PlayerColor == Color.White)
            {
                this.Add(player2);
                this.Add(player1);
            }
        }
    }    
}

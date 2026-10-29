using System;
using UnityEngine;

public class TurnController : Singleton<TurnController>
{
    private Player playerInControl;
    private Player[] playersInGame;

    public void Start()
    {
        playersInGame = new Player[Settings.NumOfPlayers];
    }

    public void RegisterPlayer(Player player)
    {
        for (int i = 0; i < playersInGame.Length; i++)
        {
            if (playersInGame[i] == null)
            {
                playersInGame[i] = player;
                return;
            }
        }
    }
    
    public void RemovePlayer(Player player)
    {
        for (int i = 0; i < playersInGame.Length; i++)
        {
            if (playersInGame[i] == player)
            {
                playersInGame[i] = null;
                return;
            }
        }
    }
    
    public int GetPlayerIndex(Player player)
    {
        for (int i = 0; i < playersInGame.Length; i++)
        {
            if (playersInGame[i] == player)
            {
                return i;
            }
        }

        return -1;
    }
}

using System;
using UnityEngine;

public class TurnController : Singleton<TurnController>
{
    private Player playerInControl;
    [SerializeField] private Player[] playersInGame;

    public void Start()
    {
        playersInGame = new Player[Settings.Instance.data.numOfPlayers];
        Debug.Log("Turn Controller initialized");
    }

    public void RegisterPlayer(Player player)
    {
        for (int i = 0; i < playersInGame.Length; i++)
        {
            Debug.Log(i);
            if (playersInGame[i] == null)
            {
                playersInGame[i] = player;
                return;
            }
        }
        Debug.LogError("Too many players in game");
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

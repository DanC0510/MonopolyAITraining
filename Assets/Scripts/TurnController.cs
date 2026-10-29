using System;
using UnityEngine;

public class TurnController : Singleton<TurnController>
{
    [SerializeField] private Player playerInControl;
    [SerializeField] private Player[] playersInGame;
    int turnNumber;

    public void Start()
    {
        playersInGame = new Player[Settings.Instance.data.numOfPlayers];
        Debug.Log("Turn Controller initialized");
    }

    public void StartGame()
    {
        Debug.Log("Starting game");
        foreach (Player player in playersInGame)
        {
            if (player == null)
            {
                Debug.LogError("Not Enough Players in Game");
                return;
            }
        }
        Array.Sort(playersInGame, delegate (Player player1, Player player2) { return player1.PlayerIndex.CompareTo(player2.PlayerIndex);});
        playerInControl = playersInGame[0];
        playerInControl.StartTurn();
    }

    public void EndTurn()
    {
        turnNumber++;
        playerInControl = playersInGame[Helpers.mod(playerInControl.PlayerIndex + 1, playersInGame.Length)];
        if (turnNumber <= 60)
        {
            playerInControl.StartTurn();
        }
        else
        {
            float totalRoll = 0;
            foreach (Player player in playersInGame)
            {
                if (player == null) { return; }
                totalRoll += player.PlayerPosition;
            }
        }
    }

    public void RegisterPlayer(Player player)
    {
        for (int i = 0; i < playersInGame.Length; i++)
        {
            if (playersInGame[i] == null)
            {
                playersInGame[i] = player;
                player.SetPlayerIndex(i);
                StartGame();
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
    
}

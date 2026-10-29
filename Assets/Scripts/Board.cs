using UnityEditor;
using UnityEngine;

public class Board : Singleton<Board>
{
    private int[] playerPositions;
    private Player playerInControl;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPositions = new int[Settings.Instance.data.numOfPlayers];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

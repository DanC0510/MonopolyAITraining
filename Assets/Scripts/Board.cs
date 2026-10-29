using UnityEditor;
using UnityEngine;

public class Board : Singleton<Board>
{
    private int[] playerPositions;
    private Player playerInControl;

    void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPositions = new int[Settings.NumOfPlayers];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

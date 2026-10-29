using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private int playerPosition;
    private int min = 0;
    private int max = 6;

    public int PlayerIndex { get => playerIndex; }
    public int PlayerPosition { get => playerPosition; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnController.Instance.RegisterPlayer(this);
    }
    
    public void SetPlayerIndex(int index) { playerIndex = index; }

    public void StartTurn()
    {
        Roll();
    }

    void Roll()
    {
        int roll1 = Random.Range(max, min);
        int roll2 = Random.Range(max, min);
        playerPosition += (roll1 + roll2);
        TurnController.Instance.EndTurn();
    }
}

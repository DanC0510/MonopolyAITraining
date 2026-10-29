using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private int playerPosition;
    private int min = 0;
    private int max = 6;
    private TurnAction playerAction;

    public int PlayerIndex { get => playerIndex; }
    public int PlayerPosition { get => playerPosition; }
    public TurnAction PlayerAction { get => playerAction; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnController.Instance.RegisterPlayer(this);
    }
    
    public void SetPlayerIndex(int index) { playerIndex = index; }

    public void GetInput()
    {
        //Make UI Appear Here to allow player to select action
    }

    public void StartTurn()
    {
        switch(playerAction)
        {
            case TurnAction.Roll:
                Roll();
                break;
            case TurnAction.Build:
                break;
            case TurnAction.Mortgage:
                break;
            case TurnAction.Bankrupt:
                break;
        }
    }

    void Roll()
    {
        int roll1 = Random.Range(max, min);
        int roll2 = Random.Range(max, min);
        playerPosition += (roll1 + roll2);
        TurnController.Instance.EndTurn();
    }

    public enum TurnAction
    {
        Roll,
        Build,
        Mortgage,
        Bankrupt,
    }
}

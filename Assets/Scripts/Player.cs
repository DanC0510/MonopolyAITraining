using UnityEngine;

public class Player : MonoBehaviour
{
    private int playerIndex;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnController.Instance.RegisterPlayer(this);
        playerIndex = TurnController.Instance.GetPlayerIndex(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

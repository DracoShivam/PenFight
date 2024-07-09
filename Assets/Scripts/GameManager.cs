using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private FlickObject playerController;
    

    private bool isPlayer1Turn = true;

    void Start()
    {
        // Initialize the game by starting with Player 1's turn
        EnablePlayerControls(player1);
        DisablePlayerControls(player2);
    }

    void Update()
    {
        // Check for input to pass the turn
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchTurn();
        }
    }

    void SwitchTurn()
    {
        if (isPlayer1Turn)
        {
            // Switch turn to Player 2
            DisablePlayerControls(player1);
            EnablePlayerControls(player2);
        }
        else
        {
            // Switch turn to Player 1
            DisablePlayerControls(player2);
            EnablePlayerControls(player1);
        }

        isPlayer1Turn = !isPlayer1Turn;
    }

    void EnablePlayerControls(GameObject player)
    {
        // Enable player controls by setting the script or component active
        player.GetComponent<FlickObject>().enabled = true;
    }

    void DisablePlayerControls(GameObject player)
    {
        // Disable player controls by setting the script or component inactive
        player.GetComponent<FlickObject>().enabled = false;
    }
}

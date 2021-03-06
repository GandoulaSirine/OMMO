﻿using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;
   
    public static GameObject player1, player2;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;


    // Use this for initialization
    void Start()
    {

        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player1.GetComponent<FollowThePath>().waypointIndex >
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
            Dice.coroutineAllowed = true;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
            Dice.coroutineAllowed = true;
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex ==
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            gameOver = true;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
            gameOver = true;
        }
    }

    public static int MovePlayer(int playerToMove)
    {
        print(player1.GetComponent<FollowThePath>().waypointIndex + "<=" + player2.GetComponent<FollowThePath>().waypointIndex+"pp"+ playerToMove);
        if (player1.GetComponent<FollowThePath>().waypointIndex <= player2.GetComponent<FollowThePath>().waypointIndex)
        {
            player2.GetComponent<FollowThePath>().stop = false;
            print(1);
        }
        else if (player1.GetComponent<FollowThePath>().stop&& playerToMove==0)
        {
            print(2);
            playerToMove = (playerToMove + 1) % 2;
        }
            
        if (player2.GetComponent<FollowThePath>().waypointIndex <= player1.GetComponent<FollowThePath>().waypointIndex)
        {
            player1.GetComponent<FollowThePath>().stop = false;
            print(3);
        }
        else if (player2.GetComponent<FollowThePath>().stop&& playerToMove == 1)
        {
            playerToMove = (playerToMove + 1) % 2;
            print(4);
        }
        print("pp" + playerToMove);
        switch (playerToMove)
        {
            case 0:
                player1.GetComponent<FollowThePath>().moveAllowed = true;  
                break;

            case 1:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
        
        
        return (playerToMove + 1) % 2;
    }


 

}

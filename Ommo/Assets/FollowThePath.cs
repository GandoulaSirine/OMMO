using UnityEngine;
using System.Collections;





public class FollowThePath : MonoBehaviour
{

    float t=-1;
    public Transform[] waypoints;
    public bool stop;
    [SerializeField]
    private float moveSpeed = 1f;

    int stopPoint;
    public int waypointIndex = 0;

    public bool moveAllowed = false;
    public bool moveBack = false;
    public bool maj = false;
    bool dontMove;
    

    // Use this for initialization
    private void Start()
    {
       
        transform.position = waypoints[waypointIndex].transform.position;
    }
   
    
    
    
    
    


    // Update is called once per frame
    private void Update()
    {
        if (t < 0)
        {

            if (moveBack)
            {
                Dice.coroutineAllowed = false;
                MoveBack();

                if (waypoints[stopPoint].transform.position == transform.position)
                {
                    moveBack = false;
                    transform.position = waypoints[stopPoint].transform.position;
                    GameControl.player1StartWaypoint = GameControl.player1.GetComponent<FollowThePath>().waypointIndex;
                    Dice.coroutineAllowed = true;
                    GameControl.player2StartWaypoint = GameControl.player2.GetComponent<FollowThePath>().waypointIndex;
                }
            }
            else if (moveAllowed || maj)
            {
                Move();
                Dice.coroutineAllowed = false;
                dontMove = false;
                
            }
            else if (waypoints[2].transform.position == transform.position)
            {
                t = 2;
                stopPoint =8 ;
                maj = true;
            }
            else if (waypoints[14].transform.position == transform.position)
            {
                t = 2;
                stopPoint =14+ GameControl.diceSideThrown;
                maj = true;
            }
            else if (waypoints[17].transform.position == transform.position)
            {
                t = 2;
                print("hhh");
                moveAllowed = false;
                moveBack = true;
                stopPoint = 1;
                waypointIndex = 17;
            }
            else if (waypoints[8].transform.position == transform.position&&!dontMove)
            {
               
                    t = 2;
                    print("hhh");
                    moveAllowed = false;
                    moveBack = true;
                    stopPoint = 5;
                    waypointIndex = 8;
                    dontMove = false;
                
            }
            else if (waypoints[31].transform.position == transform.position)
            {
                t = 2;
                print("hhh");
                moveAllowed = false;
                moveBack = true;
                stopPoint = 19;
                waypointIndex = 31;
            }
            else if (waypoints[24].transform.position == transform.position&&!stop)
            {
                
                stop = true;
                Dice.coroutineAllowed = true;
            }
                if (waypoints[stopPoint].transform.position == transform.position&& maj)
            {
                maj = false;
                Dice.coroutineAllowed = true;
                moveBack = false;
                dontMove = true;
                
            }
        }
        else
        {
            Dice.coroutineAllowed = false;
            t -= Time.deltaTime;
            
        }
    }

private void Move()
    {
       
        if (waypointIndex <= waypoints.Length - 1)
            {

                transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

                if (transform.position == waypoints[waypointIndex].transform.position)
                {

                    waypointIndex += 1;
                }

            }
    }

    private void MoveBack()
    {
       
        if (waypointIndex <= waypoints.Length - 1)
        {
            if (transform.position == waypoints[waypointIndex].transform.position)
            {

                waypointIndex -= 1;


            }

            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

        }


    }


}

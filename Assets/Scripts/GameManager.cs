using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    //set up for display graphics and buttons
    public GUISkin layout;

    GameObject theBall;

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    //detects when the ball hits side walls
    public static void Score(string wallID)
    {
        if (wallID == "RightWall") {
            PlayerScore1++;
        }

        else {
            PlayerScore2++;
        }
    }

    //displays score and reset button
    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        //triggers RestartBall function from BallControl script
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART")) {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        //triggers ResetBall function from BallControl script
        if (PlayerScore1 == 10) {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }

        else if (PlayerScore2 == 10) {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

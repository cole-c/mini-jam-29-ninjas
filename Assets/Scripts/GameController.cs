using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float deathRadius = 1f;

    private static Vector2 playerRespawnPos;
    private Vector2 playerStartPos;
    private GameObject[] hazards;
    private GameObject[] checkpoints;
    private GameObject[] endpoints;
    private GameObject player;
    private GameObject activeCheckPoint;

    public Sprite inactiveCheckpointSprite;
    public Sprite activeCheckpointSprite;

    private static bool dead = false;
    private static bool winner = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerRespawnPos = playerStartPos = Pos2d(player);
        }

        hazards = GameObject.FindGameObjectsWithTag("InstantDeath");

        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        endpoints = GameObject.FindGameObjectsWithTag("Endpoint");

    }

    // Update is called once per frame
    void Update()
    {
        if(hazards != null)
        {
            foreach (GameObject hazard in hazards)
            {
                if (Vector2.Distance(Pos2d(player), Pos2d(hazard)) < deathRadius)
                {
                    dead = true;
                }
            }
        }

        if (checkpoints != null)
        {
            foreach (GameObject checkpoint in checkpoints)
            {
                if (Vector2.Distance(Pos2d(player), Pos2d(checkpoint)) < 1)
                {
                    playerRespawnPos = Pos2d(checkpoint);

                    activeCheckPoint = checkpoint;
                    checkpoint.GetComponent<SpriteRenderer>().sprite = activeCheckpointSprite;
                }

                if(checkpoint != activeCheckPoint)
                {
                    checkpoint.GetComponent<SpriteRenderer>().sprite = inactiveCheckpointSprite;
                }
            }
        }

        if(endpoints != null)
        {
            foreach (GameObject endpoint in endpoints)
            {
                if (Vector2.Distance(Pos2d(player), Pos2d(endpoint)) < 1)
                {
                    winner = true;
                }
            }
        }

    }

    public static Vector2 Pos2d(GameObject thing)
    {
        return new Vector2(thing.transform.position.x, thing.transform.position.y);
    }

    Rect _quitWindowRect = new Rect(Screen.width / 2 - 125, Screen.height / 2 - 25, 250, 80);
    Rect _winWindowRect = new Rect(Screen.width / 2 - 125, Screen.height / 2 - 25, 250, 100);

    void OnGUI()
    {
        if (dead)
        {
            GUI.Window(1, _quitWindowRect, QuitWindowFunction, "You died, restart at last checkpoint?");
        }

        if(winner)
        {
            GUI.Window(1, _winWindowRect, WinnerWindowFunction, "You Won the Game! Congratulations! \n Would you like to restart?");
        }
    }

    void QuitWindowFunction(int id)
    {
        if (GUI.Button(new Rect(20, 20, 100, 40), "Yes"))
        {
            player.transform.position = playerRespawnPos;

            dead = false;
        }
        if (GUI.Button(new Rect(135, 20, 100, 40), "No"))
        {
            Application.Quit();
        }
    }

    void WinnerWindowFunction(int id)
    {
        if (GUI.Button(new Rect(20, 40, 100, 40), "Yes"))
        {
            player.transform.position = playerStartPos;

            winner = false;
        }
        if (GUI.Button(new Rect(135, 40, 100, 40), "No"))
        {
            Application.Quit();
        }
    }

    public static bool isAlive()
    {
        if (winner)
        {
            return false;
        }
        return !dead;
    }

    public static void playerKilled()
    {
        dead = true;
    }

    public static Vector2 getRespawnPoint()
    {
        return playerRespawnPos;
    }
}

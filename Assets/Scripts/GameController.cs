using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float deathRadius = 1f;

    private Vector2 playerStartingPos;
    private GameObject[] hazards;
    private GameObject[] checkpoints;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            playerStartingPos = Pos2d(player);
        }

        hazards = GameObject.FindGameObjectsWithTag("InstantDeath");

        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    // Update is called once per frame
    void Update()
    {

        foreach(GameObject hazard in hazards)
        {
            if (Vector2.Distance(Pos2d(player), Pos2d(hazard)) < deathRadius)
            {
                //TODO death screen graphics

                player.transform.position = playerStartingPos;
            }
        }

        foreach(GameObject checkpoint in checkpoints)
        {
            if(Vector2.Distance(Pos2d(player), Pos2d(checkpoint)) < 1)
            {
                //TODO checkpoint animation

                playerStartingPos = Pos2d(checkpoint);
            }
        }
    }

    private Vector2 Pos2d(GameObject thing)
    {
        return new Vector2(thing.transform.position.x, thing.transform.position.y);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float deathRadius = 1f;

    private Vector2 playerStartingPos;
    private GameObject[] hazards;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Debug.Log("PLAYER FOUND");
        }
        
        if(hazards.Length > 0)
        {
            Debug.Log("HAZARDS FOUND");
        }

        foreach(GameObject hazard in hazards)
        {
            if (Vector2.Distance(Pos2d(player), Pos2d(hazard)) < deathRadius)
            {
                //TODO death screen graphics

                player.transform.position = playerStartingPos;
                Debug.Log("hazard pos:" + Pos2d(hazard));
                Debug.Log("player pos:" + Pos2d(player));
                Debug.Log(Vector2.Distance(Pos2d(player), Pos2d(hazard)));
                Debug.Log("   ");
            }
        }
    }

    private Vector2 Pos2d(GameObject thing)
    {
        return new Vector2(thing.transform.position.x, thing.transform.position.y);
    }


}

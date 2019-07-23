using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkTowerController : MonoBehaviour
{
    public GameObject Watchman;
    public GameObject lightSwitch;
    public GameObject spotlight;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(GameController.Pos2d(player), GameController.Pos2d(lightSwitch)) < 1)
        {
            Destroy(spotlight);
            Destroy(Watchman);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    public int offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if(player != null)
        {
            transform.position = new Vector3(player.transform.position.x + offset, player.transform.position.y, -15);
        } else
        {
            Debug.Log("Your Camera is messed up because you don't have a tagged Player");
        }
        
    }
}

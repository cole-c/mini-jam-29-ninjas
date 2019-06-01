using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControllerScript : MonoBehaviour
{
    public float actualSpeed = 10.0f;
    public GameObject[] Waypoints;
    public float distance; //on which distance you want to switch to the next waypoint

    private int counter = 0;
    private Vector2 velocity;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("CURRENT POSITION: " + transform.position);
        Debug.Log("WAYPOINT POSITION: " + Waypoints[counter].transform.position);
        Debug.Log("COUNTER: " + counter);
        direction = Vector3.zero;
        //get the vector from your position to current waypoint
        direction = Waypoints[counter].transform.position - transform.position;
        Debug.Log("DIRECTION: " + direction.magnitude);
        Debug.Log("DISTANCE: " + distance);
        //check our distance to the current waypoint, Are we near enough?
        if (direction.magnitude < distance)
        {
            if (counter < Waypoints.Length - 1) //switch to the nex waypoint if exists
            {
                counter++;
            }
            else //begin from new if we are already on the last waypoint
            {
                counter = 0;
            }
        }

        direction = direction.normalized;
        Vector3 dir = direction;
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * actualSpeed, direction.y * actualSpeed);
    }
}

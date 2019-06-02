using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffSpotlightController : MonoBehaviour
{
    public bool lightIsOn = true;
    public float onOffFrequency = 5f;
    public float startDelay = 1f; //how many seconds before we start turning on and off
    public Sprite offSprite;
    public Sprite onSprite;

    GameObject player;
    Vector2 playerStartingPos;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerStartingPos = GameController.Pos2d(player);
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("lightswitch", startDelay, onOffFrequency);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void lightswitch()
    {
        print("invoking lightswitch");
        // if light is on, turn it off (and vice versa)
        if (lightIsOn == true)
        {
            spriteRenderer.sprite = offSprite;
            lightIsOn = false;
        }
        else
        {
            spriteRenderer.sprite = onSprite;
            lightIsOn = true;
        }
        print("switched lights");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (lightIsOn == true)
        {
            player.transform.position = playerStartingPos;
        }
    }
}

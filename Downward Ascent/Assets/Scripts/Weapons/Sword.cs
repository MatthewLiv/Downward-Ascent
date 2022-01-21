using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private bool attacking;
    private bool down;

    public int downspeed;
    public int upspeed;

    public GameObject tracker;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(-1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("E: " + transform.eulerAngles.x);
        //Debug.Log("Q: " + transform.rotation.eulerAngles.x);

        //transform.Rotate(-20 * Time.deltaTime, 0, 0);

        Debug.Log(tracker.transform.position.y);

        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            attacking = true;
            down = true;
        }

        if (attacking && down)
        {
            Down();
        }

        else if (attacking)
        {
            Up();
        }
    }

    void Down()
    {
        if (tracker.transform.position.y - player.position.y > -20)
        {
            transform.Rotate(-downspeed * Time.deltaTime, 0, 0);
        }

        else
        {
            down = false;
        }
    }

    void Up()
    {
        if (tracker.transform.position.y - player.position.y < 49.47)
        {
            transform.Rotate(upspeed * Time.deltaTime, 0, 0);
        }

        else
        {
            attacking = false;
        }

    }


    
}

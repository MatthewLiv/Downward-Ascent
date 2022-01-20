using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private bool Pressed;
    private bool down;

    // Start is called before the first frame update
    void Start()
    {
        down = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("It gets to here");
        if (Input.GetKeyDown("space"))
        {
            
            Pressed = true;
        }

        if (Pressed)
        {
            
            Swing();
        }
    }

    private void Swing()
    {
        
        if (down && transform.eulerAngles.x < 130)
        {
            transform.Rotate(Time.deltaTime, 0, 0);
        }

        else
        {
            down = false;
        }

        if (!down && transform.eulerAngles.x > 0)
        {
            transform.Rotate(-Time.deltaTime, 0, 0);
        }

        else
        {
            down = true;
            Pressed = false;
        }
    }
}

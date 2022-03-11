using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDcontroller : MonoBehaviour
{
    public GameObject HUD;
    //private int lives = 4;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(HUD, new Vector3(0, 0, 0), HUD.transform.rotation);
    }

    
}

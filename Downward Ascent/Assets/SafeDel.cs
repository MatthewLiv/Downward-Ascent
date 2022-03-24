using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeDel : MonoBehaviour
{

    private float T;
    public GameObject r;

    // Start is called before the first frame update
    void Start()
    {
        T = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - T > 0.3)
        {
            Destroy(r);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCol : MonoBehaviour
{
    private bool yes = true;

    private void OnTriggerEnter(Collider other)
    {
        var cubRenderer = GetComponent<Renderer>();
        if (yes)
        {
            cubRenderer.material.SetColor("_Color", Color.blue);
            yes = !yes;
        }

        else
        {
            cubRenderer.material.SetColor("_Color", Color.green);
            yes = !yes;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collhop : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Destroy(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collhop : MonoBehaviour
{
    private float speed = -2f;

    private void OnTriggerEnter(Collider col)
    {
        speed = speed * -1;
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (Input.GetKeyDown("space"))
        {
            speed = speed * -1;
        }
    }
}

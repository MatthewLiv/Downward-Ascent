using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour


{
    public Vector3 Vec;

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* yaw += speedH * Input.GetAxis("Mouse X");
         pitch -= speedV * Input.GetAxis("Mouse Y");

         transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        */
        
        Vec = transform.localPosition;
        Vec.x = Vec.x + Input.GetAxis("Horizontal") * Time.deltaTime * 20;
        Vec.z = Vec.z + Input.GetAxis("Vertical") * Time.deltaTime * 20;
        transform.localPosition = Vec;



    }
}

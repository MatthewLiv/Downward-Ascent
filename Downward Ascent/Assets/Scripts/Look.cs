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

    public bool isJump;
    private float yspot = -1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int Xax = Input.GetAxis("MouseX");
        if (Xax > 180 || Xax < -180)
        {
            yaw = 0;
        }
        else
        {
            yaw += speedH * Xax;
        }

        int Yax = Input.GetAxis("MouseY");
        if (Yax > 180 || Yax < -180)
        {
            pitch = 0;
        }
        else
        {
            pitch -=peedH * Xax;
        }




        /*
        yaw += speedH * Input.GetAxis("MouseX");
         pitch -= speedV * Input.GetAxis("Mouse Y");

         transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        */

        Vec = transform.localPosition;
        Vec.x = Vec.x + Input.GetAxis("Horizontal") * Time.deltaTime * 20;
        Vec.z = Vec.z + Input.GetAxis("Vertical") * Time.deltaTime * 20;
        transform.localPosition = Vec;


        Rigidbody r = gameObject.GetComponent<Rigidbody>();

        yspot = gameObject.transform.position.y;

        if (Input.GetKey("space") && !isJump)
        {
            isJump = true;
            


            //object.Rigidbody.AddForce(Vector3.up * 5);
            
            r.AddForce(Vector3.up * 150);
            
        }

        else if (isJump && gameObject.transform.position.y == yspot)
        {
            isJump = false;
        }
        

        

       

       // Debug.Log(yspot);
       // Debug.Log(isJump);

    }
}

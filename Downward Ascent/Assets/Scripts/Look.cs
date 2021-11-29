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
        /*  int Xax = (int) Input.GetAxis("Mouse X");
          if (Xax > 180 || Xax < -180)
          {
              yaw = 0;
          }
          else
          {
              yaw += speedH * Xax;
          }

          int Yax = (int) Input.GetAxis("Mouse Y");
          if (Yax > 180 || Yax < -180)
          {
              pitch = 0;
          }
          else
          {
              pitch -= speedH * Yax;
          }

          transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        */

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        if (transform.rotation.x > 0.5 || transform.rotation.x < 0.5)
        {
            yaw = 0;
            Debug.Log("It goes to show");
        }

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        //0.09864876
        //Debug.Log(transform.rotation.x);
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

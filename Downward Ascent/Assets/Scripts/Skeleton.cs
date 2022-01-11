using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{

    private int currentR;

    private void Start()
    {
        currentR = Random.Range(0, 361);

        transform.Rotate(0, currentR, 0);
        
    }

    private void Update()
    {

        transform.Translate(0, 0, Time.deltaTime);

        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);


        
        if (Physics.Raycast(landingRay, out hit, 2))
        {
            //Debug.Log("weel it hit");
            if (hit.collider.tag == "Turner")
            {
                
                transform.Rotate(0, currentR * -1 * Time.deltaTime, 0);
                

            }
        
        }

        
       
        //for y rote value: transform.eulerAngles.y

    }

        
  

   
    


}

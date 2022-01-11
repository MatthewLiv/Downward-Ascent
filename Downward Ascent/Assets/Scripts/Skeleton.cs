using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{

    private int currentR;

    private void Start()
    {
        int R = Random.Range(0, 361);
        transform.Rotate(0, R, 0);
        
    }

    private void Update()
    {
        

        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);


        Debug.DrawRay(transform.position, Vector3.down, Color.blue);


        



        if (Physics.Raycast(landingRay, out hit, 2))
        {
            //Debug.Log("weel it hit");
            if (hit.collider.tag == "Turner")
            {
                
                transform.Rotate(0,90 * Time.deltaTime, 0);
                

            }

            


            
        }
      
        

    }

        
  

   
    


}

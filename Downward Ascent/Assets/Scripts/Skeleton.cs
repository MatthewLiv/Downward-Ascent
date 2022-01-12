using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{

    private float currentR;

    public LayerMask player;

    public GameObject Player;

    private bool playerInSightRange;


    private void Start()
    {
        currentR = Random.Range(0, 361);

        transform.Rotate(0, currentR, 0);

        playerInSightRange = false;
        
    }

    private void Update()
    {
        Debug.Log(playerInSightRange);
        if (!playerInSightRange)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, 5, player);
            
        }
        
        //playerInSightRange = Physics.CheckSphere(transform.position, 10, player);


        if (playerInSightRange)
        {
            ChasePlayer();
        }

        else
        {
            transform.Translate(0, 0, Time.deltaTime);

            RaycastHit hit;
            Ray landingRay = new Ray(transform.position, Vector3.down);



            if (Physics.Raycast(landingRay, out hit, 2))
            {
                //Debug.Log("weel it hit");
                if (hit.collider.tag == "Turner")
                {

                    transform.Rotate(0, currentR * -1.2f * Time.deltaTime, 0);


                }

            }

            else
            {
                currentR = transform.eulerAngles.y;
            }
        }
        
        void ChasePlayer()
        {
            Transform t = Player.transform;
            transform.Translate(t.x * Time.deltaTime, 0, t.z * Time.deltaTime);
        }
        

    }

        
  

   
    


}

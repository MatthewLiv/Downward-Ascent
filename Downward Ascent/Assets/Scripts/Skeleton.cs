using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{/*
    private bool Obstacle;
    

    private void Start()
    {
        int R = Random.Range(0, 361);
        transform.Rotate(0, R, 0);
        
    }

    private void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * 5);

        checkObstacle();
        int i = 0;
        while (i == 0)
        {
                if (Obstacle)
                {
                    transform.Rotate(0, 90, 0);
                i = 1;
                }
        }
        
        

    }


    private void checkObstacle()
    {
        RaycastHit hit;
        Vector3 p = transform.position;
        Ray landingRay = new Ray(new Vector3(p.x, p.y + 0.5f, p.z), Vector3.forward);
        Debug.DrawRay(new Vector3(p.x, p.y + 0.5f, p.z), Vector3.forward);

        if (Physics.Raycast(landingRay, out hit, 2))
        {
            if (hit.collider.tag == "Ground")
            {
                Obstacle = true;
                

            }

        }
    }




    /*

 

    public LayerMask whatIsGround, whatIsPlayer;

   
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("MyPersonController").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        

       

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }

        if (playerInSightRange && playerInAttackRange)
        {
            attackPlayer();
        }
    }

    private void Patroling()
    {
        
    }

   
    

    private void ChasePlayer()
    {
        
    }
    private void AttackPlayer()
    {
        
    }

   
    */


}

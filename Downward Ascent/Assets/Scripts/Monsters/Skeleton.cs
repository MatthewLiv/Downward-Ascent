using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{

    private float currentR;

    public LayerMask player;

    public GameObject P;

    private bool playerInSightRange;
    private bool playerInAttackRange;

    //chasing
    public NavMeshAgent enemy;
    private Transform ayer;
    private Animator mAnimator;

    private bool dead;
    private float deathTime;

    SpriteRenderer rend;

   


    private void Start()
    {
        currentR = Random.Range(0, 361);

        transform.Rotate(0, currentR, 0);

        playerInSightRange = false;

        mAnimator = GetComponent<Animator>();

        ayer = GameObject.Find("SwordPerson").transform;

        rend = GetComponent<SpriteRenderer>();
        
        
    }

    private void Update()
    {
        if (dead)
        {
            if (Time.time - deathTime > 3)
            {
                Color c = rend.material.color;
                c.a = c.a - 0.5f;
                rend.material.color = c;

            }
            return;
        }
        
        if (!playerInSightRange)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, 7, player);
            if (playerInSightRange)
            {
                mAnimator.SetTrigger("Seen");
                enemy.speed = 25;
                enemy.angularSpeed = 1000;
              // mAnimator.Play("Run")
            }
        }

        //playerInSightRange = Physics.CheckSphere(transform.position, 10, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, 1, player);

        if (playerInAttackRange)
        {
            enemy.SetDestination(transform.position);
            mAnimator.Play("Attack");
            
            //enemy.isStopped = true;
        }

        else if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {

        }


        else if (playerInSightRange)
        {
            enemy.speed = 25;
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
            /* Transform t = P.transform;
             Debug.Log(t.position.x + " " + t.position.z);
             transform.Translate(t.position.x * Time.deltaTime, 0, t.position.z * Time.deltaTime);
             */

            enemy.SetDestination(ayer.position);


        }

        

        

    }



    private void OnTriggerEnter(Collider col)
    {
        mAnimator.Play("Death");
        Destroy(enemy);
        dead = true;
        deathTime = Time.time;
    }




}

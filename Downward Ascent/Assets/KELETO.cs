using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KELETO : MonoBehaviour
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

    public bool roting;
    public int rotamount;
    public int rot;
    public bool negrot;

    public int rotChance;

    //SpriteRenderer rend;




    private void Start()
    {
        currentR = Random.Range(0, 361);

        transform.Rotate(0, currentR, 0);

        playerInSightRange = false;

        mAnimator = GetComponent<Animator>();
        //mAnimator.Play("Walk");

        //ayer = GameObject.Find("SwordPerson(Clone)").transform;
        //ayer = GameObject.Find("SwordPerson").transform;
        ayer = GameObject.Find("WorkingSword(Clone)").transform;
        //ayer = GameObject.Find("WorkingSword").transform;



        /*if (ayer == null)
        {
            ayer = GameObject.Find("SwordPerson").transform;
        }*/

        //rend = GetComponent<SpriteRenderer>();



    }

    private void Update()
    {

        //Debug.Log(mAnimator.enabled);

        

        //Debug.Log(ayer);
        if (dead)
        {
            if (Time.time - deathTime > 3)
            {
                //Color c = rend.material.color;
                //c.a = c.a - 0.5f;
                //rend.material.color = c;
                Destroy(gameObject);
            }
            return;
        }

        if (!playerInSightRange)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, 11, player);
            if (playerInSightRange)
            {
                mAnimator.SetTrigger("Seen");
                enemy.acceleration = 20;
                //enemy.velocity = new Vector3(1, 0, 0);
                //enemy.angularSpeed = 100000;
                enemy.angularSpeed = 10000;
                // mAnimator.Play("Run")
            }
        }

        //playerInSightRange = Physics.CheckSphere(transform.position, 10, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, 1, player);

        if (playerInAttackRange)
        {
            enemy.SetDestination(transform.position);
            mAnimator.Play("attac");
            //GameObject.SkelSwordCol.EndAttack();

            //enemy.isStopped = true;
        }

        else if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("attac"))
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



            if (Random.Range(0, rotChance) == 5)
            {
                roting = true;
                rotamount = Random.Range(45, 160);
                rot = 0;
                if (Random.Range(0, 2) == 0)
                {
                    negrot = true;
                }
                //transform.Rotate(0, r, 0);
            }

            if (roting && rot < rotamount)
            {
                if (negrot)
                {
                    transform.Rotate(0, -5, 0);
                }
                else
                {
                    transform.Rotate(0, 5, 0);
                }
                
                rot+= 5;
            }

            else if (roting)
            {
                roting = false;
                negrot = false;
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
        if (!dead)
        {
            if (col.gameObject.name == "Good Katana")
            {
                mAnimator.Play("Death");
                Destroy(enemy);
                dead = true;
                deathTime = Time.time;
            }
        }


    }




}


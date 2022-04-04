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

    
    //SpriteRenderer rend;

   


    private void Start()
    {
        currentR = Random.Range(0, 361);

        transform.Rotate(0, currentR, 0);

        playerInSightRange = false;

        mAnimator = GetComponent<Animator>();
        //mAnimator.Play("Walk");

        //ayer = GameObject.Find("SwordPerson(Clone)").transform;
        ayer = GameObject.Find("SwordPerson").transform;

        

        /*if (ayer == null)
        {
            ayer = GameObject.Find("SwordPerson").transform;
        }*/

        //rend = GetComponent<SpriteRenderer>();



    }

    private void Update()
    {

        Debug.Log(mAnimator.enabled);

        if (Input.GetKeyDown("l"))
        {
            //Instantiate(EndScreen, new Vector3(0, 0, 0), EndScreen.transform.rotation);
            //SceneManager.LoadScene("The Game");
            mAnimator.Play("Damage");
        }

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
            playerInSightRange = Physics.CheckSphere(transform.position, 7, player);
            if (playerInSightRange)
            {
                mAnimator.SetTrigger("Seen");
                enemy.acceleration = 20;
                //enemy.velocity = new Vector3(1, 0, 0);
                enemy.angularSpeed = 100000;
              // mAnimator.Play("Run")
            }
        }

        //playerInSightRange = Physics.CheckSphere(transform.position, 10, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, 1, player);

        if (playerInAttackRange)
        {
            enemy.SetDestination(transform.position);
            mAnimator.Play("Attack");
            //GameObject.SkelSwordCol.EndAttack();
            
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

            /*RaycastHit hit;
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
            }*/
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
                mAnimator.Play("Death 0");
                Destroy(enemy);
                dead = true;
                deathTime = Time.time;
            }
        }
        
       
    }

   


}

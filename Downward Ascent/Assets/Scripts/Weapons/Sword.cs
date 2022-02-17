using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator mAnimator;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(-1, 0, 0);
        mAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        int Trig = -1;
        Debug.Log(Input.GetKeyDown("left shift"));
        if (Input.GetMouseButtonDown(0))
        {
            mAnimator.SetTrigger("Attack");
        }

        bool moving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        

        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        
        {
            if (Input.GetKeyDown("left shift"))
            {
                mAnimator.SetTrigger("walking");
                Trig = 1;
               
            }
            else
            {
                mAnimator.SetTrigger("Running");
                Trig = 2;
            }
            
        }

        
        if (Trig == 2)
        {
            //mAnimator.ResetTrigger("Running");
        }
        
        if (Trig == 1)
        {
            //mAnimator.ResetTrigger("walking");
        }
        
        
        /*else
        {
            mAnimator.ResetTrigger("Running");
            mAnimator.ResetTrigger("walking");
        }*/
        





        /*else
        {
            mAnimator.SetBool("Walking", false);
        }*/




       /*/ if (Input.GetMouseButtonDown(0))
        {
            mAnimator.SetBool("Attack", true);
        }
        else
        {
            mAnimator.SetBool("Attack", false);

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                mAnimator.SetBool("Walking", true);
            }
            else
            {
                mAnimator.SetBool("Walking", false);
            }
        }
        
        //Player.isWalking;
        if (Player.isWalking)
        {
            mAnimator.SetBool("Walking", true);
        }
        else
        {
            mAnimator.SetBool("Walking", false);
        }*/

        

    }

    


    
}

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

        if (Input.GetMouseButtonDown(0))
        {
            mAnimator.SetTrigger("Attack");
        }



        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        
        {
            mAnimator.SetTrigger("Running");
        }

        else
        {
            mAnimator.ResetTrigger("Running");
        }
        Debug.Log(Input.GetAxis("Horizontal"));
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

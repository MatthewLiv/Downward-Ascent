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
            mAnimator.SetBool("Attack", true);
        }
        else
        {
            mAnimator.SetBool("Attack", false);
        }
       
        if (Player.isWalking)
        {
            mAnimator.SetBool("Walking", true);
        }
        else
        {
            mAnimator.SetBool("Walking", false);
        }



    }

    


    
}

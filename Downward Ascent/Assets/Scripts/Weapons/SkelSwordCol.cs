using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkelSwordCol : MonoBehaviour
{

    public BoxCollider col;


    // Start is called before the first frame update
    void Start()
    {
        
        col.enabled = false;
    }

    private void Update()
    {
        //Debug.Log(col.enabled);
    }
    

    public void EnterAttack()
    {
        col.enabled = true;
    }

    public void EndAttack()
    {
        col.enabled = false;
    }

}

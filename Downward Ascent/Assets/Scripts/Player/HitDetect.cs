using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetect : MonoBehaviour
{

    public GameObject Redscreen;

    private void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.name == "Skeleton")
        {
            Instantiate(Redscreen, new Vector3(0, 0, 0), Redscreen.transform.rotation);
        }
        
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillFall : MonoBehaviour
{

    



    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "WorkingSword(Clone)")
        {
            SceneManager.LoadScene("Death Screen");
        }

    }

    


}

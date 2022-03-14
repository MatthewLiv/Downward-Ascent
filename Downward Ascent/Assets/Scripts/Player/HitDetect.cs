using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetect : MonoBehaviour
{

    public GameObject Redscreen;
    


    private void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.name == "SkelSword")
        {
            Instantiate(Redscreen, new Vector3(0, 0, 0), Redscreen.transform.rotation);
            //LifeChanger.score -= 1;
            //LifeChanger.scoretext.text = LifeChanger.score.ToString();
            LifeChanger.LoseLife();
        }
        
    }
    

}

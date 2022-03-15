using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetect : MonoBehaviour
{

    public GameObject Redscreen;
    private bool hit = false;
    private float t;
    private GameObject r;


    private void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.name == "SkelSword")
        {
             r = Instantiate(Redscreen, new Vector3(0, 0, 0), Redscreen.transform.rotation);
            //LifeChanger.score -= 1;
            //LifeChanger.scoretext.text = LifeChanger.score.ToString();
            LifeChanger.LoseLife();
            hit = true;
            t = Time.time;
            
        }
        
    }

    void Update()
    {
        if (hit)
        {
            if (Time.time - t > 0.3)
            {
                hit = false;
                Destroy(r);
                if (LifeChanger.score == 0)
                {

                }
            }
        }
    }
    

}

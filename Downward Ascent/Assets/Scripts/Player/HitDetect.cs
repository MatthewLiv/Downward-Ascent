using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HitDetect : MonoBehaviour
{

    public  GameObject Redscreen;
    private bool hit = false;
    private float t;
    private GameObject r;

    //This code works
    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Works");
        if (col.gameObject.name == "Object01")
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
                if (LifeChanger.score <= 0)
                {
                    SceneManager.LoadScene("Death Screen");
                }
            }
        }
    }
    


    




}

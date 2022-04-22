using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerThis : MonoBehaviour
{

    public GameObject Explosion;
    private static Transform Player;
    private float EXtime;
    private bool Exing;

    public GameObject Redscreen;
    private bool hit = false;
    private float t;
    private GameObject r;



    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "WorkingSword(Clone)")
        {
            //Debug.Log(new Vector3(Player.position.x, Player.position.y + 0.6f, Player.position.z));
            Instantiate(Explosion, new Vector3(Player.position.x, Player.position.y + 0.2f, Player.position.z), Explosion.transform.rotation);

            r = Instantiate(Redscreen, new Vector3(0, 0, 0), Redscreen.transform.rotation);
            LifeChanger.LoseLife();
            hit = true;
            t = Time.time;
        }
        
    }

    public static void SetPlayer(Transform player)
    {
        Player = player;
    }

    void Update()
    {
        Debug.Log(new Vector3(Player.position.x, Player.position.y + 0.6f, Player.position.z));
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

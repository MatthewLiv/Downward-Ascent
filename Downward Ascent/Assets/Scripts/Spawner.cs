using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Starters;
    public GameObject yoyoyo;
    private int[] path1 = new int[9];
    
    // Start is called before the first frame update
    void Start()
    {
        //Random r = new Random();
        //int num = r.Next(0, 1);
        // Instantiate(landFabs[0], new Vector3(0, 0, 0), landFabs[0].transform.rotation);

        int num = Random.Range(0, 5);
        Vector3 position = Vector3.zero;
        GameObject g = Instantiate(Starters[num], position, Starters[num].transform.rotation);
        //placeR(g);

     /*   int random = Random.Range(0, 2);
        if (random == 1)
        {
            Instantiate(yoyoyo, new Vector3(16, 0, 0), yoyoyo.transform.rotation);
        }
        else
        {
            Instantiate(yoyoyo, new Vector3(-16, 0, 0), yoyoyo.transform.rotation);
        }

        Debug.LogError(path1[0]);*/
      
      


    }

    private void placeR(GameObject g)
    {
        int num = Random.Range(0, 4);
        if (num == 0)
        {
            return;
        }
        /*else if (num == 1)
        {
            g.transform.Rotate(Vector3.up, 90);
            g.transform.Translate(new Vector3(16, 0, 0));
        }
        else if (num == 2)
        {
            g.transform.Rotate(Vector3.up, 180);
            g.transform.Translate(new Vector3(16, 0, 16));
        }*/
        else
        {
            g.transform.Rotate(Vector3.up, 270);
            // g.transform.Translate(new Vector3(0, 0, 16));
            g.transform.SetPositionAndRotation(new Vector3(15, 0, 0), new Quaternion(0, 270, 0, 1));  
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

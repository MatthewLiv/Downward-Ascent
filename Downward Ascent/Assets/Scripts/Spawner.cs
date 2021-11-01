using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Starters;
    public GameObject yoyoyo;
    
    // Start is called before the first frame update
    void Start()
    {
        //Random r = new Random();
        //int num = r.Next(0, 1);
        // Instantiate(landFabs[0], new Vector3(0, 0, 0), landFabs[0].transform.rotation);

        int num = Random.Range(0, 1);
        Vector3 position = Vector3.zero;
        GameObject g = Instantiate(Starters[num], position, Starters[num].transform.rotation);
        
        Debug.LogError(g.transform.position);

        Debug.LogError(yoyoyo.transform.position + "ookeeboogey");
        
       // Vector3 position2 = new Vector3(0, 0, 0);
       //GameObject THEg = Instantiate(yoyoyo, position2, yoyoyo.transform.rotation);
       // THEg.transform.position = position2;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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

        int num = Random.Range(0, 1);
        Vector3 position = Vector3.zero;
        GameObject g = Instantiate(Starters[num], position, Starters[num].transform.rotation);

        int random = Random.Range(0, 2);
        if (random == 1)
        {
            Instantiate(yoyoyo, new Vector3(16, 0, 0), yoyoyo.transform.rotation);
        }
        else
        {
            Instantiate(yoyoyo, new Vector3(-16, 0, 0), yoyoyo.transform.rotation);
        }

        Debug.LogError(path1[0]);
      



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

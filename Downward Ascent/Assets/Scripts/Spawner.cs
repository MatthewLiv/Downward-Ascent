using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Starters;
    // Start is called before the first frame update
    void Start()
    {
        //Random r = new Random();
        //int num = r.Next(0, 1);
        // Instantiate(landFabs[0], new Vector3(0, 0, 0), landFabs[0].transform.rotation);

        int num = Random.Range(0, 2);
        Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
        GameObject g = Instantiate(Starters[num], position, Starters[num].transform.rotation);
        g.transform.localPosition = position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

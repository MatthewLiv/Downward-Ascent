using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] landFabs;
    // Start is called before the first frame update
    void Start()
    {
        //Random r = new Random();
        //int num = r.Next(0, 1);
        // Instantiate(landFabs[0], new Vector3(0, 0, 0), landFabs[0].transform.rotation);

        int num = Random.Range(0, 1);
        Instantiate(landFabs[num], new Vector3(0, 0, 0), landFabs[num].transform.rotation);
        Instantiate(landFabs[num], new Vector3((float) 15.5, 0, 0), landFabs[num].transform.rotation);
        Instantiate(landFabs[num], new Vector3((float)-15.5, 0, 0), landFabs[num].transform.rotation);
        Instantiate(landFabs[num], new Vector3(0, 0, (float)15.5), landFabs[num].transform.rotation);
        Instantiate(landFabs[num], new Vector3(0, 0, (float)-15.5), landFabs[num].transform.rotation);
        Instantiate(landFabs[num], new Vector3((float)15.5, 0, (float)15.5), landFabs[num].transform.rotation);
        Instantiate(landFabs[num], new Vector3((float)15.5, 0, (float)-15.5), landFabs[num].transform.rotation);
        Instantiate(landFabs[num], new Vector3((float)-15.5, 0, (float)-15.5), landFabs[num].transform.rotation);
        Instantiate(landFabs[num], new Vector3((float)-15.5, 0, (float)15.5), landFabs[num].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

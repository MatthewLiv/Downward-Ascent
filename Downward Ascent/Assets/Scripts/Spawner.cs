using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Starters;
    public GameObject[] stays;

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
        placeR(g, 0, 0);

        int yog = Random.Range(0, 2);

          GameObject O = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
          placeR(O, 16, 0);
        yog = Random.Range(0, 2);
        GameObject O1 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O1, 16, 16);
        yog = Random.Range(0, 2);
        GameObject O2 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O2, 16, -16);
        yog = Random.Range(0, 2);
        GameObject O3 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O3, 0, 16);
        yog = Random.Range(0, 2);
        GameObject O4 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O4, 0, -16);
        yog = Random.Range(0, 2);
        GameObject O5 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O5, -16, 16);
        yog = Random.Range(0, 2);
        GameObject O6 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O6, -16, 0);
        yog = Random.Range(0, 2);
        GameObject O7 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O7, -16, -16);

        
          
          
          
          
          








    }

    private void placeR(GameObject g, int X, int Z)
    {
        int num = Random.Range(0, 4);
        if (num == 0)
        {
            g.transform.Translate(new Vector3(X, 0, Z));
            
        }
        else if (num == 1)
        {
            g.transform.Rotate(Vector3.up, 90);
            g.transform.Translate(new Vector3(-15 - Z, 0, 0 + X));
        }
        else if (num == 2)
        {
            g.transform.Rotate(Vector3.up, 180);
            g.transform.Translate(new Vector3(-15 - X, 0, -15 - Z));
        }
        else
        {
            g.transform.Rotate(Vector3.up, 270);
            g.transform.Translate(new Vector3(0 + Z, 0, -15 - X));
       // g.transform.Position(new Vector3(15, 0, 0));
           // g.transform.SetPositionAndRotation(new Vector3(15, 0, 0), new Quaternion(0, 180, 0, 1));  
       }    
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

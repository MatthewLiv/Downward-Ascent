using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Starters;
    
    public GameObject[] downs;
    public GameObject[] pass;
    public GameObject[] stops;
    private bool[] path = new bool[9];
    private bool down = false;
    private Vector3[] trans = new Vector3[9];

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        populatetrans();








        //Starting area
        int n = Random.Range(0, 5);

        GameObject g = Instantiate(Starters[n], new Vector3(0, 0, 0), Starters[n].transform.rotation);
        placeR(g, 0, 0);

        if (n > 1)
        {
            down = true;
            path[0] = true;
        }
        
        //Where to go next
        int spot = GetnextSpotFromStart();
       if (down)
        {
            fill(spot);
        }
       // for (int i = 0; i < 7; i++)
        //{
           // if (down)
            //{
                
            //choose where to go now

          
            


    }
      //  }

        




        
        
      
        
        
        
        /*  int num = Random.Range(0, 5);
        Vector3 position = Vector3.zero;
        GameObject g = Instantiate(Starters[num], position, Starters[num].transform.rotation);
        placeR(g, 0, 0);

        int yog = Random.Range(0, 3);

          GameObject O = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
          placeR(O, 16, 0);
        yog = Random.Range(0, 3);
        GameObject O1 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O1, 16, 16);
        yog = Random.Range(0, 3);
        GameObject O2 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O2, 16, -16);
        yog = Random.Range(0, 3);
        GameObject O3 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O3, 0, 16);
        yog = Random.Range(0, 3);
        GameObject O4 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O4, 0, -16);
        yog = Random.Range(0, 3);
        GameObject O5 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O5, -16, 16);
        yog = Random.Range(0, 3);
        GameObject O6 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O6, -16, 0);
        yog = Random.Range(0, 3);
        GameObject O7 = Instantiate(stays[yog], new Vector3(0, 0, 0), Starters[num].transform.rotation);
        placeR(O7, -16, -16);

        
          */
          
          
          
          








    

    private void placeR(GameObject g, float X, float Z)
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
        }    
     }


    private int GetnextSpotFromStart()
    {
        int n = Random.Range(0, 4);
        int spot;
        if (n == 0)
        {
            spot = 2;
        }
        else if (n == 1)
        {
            spot = 4;
        }
        else if (n == 2)
        {
            spot = 6;
        }
        else
        {
            spot = 8;
        }
        return 8; 
    }


    /*
     1  16, 16
    2   16, 0
    3   16, -16
    4   0, -16
    5,  -16, -16
    6, -16, 0
    7,  -16, 16
    8   0 16
    */

    private void populatetrans()
    {
        trans[0] = new Vector3(0, 0, 0);
        trans[1] = new Vector3(16, 0, 16);
        trans[2] = new Vector3(16, 0, 0);
        trans[3] = new Vector3(16, 0, -16);
        trans[4] = new Vector3(0, 0, -16);
        trans[5] = new Vector3(-16, 0, -16);
        trans[6] = new Vector3(-16, 0, 0);
        trans[7] = new Vector3(-16, 0, 16);
        trans[8] = new Vector3(0, 0, 16);
    }

    private void fill(int spot)
    {
        path[spot] = true;
        int type = Random.Range(0, 3);
        int n;
        GameObject g;
        if (type == 0)
        {
            //how many downs there are is n
            n = Random.Range(0, 1);
            g = Instantiate(downs[n], new Vector3(0, 0, 0), downs[n].transform.rotation);
            placeR(g, trans[spot].x, trans[spot].z);
        }
        else if (type == 1)
        {
            //how many downs there are is n
            n = Random.Range(0, 1);
            g = Instantiate(pass[n], new Vector3(0, 0, 0), pass[n].transform.rotation);
            placeR(g, trans[spot].x, trans[spot].z);
        }
        else
        {
            //how many downs there are is n
            n = Random.Range(0, 1);
            g = Instantiate(stops[n], new Vector3(0, 0, 0), stops[n].transform.rotation);
            placeR(g, trans[spot].x, trans[spot].z);
        }

        int leftnum = spot - 1;
        if (leftnum == 0)
        {
            leftnum = 8;
        }
        if (!path[leftnum])
        {
            fill(leftnum);
        }

        int rightnum = spot + 1;
        if (rightnum == 9)
        {
            rightnum = 1;
        }
        if (!path[rightnum])
        {
            fill(rightnum);
        }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}

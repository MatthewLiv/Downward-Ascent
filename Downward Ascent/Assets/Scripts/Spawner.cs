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
    private int direction;
    private int level;
    private int fillcount;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        populatetrans();
        level = 0;
        int nextspot = SpawnTop();
        resetThem();
        level = -16;
        fill();
        

          
            


    }
      
    private void resetThem()
    {
        path = new bool[9];
        down = false;

    }
        


    private int getDirection()
    {
        int n = Random.Range(0, 2);
        if (n == 0)
        {
            return 1;
        }
        return -1;
    }

        
        
      
        
        
        
       
          
          
          
          




    private int SpawnTop()
    {
        direction = 1;
        int y = Random.Range(0, 2);
        if (y == 0)
        {
            direction = -1;
        }









        //Starting area
        int n = Random.Range(0, 5);

        GameObject g = Instantiate(Starters[n], new Vector3(0, 0, 0), Starters[n].transform.rotation);
        placeR(g, 0, 0);
        int spot = GetnextSpotFromStart();
        path[0] = true;
        if (n > 1)
        {
            down = true;
            
            //fill(spot);
            fill();
        }

        
        else
        {
            int i = 0;
            while (!down && i < 7)
            {
                int r = Random.Range(0, 8);
                i++;
                if (r == 0)
                {
                    down = true;
                    g = Instantiate(downs[0], new Vector3(0, 0, 0), downs[0].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    //fill(spot + 1);
                    //fill(spot - 1);
                    fill();
                }
                else
                {
                    g = Instantiate(pass[0], new Vector3(0, 0, 0), pass[0].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    spot = UpdateSpot(spot);
                }
            }

            if (!down)
            {
                g = Instantiate(downs[0], new Vector3(0, 0, 0), downs[0].transform.rotation);
                placeR(g, trans[spot].x, trans[spot].z);
                path[spot] = true;
               
            }
        }
        return spot;
    }

    private void SpawnMid(int spot)
    {
        int i = 0;
        
        int d = getDirection();
        while (!down && i < 8)
        {
                path[spot] = true;
                int r = Random.Range(0, 9);
                if (spot == 0)
                {
                //change direction since its back in the middle
                d = getDirection();
                    //go down then make down true so the rest fills. 
                    if (r == 0)
                    {
                        GameObject g = Instantiate(downs[0], new Vector3(0, 0, 0), downs[0].transform.rotation);
                        placeR(g, 0, 0);
                        down = true;
                    }
                    else
                    {
                        GameObject g = Instantiate(pass[0], new Vector3(0, 0, 0), pass[0].transform.rotation);
                        placeR(g, 0, 0);
                    }
                }
            i++;
        }
        
            
    }

    
   


    

    private void placeR(GameObject g, float X, float Z)
    {
        int num = Random.Range(0, 4);
        if (num == 0)
        {
            g.transform.Translate(new Vector3(X, level, Z));
            
        }
        else if (num == 1)
        {
            g.transform.Rotate(Vector3.up, 90);
            g.transform.Translate(new Vector3(-15 - Z, level, 0 + X));
        }
        else if (num == 2)
        {
            g.transform.Rotate(Vector3.up, 180);
            g.transform.Translate(new Vector3(-15 - X, level, -15 - Z));
        }
        else
        {
            g.transform.Rotate(Vector3.up, 270);
            g.transform.Translate(new Vector3(0 + Z, level, -15 - X));
        }    
     }

    private int UpdateSpot(int spot)
    {
        spot += direction;
        if (spot == 9)
        {
            return 1;
        }
        if (spot == 0)
        {
            return 8;
        }
        return spot;
    }


    private int GetnextSpotFromStart()
    {
        bool go = false;
        for (int i = 2; i <= 8; i += 2)
        {
            if (!path[i])
            {
                go = true;
            }

        }

        if (go)
        {
            while (true)
            {
                int n = Random.Range(1, 5) * 2;
                if (!path[n])
                {
                    return n;
                }
            }
        }
        return -1;



       /* int n = Random.Range(0, 4);
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
        return 8;*/ 
    }

    public int GetNextSpotFromSide()
    {
        return 0;
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

    /*private void fill(int spot)
    {

        if (spot < 1 || spot > 8)
        {
            return;
        }
        





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
}*/

    private void fill()
    {
        for (int i = 0; i < 9; i++)
        {
            if (!path[i])
            {
                path[i] = true;
                GameObject g = GetanySpace();
                placeR(g, trans[i].x, trans[i].z);

            }
        }
    }

    private GameObject GetanySpace()
    {
        int type = Random.Range(0, 3);
        int n;
        GameObject g;
        if (type == 0)
        {
            //how many downs there are is n
            n = Random.Range(0, 1);
            g = Instantiate(downs[n], new Vector3(0, 0, 0), downs[n].transform.rotation);
            return g;
        }
        else if (type == 1)
        {
            //how many downs there are is n
            n = Random.Range(0, 1);
            g = Instantiate(pass[n], new Vector3(0, 0, 0), pass[n].transform.rotation);
            return g;
        }
        else
        {
            //how many downs there are is n
            n = Random.Range(0, 1);
            g = Instantiate(stops[n], new Vector3(0, 0, 0), stops[n].transform.rotation);
            return g;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

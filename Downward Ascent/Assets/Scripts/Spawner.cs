using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityEditor.AI;
//using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] Starters;
    
    public GameObject[] downs;
    public GameObject[] pass;
    public GameObject[] stops;
    public GameObject[] ends;
    public GameObject Person;
    public GameObject EndScreen;
    private bool[] path = new bool[9];
    private bool down = false;
    private Vector3[] trans = new Vector3[9];
    private int direction;
    private int level;
    private int fillcount;
    private bool keepGoing;
    private bool done = false;
    private bool hit;
    //public GameObject HUD;
    //public int Lives;

    //public NavMeshSurface navSurface;

    public GameObject Skeleton;
    //private GameObject skel;

    public GameObject song1;
    public GameObject song2;




    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        populatetrans();
        level = 0;
        int nextspot = SpawnTop();
        ChangeDirection();
        resetThem();
        level = -16;
        nextspot = SpawnMid(nextspot, 0);
        ChangeDirection();
        resetThem();
        level = -32;
        nextspot = SpawnMid(nextspot, 0);
        ChangeDirection();
        resetThem();
        level = -48;
        SpawnBott(nextspot, 0);



        NavMeshBuilder.BuildNavMesh();
        //navSurface.BuildNavMesh();

        spawnSkels();






        //create player

        Person = Instantiate(Person, new Vector3(7.5f, 5f, 7.5f), Person.transform.rotation);
        TriggerThis.SetPlayer(Person.transform);


        


        keepGoing = true;
        //Instantiate(HUD, new Vector3(0, 0, 0), HUD.transform.rotation);

        //Instantiate(Skeleton, new Vector3(10, 5, 20), Skeleton.transform.rotation);

        if (Random.Range(0, 2) == 0)
        {
            song1.SetActive(true);
        }

        else
        {
            song2.SetActive(true);
        }

    }
      
    private void resetThem()
    {
        path = new bool[9];
        down = false;

    }
        


    private void ChangeDirection()
    {
        int n = Random.Range(0, 2);
        if (n == 0)
        {
            direction = 1;
        }
        direction = -1;
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
            fill(false);
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
                    int DR = Random.Range(0, downs.Length);
                    g = Instantiate(downs[DR], new Vector3(0, 0, 0), downs[DR].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    //fill(spot + 1);
                    //fill(spot - 1);
                    fill(false);
                }
                else
                {
                    int AR = Random.Range(0, pass.Length);
                    g = Instantiate(pass[AR], new Vector3(0, 0, 0), pass[AR].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    spot = UpdateSpot(spot);
                }
            }

            if (!down)
            {
                int DR = Random.Range(0, downs.Length);
                g = Instantiate(downs[DR], new Vector3(0, 0, 0), downs[DR].transform.rotation);
                placeR(g, trans[spot].x, trans[spot].z);
                path[spot] = true;
               
            }
        }
        return spot;
    }

    

    private int SpawnMid(int spot, int i)
    {
        //if weve gone through everything else
        if (i == 8)
        {
            int DR = Random.Range(0, downs.Length);
            GameObject g = Instantiate(downs[DR], new Vector3(0, 0, 0), downs[DR].transform.rotation);
            placeR(g, trans[spot].x, trans[spot].z);
            path[spot] = true;
            return spot;
        }
        // if this spot is randomly chosen to go down
        int r = Random.Range(0, 9);
        if (r == 0)
        {
            int DR = Random.Range(0, downs.Length);
            GameObject g = Instantiate(downs[DR], new Vector3(0, 0, 0), downs[DR].transform.rotation);
            placeR(g, trans[spot].x, trans[spot].z);
            path[spot] = true;
            fill(false);
            return spot;
        }

        else
        {
           
            
            // figure out where to go next
            //if we are in the middle
            if (spot == 0)
            {
                int nextspot = GetnextSpotFromStart();
                //if there is nowhere to go go down
                if (nextspot == -1)
                {
                    int DR = Random.Range(0, downs.Length);
                    GameObject g = Instantiate(downs[DR], new Vector3(0, 0, 0), downs[DR].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    fill(false);
                    return spot;
                }
                else
                {
                    int AR = Random.Range(0, pass.Length);
                    GameObject g = Instantiate(pass[AR], new Vector3(0, 0, 0), pass[AR].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    ChangeDirection();
                    return SpawnMid(nextspot, i++);
                }
            }
            //if we or in the middle side
            //else if (spot % 2 == 0)
            else
            {
                int newspot;
                if (spot % 2 == 0)
                {
                    newspot = UpdateSpotMid(spot);
                }
                else
                {
                    newspot = UpdateSpot(spot);
                }
                
                
                //if something is already there then go down
                if (path[newspot])
                {
                    int DR = Random.Range(0, downs.Length);
                    GameObject g = Instantiate(downs[DR], new Vector3(0, 0, 0), downs[DR].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    fill(false);
                    return spot;
                }
                // pass and keep going yall
                else
                {
                    int AR = Random.Range(0, pass.Length);
                    GameObject g = Instantiate(pass[AR], new Vector3(0, 0, 0), pass[AR].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    //Debug.Log(newspot + "   " + spot);
                    return SpawnMid(newspot, i++);
                }
                

            }
            


        }
       


    }



    private int SpawnBott(int spot, int i)
    {
        int EndNum = Random.Range(0, 5);
        //if weve gone through everything else
        if (i == 8)
        {
            GameObject g = Instantiate(ends[EndNum], new Vector3(0, 0, 0), ends[EndNum].transform.rotation);
            placeR(g, trans[spot].x, trans[spot].z);
            path[spot] = true;
            return spot;
        }
        // if this spot is randomly chosen to go down
        int r = Random.Range(0, 9);
        if (r == 0)
        {
            GameObject g = Instantiate(ends[EndNum], new Vector3(0, 0, 0), ends[EndNum].transform.rotation);
            placeR(g, trans[spot].x, trans[spot].z);
            path[spot] = true;
            fill(true);
            return spot;
        }

        else
        {


            // figure out where to go next
            //if we are in the middle
            if (spot == 0)
            {
                int nextspot = GetnextSpotFromStart();
                //if there is nowhere to go go down
                if (nextspot == -1)
                {
                    GameObject g = Instantiate(ends[EndNum], new Vector3(0, 0, 0), ends[EndNum].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    fill(true);
                    return spot;
                }
                else
                {
                    int AR = Random.Range(0, pass.Length);
                    GameObject g = Instantiate(pass[AR], new Vector3(0, 0, 0), pass[AR].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    ChangeDirection();
                    return SpawnBott(nextspot, i++);
                }
            }
            //if we or in the middle side
            //else if (spot % 2 == 0)
            else
            {
                int newspot;
                if (spot % 2 == 0)
                {
                    newspot = UpdateSpotMid(spot);
                }
                else
                {
                    newspot = UpdateSpot(spot);
                }


                //if something is already there then go down
                if (path[newspot])
                {
                    GameObject g = Instantiate(ends[EndNum], new Vector3(0, 0, 0), ends[EndNum].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    fill(true);
                    return spot;
                }
                // pass and keep going yall
                else
                {
                    int AR = Random.Range(0, pass.Length);
                    GameObject g = Instantiate(pass[AR], new Vector3(0, 0, 0), pass[AR].transform.rotation);
                    placeR(g, trans[spot].x, trans[spot].z);
                    path[spot] = true;
                    //Debug.Log(newspot + "   " + spot);
                    return SpawnBott(newspot, i++);
                }


            }



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

    private int UpdateSpotMid(int spot)
    {
        if (Random.Range(0, 9) == 0)
        {
            return 0;
        }
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

   

    private void fill(bool b)
    {
        for (int i = 0; i < 9; i++)
        {
            if (!path[i])
            {
                path[i] = true;
                GameObject g = GetanySpace(b);
                placeR(g, trans[i].x, trans[i].z);

            }
        }
    }

    private GameObject GetanySpace(bool b)
    {
        int type = Random.Range(0, 5);
        int n;
        GameObject g;
        if (type == 0 && !b)
        {
            //how many downs there are is n
            n = Random.Range(0, downs.Length);
            g = Instantiate(downs[n], new Vector3(0, 0, 0), downs[n].transform.rotation);
            return g;
        }
        else if (type == 1)
        {
            //how many downs there are is n
            n = Random.Range(0, pass.Length);
            g = Instantiate(pass[n], new Vector3(0, 0, 0), pass[n].transform.rotation);
            return g;
        }
        else
        {
            //how many downs there are is n
            n = Random.Range(0, stops.Length);
            g = Instantiate(stops[n], new Vector3(0, 0, 0), stops[n].transform.rotation);
            return g;
       }
    }




    private void spawnSkels()
    {
        int k = Random.Range(20, 48);

        for (int i = 0; i < k; i++)
        {
            int x = Random.Range(-16, 32);
            int y = Random.Range(-54, 16);
            int z = Random.Range(-16, 32);
            Instantiate(Skeleton, new Vector3(x, y, z), Skeleton.transform.rotation);
        }
    }






    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray landingRay = new Ray(Person.transform.position, Vector3.down);


        

        if (Input.GetKeyDown("k"))
        {
            //Instantiate(EndScreen, new Vector3(0, 0, 0), EndScreen.transform.rotation);
            SceneManager.LoadScene("The Game");
        }




        if (Physics.Raycast(landingRay, out hit, 2))
        {
            if (hit.collider.tag == "End" && !done)
            {
                if (LifeChanger.GetLevel() == 5)
                {
                    SceneManager.LoadScene("End Scene");
                }
                //SceneManager.UnloadSceneAsync(0);
                if (keepGoing)
                {
                    Instantiate(EndScreen, new Vector3(0, 0, 0), EndScreen.transform.rotation);
                    done = true;
                    keepGoing = false;
                    PlayerPrefs.SetInt("Time", PlayerPrefs.GetInt("Time") + TimeKeeper.t);
                    Time.timeScale = 0;
                }
                
                //SceneManager.LoadScene(1);

            }

        }

        if (done)
        {
            if (Input.GetKeyDown("space"))
            {
                PlayerPrefs.SetInt("Lives", LifeChanger.GetLives());
                //PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

                


                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }

        }




    }

   
}

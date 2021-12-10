using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerRayTest : MonoBehaviour
{

    public GameObject Player;
    private bool i;

    // Start is called before the first frame update
    void Start()
    {
        
        
        //Debug.Log("This is called more than once?");  
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(Player.transform.position, Vector3.down);

        if (Physics.Raycast(landingRay, out hit, 2))
        {
            if (hit.collider.tag == "End")
            {
                //SceneManager.UnloadSceneAsync(0);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //SceneManager.LoadScene(1);
                
            }
            
        }
        //Debug.Log(SceneManager.sceneCount);
    }
}

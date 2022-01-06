using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionTestAnimator : MonoBehaviour
{

    public GameObject Skel;
    // Start is called before the first frame update
    void Start()
    {
        Skel = Instantiate(Skel, new Vector3(2.5f, 0.5f, 8f), Skel.transform.rotation);
        Skel.transform.localScale = new Vector3(15, 15, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            
            Skel.GetComponent<Animator>().Play("Skeleton@Run");
            Debug.Log("Well it got here");
        }
    }
}

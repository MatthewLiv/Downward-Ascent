using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav : MonoBehaviour
{
    public NavMeshSurface n;

    // Start is called before the first frame update
    void Start()
    {
        n.BuildNavMesh();
    }

    // Update is called once per frame
   
}

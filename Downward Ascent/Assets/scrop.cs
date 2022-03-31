using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class scrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NavMeshBuilder.BuildNavMesh();
    }

    
}

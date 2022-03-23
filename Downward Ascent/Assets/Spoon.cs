using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spoon : MonoBehaviour
{
    public GameObject A;
    public NavMeshSurface s;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(A, new Vector3(0, 0, 0), A.transform.rotation);
        s.BuildNavMesh();
    }
}

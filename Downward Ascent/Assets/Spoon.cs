using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour
{

    public NavMeshSurface A;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(A, new Vector3(0, 0, 0), A.transform.rotation);
        A.BuildNavMesh();
    }
}

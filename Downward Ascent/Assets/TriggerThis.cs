using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerThis : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("worls");
    }
}

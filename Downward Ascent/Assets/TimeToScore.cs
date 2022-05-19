using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeToScore : MonoBehaviour
{

    public TextMeshProUGUI timetext;
    
    // Start is called before the first frame update
    void Start()
    {
        timetext.text = "Time: " + PlayerPrefs.GetInt("Time").ToString();
    }

    
}

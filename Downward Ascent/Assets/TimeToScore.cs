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

        int t = PlayerPrefs.GetInt("Time");


        int mins = t / 60;

        int secs = t % 60;

         if (mins > 9 && secs > 9)
         {
             timetext.SetText("Time: " + mins.ToString() + ":" + secs.ToString());
         }

         else if (mins > 9)
         {
             timetext.SetText("Time: " + mins.ToString() + ":0" + secs.ToString());
         }

         else if (secs > 9)
         {
             timetext.SetText("Time: 0" + mins.ToString() + ":" + secs.ToString()); 
         }

         else
         {
             timetext.SetText("Time: 0" + mins.ToString() + ":0" + secs.ToString());
         }

        

        
    }

    
}

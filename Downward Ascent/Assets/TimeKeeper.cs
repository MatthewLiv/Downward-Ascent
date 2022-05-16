
using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{

    public Text playerTime;

    // Update is called once per frame
    void Update()
    {
        int t = (int) Time.time;
        int mins = t / 60;
        //playerTime.text = mins.ToString() + ":" + (t % 60).ToString();
        if (t % 60 > 9 && mins > 9)
        {
            playerTime.text = mins.ToString() + ":" + (t % 60).ToString();
        }

        else if (t % 60 > 9)
        {
            playerTime.text = "0" + mins.ToString() + ":" + (t % 60).ToString();
        }

        else if (mins > 9)
        {
            playerTime.text = mins.ToString() + ":0" + (t % 60).ToString();
        }

        else
        {
            playerTime.text = "0" + mins.ToString() + ":0" + (t % 60).ToString();
        }

    }
}

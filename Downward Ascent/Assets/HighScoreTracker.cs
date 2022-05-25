using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreTracker : MonoBehaviour
{

    public TextMeshProUGUI HighScoretext;
    

    // Start is called before the first frame update
    void Start()
    {
        /*int past = PlayerPrefs.GetInt("HighScore");
        int current = ScoreCalculator.Score;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            

           // Debug.Log(ScoreCalculator.Score);
            if (current > past)
            {
                PlayerPrefs.SetInt("HighScore", current);
                HighScoretext.SetText("High-Score: " + current.ToString());
            }

            else
            {
                HighScoretext.SetText("High-Score: " + past.ToString());
            }
        }

        else
        {
            PlayerPrefs.SetInt("HighScore", current);
            HighScoretext.SetText("High-Score: " + current.ToString());
        }*/

        
        
    }

    void Update()
    {
        if (Input.GetKeyDown("u"))
        {
            PlayerPrefs.SetInt("HighScore", 800);
        }
    }

   

    
}

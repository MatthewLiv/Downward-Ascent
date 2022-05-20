using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreTracker : MonoBehaviour
{

    public TextMeshProUGUI HighScoretext;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            int past = PlayerPrefs.GetInt("HighScore");
            int current = ScoreCalculator.Score;

            Debug.Log(ScoreCalculator.Score);
            if (current > past)
            {
                PlayerPrefs.SetInt("HighScore", current);
                
            }
        }

        else
        {
            PlayerPrefs.SetInt("HighScore", ScoreCalculator.Score);
        }


        HighScoretext.SetText("High-Score: " + PlayerPrefs.GetInt("HighScore").ToString());
    }

    
}

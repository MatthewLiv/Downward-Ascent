
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{

    public TextMeshProUGUI Scoretext;
    public static int Score;

    public TextMeshProUGUI HighScoretext;

    // Start is called before the first frame update
    void Start()
    {
        int liv = LifeChanger.score;
        int livcalc = (int) Mathf.Pow(10, liv) * 10;

        int tim = PlayerPrefs.GetInt("Time");

        Score = livcalc - (10 * tim);

        Scoretext.SetText("Score: " + Score.ToString());
        //HighScoreTracker.SetHigh(Score);

        
        
        if (PlayerPrefs.HasKey("HighScore"))
        {
            int current = PlayerPrefs.GetInt("HighScore");

            // Debug.Log(ScoreCalculator.Score);
            if (Score > current)
            {
                PlayerPrefs.SetInt("HighScore", Score);
                HighScoretext.SetText("High-Score: " + Score.ToString());
            }

            else
            {
                HighScoretext.SetText("High-Score: " + current.ToString());
            }
        }

        else
        {
            PlayerPrefs.SetInt("HighScore", Score);
            HighScoretext.SetText("High-Score: " + Score.ToString());
        }


    }

    
}


using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{

    public TextMeshProUGUI Scoretext;
    public static int Score;

    // Start is called before the first frame update
    void Start()
    {
        int liv = LifeChanger.score;
        int livcalc = (int) Mathf.Pow(10, liv) * 10;

        int tim = PlayerPrefs.GetInt("Time");

        Score = livcalc - (10 * tim);

        Scoretext.SetText("Score: " + Score.ToString());


    }

    
}

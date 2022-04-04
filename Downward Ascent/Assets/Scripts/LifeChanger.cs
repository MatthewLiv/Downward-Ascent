using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeChanger : MonoBehaviour
{
    public Text scoretext;
    public static int score;

    public Text leveltext;
    private int area;
    private int level;

    public Text Moneytext;
    private int money;

    void Start()
    {
        score = 4;
        //scoretext.text = "4";
        area = 1;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
           // score -= 1;
            
       // }
        scoretext.text = score.ToString();

        if (Input.GetKeyDown("a"))
        {
            level += 1;
            if (level == 5)
            {
                area += 1;
                level = 1;
            }
            leveltext.text = area.ToString() + "-" + level.ToString();
        }

        if (Input.GetKeyDown("s"))
        {
            money += 500;
            Moneytext.text = "$" + money;
        }
    }

    public static void LoseLife()
    {
        if (score == 0)
        {

        }
        else
        {
            score -= 1;
        }
        
       // scoretext.text = score.ToString();
    }

    public static int GetLives()
    {
        return score;
    }

    public static void SetLives(int l)
    {
        score = l;
    }
}

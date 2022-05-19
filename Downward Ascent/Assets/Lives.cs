
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lives : MonoBehaviour
{

    public TextMeshProUGUI lives;
    
    // Start is called before the first frame update
    void Start()
    {
        lives.text = "Lives: " + LifeChanger.score.ToString();
    }

    
}

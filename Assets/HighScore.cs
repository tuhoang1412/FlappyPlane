using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    public int highScore;
    static private Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
        highScore = PlayerPrefs.HasKey("highscore") ? PlayerPrefs.GetInt("highscore") : 0;
        uiText.text = highScore.ToString("#,0");
    }
    [ContextMenu("Reset Score")]
    public void ResetScore()
    {
        PlayerPrefs.SetInt("highscore", 0);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

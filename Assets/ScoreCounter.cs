using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour
{
    public int score = 0;

    static private Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    // [ContextMenu("Add Score")]
    public void AddScore(int point)
    {
        // Debug.Log("Add score");
        score += point;
        uiText.text = score.ToString("#,0");
    }
}

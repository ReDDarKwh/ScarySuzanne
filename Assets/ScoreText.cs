using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreText : MonoBehaviour
{

    public TextMeshProUGUI text;
    

    // Start is called before the first frame update
    void Start()
    {
        var score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        text.text = score.score <= 1? $"{score.score} Suzanne Killed": $"{score.score} Suzannes Killed";
        score.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

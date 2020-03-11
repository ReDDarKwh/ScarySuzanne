using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreText : MonoBehaviour
{

    public TextMeshProUGUI text;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        this.score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().score;
        text.text = score <= 1? $"{score} Suzanne Killed": $"{score} Suzannes Killed";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/**
 * 
 * Create By: Jeremiah Underwood (following book instructions)
 * Date Created: 2/6/2022
 * 
 * last Edited: N/A
 * Last Edited By: N/A
 * 
 * 
 * Description: Controls HighScore
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;

    void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore")) //If there is a highscore, get it
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", score);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score" + score;

        if (score > PlayerPrefs.GetInt("HighScore")) //update PlayerPrefs
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}

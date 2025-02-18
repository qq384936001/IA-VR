﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Part2_PlayerFindingScript : MonoBehaviour
{
    public static TMP_Text playerRunningTimeText;
    public static float sec_f_playerRun = 600f;//300f
    public static int sec_playerRun = 0;
    //public Text ui;
    public static bool part2_playerFindingtimerIsRunning = false;
    int score = 0;
    bool calculated_the_marks = false;
    //public Text scoreText;
    //public TextMesh scoreText2;
    //public TextMeshPro scoreText3;
    public TMP_Text scoreText;

    //float StartTime = 61f;

    void Start()
    {
        playerRunningTimeText = GetComponent<TMP_Text>();//find the text
        sec_playerRun = PlayerPrefs.GetInt("ScoreData", sec_playerRun);//store value in memory
    }

    void Update()
    {


        DisplayTime(sec_f_playerRun);
        if (part2_playerFindingtimerIsRunning)
        {

            if (sec_f_playerRun > 0)
            {
                sec_f_playerRun -= Time.deltaTime; //when there has time
            }
            else
            {
                Debug.Log("Time has run out!");
                //sec_f_playerRun = 0;
                part2_playerFindingtimerIsRunning = false;
            }
        }
        else
        {
            //calculate the mark
            if (!calculated_the_marks)
            {
                score = (int)(sec_f_playerRun * 10);
                Score.score += score;
                //scoreText.text = "Score: " + score.ToString();
                //scoreText4.text = "Score: " + score.ToString();
                Debug.Log(score);
                calculated_the_marks = true;
                gameObject.SetActive(false);
            }

        }






    }


    void DisplayTime(float timeToDisplay)
    {
        //timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        playerRunningTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }



    public void TimegameOver()
    {
        Debug.Log("You failed");
        //ui.GetComponent<State>().setState("Well done he was saved");
    }


    public static void timeKeeper(int value)
    {
        sec_playerRun += value;
        PlayerPrefs.SetInt("ScoreData", sec_playerRun);
        PlayerPrefs.Save();
        playerRunningTimeText.text = sec_playerRun.ToString();
    }

    public static void resetTime()
    {
        sec_f_playerRun = 120f;
    }


    //menu
    //
    //the time is counting

    //the heart rate is 0 

    //
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               

public class GameController : MonoBehaviour
{
   

    public Text timeCounter, countdownText;

    public bool gamePlaying { get; private set; }

    public int countdownTime;

    private float startTime, elapsedTime;

    TimeSpan timePlaying;

    private void Start()
    {

        timeCounter.text = "Time: 00:00.00";

        gamePlaying = false;

        StartCoroutine(CountdownToStart());
    }

    private void BeginGame()
    {
        gamePlaying = true;

        startTime = Time.time;
    }


    private void Update()
    {
        if (gamePlaying)
        {
            elapsedTime = Time.time - startTime;

            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");

            timeCounter.text = timePlayingStr;
        }
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        BeginGame();

        countdownText.text = "GO!";

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
    }

}


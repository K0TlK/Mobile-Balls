using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : Singleton<GameTimer>
{
    [SerializeField] private float gameTime = 90f;
    private bool timerIsActive = false;
    private float timeLeft;

    public float MaxTime => gameTime;
    public float TimeLeft => timeLeft;

    public void Awake()
    {
        timeLeft = gameTime;
    }

    public void StartTimer()
    {
        timerIsActive = true;
        timeLeft = gameTime;
    }

    private void EndTimer()
    {
        timerIsActive = false;
        timeLeft = gameTime;
        GameManager.Instance.EndGame();
    }

    private void Update()
    {
        if (timerIsActive)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                EndTimer();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Button btPlay;
    [SerializeField] RecordsVisual recrods;
    private bool gameActive = false;
    public bool isGameActive => gameActive;

    private void Start()
    {
        btPlay.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        btPlay.gameObject.SetActive(false);
        BalloonSpawner.Instance.StartGame();
        GameTimer.Instance.StartTimer();
        PointerCounter.Instance.StartGame();
        gameActive = true;
    }

    public void EndGame()
    {
        gameActive = false;
        btPlay.gameObject.SetActive(true);
        recrods.gameObject.SetActive(true);
        BalloonSpawner.Instance.StopGame();
    }
}

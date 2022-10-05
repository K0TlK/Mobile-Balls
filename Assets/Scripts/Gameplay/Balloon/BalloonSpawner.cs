using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BalloonSpawner : Singleton<BalloonSpawner>
{
    [SerializeField] private int balloonsOnScene = 20;
    [SerializeField] private float spawnDelay = 0.5f;
    [SerializeField] private float posZ = -15f;
    [SerializeField] private BalloonController balloonPrefab;
    private bool spawnerActive = false;

    private Queue<BalloonController> ballonsQueue = new Queue<BalloonController>();
    private List<BalloonController> ballonsList = new List<BalloonController>();

    private void Start()
    {
        for (int i = 0; i < balloonsOnScene; i++)
        {
            ballonsList.Add(Instantiate(balloonPrefab));
            ballonsList[i].name = $"ballon-{i+1}";
            ballonsQueue.Enqueue(ballonsList[i]);
        }
    }

    public void StartGame()
    {
        spawnerActive = true;
        ClearGameZone();
        StartCoroutine(GameLoop());
    }

    private void ClearGameZone()
    {
        ballonsQueue.Clear();
        for (int i = 0; i < ballonsList.Count; i++)
        {
            ballonsList[i].Burst();
            ballonsQueue.Enqueue(ballonsList[i]);
        }
    }

    public void StopGame()
    {
        spawnerActive = false;
    }

    IEnumerator GameLoop()
    {
        while (spawnerActive)
        {
            var success = ballonsQueue.TryDequeue(out var newBalloon);
            if (success)
            {
                newBalloon.transform.position = new Vector3(Random.Range(-VisibleZoneManager.Instance.Width, VisibleZoneManager.Instance.Width), posZ);
                newBalloon.SetNewColor();
                newBalloon.SetRandomScale();
                newBalloon.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(Random.Range(spawnDelay/4, spawnDelay));
        }
    }

    public void ReturnBallon(BalloonController balloon)
    {
        ballonsQueue.Enqueue(balloon);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    [SerializeField]
    int points;

    public Action<int> onScoreChange;

    public Action onGameOver;

    public Action onGameSetRunningState;

    public static GManager Instance;

    [SerializeField]
    BackgroundScroller backgroundScroller;

    [SerializeField]
    BackgroundScroller baseScroller;

    [SerializeField]
    PipeSpawner pipeSpawner;

    [SerializeField]
    List<Player> _players;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        onGameSetRunningState?.Invoke();
        StartCoroutine(StartGameDelayed());
    }

    IEnumerator StartGameDelayed()
    {
        yield return new WaitForSeconds(3.99f);
        backgroundScroller.StartScrolling();
        baseScroller.StartScrolling();
        pipeSpawner.StartSpawning();
        _players.ForEach(player => player.RunGame());
    }

    public void AddPoints(int value)
    {
        points += value;
        onScoreChange?.Invoke(points);
    }

    public void GameOver()
    {
        backgroundScroller.StopScrolling();
        baseScroller.StopScrolling();
        pipeSpawner.StopSpawning();
        DataHolder.Instance.SetScore(points);
        onGameOver?.Invoke();
    }

    public void LoadGameplay()
    {
        SceneManager.LoadScene((int)SceneOrder.MainScene);
    }
}

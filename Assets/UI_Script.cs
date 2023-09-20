using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Script : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreTXT;

    [SerializeField]
    GameObject scoreContainer;

    [SerializeField]
    TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        GManager.Instance.onScoreChange += ChangeScoreUI;
        GManager.Instance.onGameSetRunningState += ShowUI;
        GManager.Instance.onGameOver += HideUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScoreUI(int value)
    {
        scoreTXT.text = value.ToString();
    }

    void ShowUI()
    {
        StartCoroutine(StartTimer());
    }

    void HideUI ()
    {
        scoreContainer.SetActive(false);
    }

    IEnumerator StartTimer()
    {
        timerText.gameObject.SetActive(true);
        float timerTime = 3.99f;
        while(timerTime > 0f)
        {
            timerText.text = ((int)timerTime).ToString();
            timerTime -= Time.deltaTime;
            yield return null;
        }
        timerText.gameObject.SetActive(false);
        scoreContainer.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI bestScoreText;

    [SerializeField]
    TextMeshProUGUI lastScoreText;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    List<GameObject> medals;
    // Start is called before the first frame update
    void Start()
    {
        GManager.Instance.onGameOver += ShowGameOverPanel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowGameOverPanel()
    {
        bestScoreText.text = DataHolder.Instance.HighScore.ToString();
        lastScoreText.text = DataHolder.Instance.LastScore.ToString();

        int highScore = DataHolder.Instance.HighScore;
        if (highScore >= 10 && highScore < 20) //bronze
            medals[0].SetActive(true);
        else if (highScore < 30) // silver
            medals[1].SetActive(true);
        else if (highScore < 40) //gold
            medals[2].SetActive(true);
        else // platinium
            medals[3].SetActive(true);

        gameOverPanel.SetActive(true);
    }
}

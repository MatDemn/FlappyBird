using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    bool isLoading = false;

    [SerializeField]
    Transform _mainMenuObj;

    [SerializeField]
    List<GameObject> medals;

    [SerializeField]
    TextMeshProUGUI lastScoreText;

    [SerializeField]
    TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        int highScore = DataHolder.Instance.HighScore;
        if (highScore >= 10 && highScore < 20) //bronze
            medals[0].SetActive(true);
        else if(highScore < 30) // silver
            medals[1].SetActive(true);
        else if(highScore < 40) //gold
            medals[2].SetActive(true);
        else // platinium
            medals[3].SetActive(true);

        lastScoreText.text = DataHolder.Instance.LastScore.ToString();
        bestScoreText.text = DataHolder.Instance.HighScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClick()
    {
        _mainMenuObj.gameObject.SetActive(false);
        GManager.Instance.StartGame();   
    }

    public void OnScoreButtonClick()
    {
        _mainMenuObj.gameObject.SetActive(false);
    }
}

public enum SceneOrder
{
    MainScene = 0
}

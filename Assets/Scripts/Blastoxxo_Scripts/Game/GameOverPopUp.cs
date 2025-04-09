using UnityEngine;
using UnityEngine.UI;

public class GameOverPopUp : MonoBehaviour
{
    public GameObject gameOverPopUp;
    public GameObject PausePopUp;
    
    void Start()
    {
        gameOverPopUp.SetActive(false);

    }
    private void OnEnable()
    {
        GameEvents.GameOver += OnGameOver;
        GameEvents.HidePopUp += OnHidePopUp;
    }

    private void OnDisable()
    {
          GameEvents.GameOver -= OnGameOver;
          GameEvents.HidePopUp -= OnHidePopUp;
    }

    public void OnGameOver(bool isGameOver)
    {
        if(isGameOver)
        {
            gameOverPopUp.SetActive(true);
            PausePopUp.SetActive(true);
        }
        else
        {
            gameOverPopUp.SetActive(true);
        }
    }

    public void OnHidePopUp()
    {
        if (PausePopUp == true)
        {
            PausePopUp.SetActive(false);
            gameOverPopUp.SetActive(false);
        }
        else
        {
            gameOverPopUp.SetActive(false);
        }
    }

}

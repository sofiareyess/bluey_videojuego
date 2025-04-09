using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public int pointsToWin = 500; // Ahora es 500 en lugar de 17

    void Awake()
    {
        PlayerPrefs.SetInt("PointsToWin", pointsToWin); 
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void checkGameOver(int _currentScore)
    {
        PlayerPrefs.SetInt("score", _currentScore);

        if (_currentScore >= pointsToWin)
        {
            SceneManager.LoadScene("EndGame_HormiOXXO"); // Cambia a la escena de victoria
        }
    }

}

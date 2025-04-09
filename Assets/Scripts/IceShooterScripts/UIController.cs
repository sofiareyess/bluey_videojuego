using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text points;
    string pointsText = "PuntOXXOs: ";
    int currentScore = 0;
    public Sprite SpendLives;
    public Image[] livesImage;
    int lives = 3;
    void Start()
    {
        lives = PlayerPrefs.GetInt("lives", 5);
        ActiveScore();
    }
    // Display inicial
    public void ActiveScore() {
        points.text = pointsText + "--";
    }
    // Suma puntos que trae desde IceBehaviour
    public void AddPoints(int _points) {
        currentScore += _points;
        PrintScore();
    }
    // Actualiza los puntos en el panel
    public void PrintScore() {
        points.text = pointsText + currentScore;
    }

    public void UpdateLives()
    {
        lives = GameControl.Instance.GetCurrentLives();
        if (lives > 0)
        {
            livesImage[lives].sprite = SpendLives;
        }
        GameControl.Instance.checkGameOver();
    }

}

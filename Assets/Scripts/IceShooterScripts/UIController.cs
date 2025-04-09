using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Text points;
    string pointsText = "PuntOXXOs: ";
    int currentScore = 0;
    public Sprite SpendLives;
    public Image[] livesImage;
    int lives = 3;

    public float tiempoRestante = 30f; 
    public Text tiempoTexto; 

    void Start()
    {
        lives = PlayerPrefs.GetInt("lives", 5);
        ActiveScore();
        ActualizarTiempoUI();  
    }

    void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarTiempoUI();
        }
        else
        {
            TiempoFinalizado();  
        }
    }

    // Mostrar el tiempo en UI
    void ActualizarTiempoUI()
    {
        if (tiempoTexto != null)
        {
            tiempoTexto.text = "Tiempo: " + Mathf.Ceil(tiempoRestante) + "s";
        }
    }

    void TiempoFinalizado()
    {
        tiempoTexto.text = "¡Tiempo agotado!";
        PlayerPrefs.SetInt("Puntos", GetCurrentScore());
        PlayerPrefs.Save();
        SceneManager.LoadScene("ShooterEndScene");  // Cambiar de escena
    }

    // Display inicial
    public void ActiveScore()
    {
        points.text = pointsText + "--";
    }

    // Suma puntos
    public void AddPoints(int _points)
    {
        currentScore += _points;
        PrintScore();
    }

    // Actualiza los puntos en el panel
    public void PrintScore()
    {
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

    public int GetCurrentScore()
{
    return currentScore;
}
}


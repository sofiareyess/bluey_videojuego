using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseBehaviour : MonoBehaviour
{

    public GameObject pausePanel;

    // Se asegura que el panel de pausa no esté activo
    void Start()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false); 
        }
    }


    // Pausa la partida
    public void PauseGame() {
        // Congela el juego
        Time.timeScale = 0;
        if (pausePanel != null) {
            // Muestra el panel de pausa
            pausePanel.SetActive(true);
        }
    }

    // Resume la partida
    public void ResumeGame() {
        // Descongela el juego
        Time.timeScale = 1;
        if (pausePanel != null) {
            // Quita el panel de pausa
            pausePanel.SetActive(false);
        }
    }

    // Reinicia la partida
    public void RestartGame() {
        // Descongela el juego
        Time.timeScale = 1;
        // Vuelve a cargar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     // Termina la partida
    public void QuitGame() {
         // Descongela el juego
        Time.timeScale = 1;
        // Cambia a la escena final del juego 
        if (SceneManager.GetActiveScene().name == "IceShooterScene") {
            SceneManager.LoadScene("ShooterEndScene");
        } else if (SceneManager.GetActiveScene().name == "FlappyScene") {
            SceneManager.LoadScene("FlappyEndScene");
        } else if (SceneManager.GetActiveScene().name == "BlastScene") {
            SceneManager.LoadScene("BlastEndScene");
        } 

    }

}



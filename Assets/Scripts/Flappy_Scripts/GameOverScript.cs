using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text resultadoText;
    public AudioClip winSound;  // Variable para el sonido cuando choca


    //esta función lleva a la escena principal
    public void RestartGame()
    {

        PlayerPrefs.SetInt("Puntos", 0); // Reinicia los puntos a cero
         PlayerPrefs.SetInt("EstrellasChocadas", 0); // Reinicia el contador de estrellas
         PlayerPrefs.SetInt("ReiniciarJuego", 1); // Marca que debe reiniciarse el juego desde la pregunta 1
         
        PlayerPrefs.Save(); // Asegura que los cambios se guarden
    
        SceneManager.LoadScene("FlappyHormigOXXO", LoadSceneMode.Single); 
    }

    // te lleva al menú
    public void ExitGame()
    {
        PlayerPrefs.SetInt("Puntos", 0);
        PlayerPrefs.SetInt("EstrellasChocadas", 0);
        PlayerPrefs.SetInt("ReiniciarJuego", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("OxxoScene");
    }

      public void getWin() // Cuando golpea algún objeto, suena un sonido
    {
        if (winSound != null)
        {
            AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position, 0.5f);
        }
    }

        void Start()
    {
        int puntosActuales = PlayerPrefs.GetInt("Puntos", 0);
        int puntosParaGanar = PlayerPrefs.GetInt("PointsToWin", 500);

        if (puntosActuales >= puntosParaGanar)
        {
            getWin();
            resultadoText.text = "¡Has completado las preguntas necesarias, WUJU!";
        }
        else
        {
            resultadoText.text = "Te faltaron algunas preguntas escenciales, inténtalo de nuevo.";
        }

    }
    }

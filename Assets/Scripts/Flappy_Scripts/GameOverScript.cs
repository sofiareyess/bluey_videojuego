using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    //esta función lleva a la escena principal
    public void RestartGame()
    {
        SceneManager.LoadScene("FlappyHormigOXXO"); 
    }

    // te lleva al menú
    public void ExitGame()
    {
        SceneManager.LoadScene("OxxoScene");
    }
}

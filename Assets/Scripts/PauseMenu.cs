using UnityEngine;
using UnityEngine.SceneManagement;

//este script es para ponerle pausa al juego
public class PauseMenu : MonoBehaviour
{
    //esta punción lleva a la escena de stop
    public void OpenStopScene()
    {
        SceneManager.LoadScene("Stop_FlappyH");
    }
}

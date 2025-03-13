using UnityEngine;
using UnityEngine.SceneManagement;

//este script se usa en la escena principal
public class StopButton : MonoBehaviour
{
    //esta función lleva a la escena de stop
    public void OpenStopScene()
    {
        SceneManager.LoadScene("Stop_FlappyH");
    }
}

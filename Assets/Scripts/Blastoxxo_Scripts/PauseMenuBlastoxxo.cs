using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBlastoxxo : MonoBehaviour
{
    public void ContinueGame(){
        SceneManager.LoadScene("GameSceneBlastoxxo");
        Debug.Log("Vuelve a minijuego");
    }
    public void RestartGame(){
        SceneManager.LoadScene("GameSceneBlastoxxo");
        Debug.Log("Reinicia minijuego");
    }
    
    public void ExitMinigame(){
        SceneManager.LoadScene("OxxoScene");
        Debug.Log("Sale de minijuego y va a Tycoon");
    }
    void Start(){    
    }
    void Update(){
    }
}

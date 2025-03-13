using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBlastoxxo : MonoBehaviour
{
    public void ExitMinigame(){
        //SceneManager.LoadScene("Tycoon");
        Debug.Log("Sale de minijuego y va a Tycoon");
    }
    public void PlayAgain(){
        SceneManager.LoadScene("GameSceneBlastoxxo");
        Debug.Log("Reinicia minijuego");
    }
    void Start() {
        
    }
    void Update(){
        
    }
}

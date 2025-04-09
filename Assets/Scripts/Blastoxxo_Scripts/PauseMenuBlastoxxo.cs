using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBlastoxxo : MonoBehaviour
{
    public void ContinueGame(){
        GameEvents.HidePopUp();
    }
    public void RestartGame(){
        SceneManager.LoadScene("GameSceneBlastoxxo");
    }
    
    public void ExitMinigame(){
        SceneManager.LoadScene("OxxoScene");
    }
}

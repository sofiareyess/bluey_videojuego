using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBlastoxxo : MonoBehaviour
{
    public UpdateResponse updateResponse;

    public void ContinueGame(){
        GameEvents.HidePopUp();
    }
    public void RestartGame(){
        //post
        SceneManager.LoadScene("GameSceneBlastoxxo");
    }
    
    public void ExitMinigame(){
        //post
        SceneManager.LoadScene("OxxoScene");
    }
}

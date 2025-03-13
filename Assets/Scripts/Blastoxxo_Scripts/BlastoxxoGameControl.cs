using UnityEngine;
using UnityEngine.SceneManagement;

public class BlastoxxoGameControl : MonoBehaviour
{
    public void GoToPauseMenu(){
        SceneManager.LoadScene("PauseSceneBlastoxxo");
    }
    void Start(){ 
    }
    void Update(){
    }
}

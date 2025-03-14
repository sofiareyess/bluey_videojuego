using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneRedirect : MonoBehaviour
{

    public GameObject Panel;


    void Start()
    {

    }

    // Abre la escena de juego de IceShooter
    public void IceShooter() {
        SceneManager.LoadScene("IceShooterScene");
    }

    // Abre la escena de juego de BlastOxxo
    public void Blast() {
        SceneManager.LoadScene("GameSceneBlastoxxo");
    }

    // Abre la escena de juego de Flappy
    public void Flappy() {
        SceneManager.LoadScene("FlappyHormigOXXO");
    }

    // Abre la escena del Oxxo
    public void Menu() {
        SceneManager.LoadScene("OxxoScene");
    }

    //abre la tienda
    public void Store()
    {
        SceneManager.LoadScene("ShopScene");
    }

}



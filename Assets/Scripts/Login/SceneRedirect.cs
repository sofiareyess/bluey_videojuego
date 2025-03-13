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

    // AUN NO SE COMO SE LLAMAN LAS ESCENAS DE JUEGO DE ESTOS MINIJUEGOS
    // CHECAR EL NOMBRE

    // Abre la escena de juego de BlastOxxo
    public void Blast() {
        SceneManager.LoadScene("BlastScene");
    }

    // Abre la escena de juego de Flappy
    public void Flappy() {
        SceneManager.LoadScene("FlappyScene");
    }

    // Abre la escena del Oxxo
    public void Menu() {
        SceneManager.LoadScene("OxxoScene");
    }

}



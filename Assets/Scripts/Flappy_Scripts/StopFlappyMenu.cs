using UnityEngine;
using UnityEngine.SceneManagement;


//este escript se usa en la escena de menu
public class StopFlappyMenu : MonoBehaviour
{
    public void ContinueGame()
    {
        // CAMBIAR FUNCION PARA QUE EL JUEGO CONTINUE
        // PUSE SOLO LA FUNCION , TIPO DE MANERA DEMOSTRATIVA, PERO REINICIA LA ESCENA NO LA CONTINUA
        //en unity en onClick, el boton si esta asignado a esta funciónS
        SceneManager.LoadScene("FlappyHormigOXXO");  
    }

    //esta funcion es para reiniciar
    //si sirve
    public void RestartGame()
    {
        SceneManager.LoadScene("FlappyHormigOXXO");
    }
}



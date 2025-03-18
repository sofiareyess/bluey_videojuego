using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LogoManager : MonoBehaviour
{
    //lleva a la scena del menu
    public string nextScene = "OxxoScene"; 
    void Start()
    {
        //inicia esta funcion always
        StartCoroutine(EsperarCargarScene());
    }

    void Update()
    {
        //detecta si se ha hecho un click en la pantalla
        if (Input.GetMouseButtonDown(0)) {
            CargarScene();
        }
    }

    //funcion para esperar 10s y cambiar de escena
    IEnumerator EsperarCargarScene()
    {
        yield return new WaitForSeconds(10f);
        CargarScene();
    }

    void CargarScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}

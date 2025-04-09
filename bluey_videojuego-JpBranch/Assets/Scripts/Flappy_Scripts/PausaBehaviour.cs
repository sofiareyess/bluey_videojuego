using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaBehaviour : MonoBehaviour
{
    public GameObject panelPreguntas; // Panel de preguntas

    void Start()
    {
       
    }

    public void PauseGame()
    {
        if (panelPreguntas != null)
        {
            panelPreguntas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        if (panelPreguntas != null)
        {
            panelPreguntas.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

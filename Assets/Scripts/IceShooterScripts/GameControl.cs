using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    static public GameControl Instance;
    public UIController UIController;

    // Se crea una instancia para la partida actual
    public void Awake()
    {
        StopAllCoroutines();
        PlayerPrefs.SetInt("lives", 5);
        Instance = this;
        Instance.SetReferences();
        DontDestroyOnLoad(this.gameObject);
    }

    void SetReferences()
    {
        if (UIController == null) {
            UIController = FindFirstObjectByType<UIController>();
        }
    }

    // Regresa las vidas actuales
    public int GetCurrentLives()
    {
        return PlayerPrefs.GetInt("lives", 5);
    }

    // Quita una vida
    public void SpendLives()
    {
        // Si aún se tienen vidas se resta 1
        if (GetCurrentLives() > 0) {
            int newLives = GetCurrentLives() - 1;
            PlayerPrefs.SetInt("lives", newLives);
            UIController.UpdateLives();
        } else {
            ActivateEndScene(); // Si no se cambia de escena
        }
    }

    // Revisa si se perdió
    public void checkGameOver()
    {
        PlayerPrefs.GetInt("lives", 5);
        if (PlayerPrefs.GetInt("lives", 5) == 0)
        {
            ActivateEndScene();
        }
    }

    // Cambia a la escena final
    public void ActivateEndScene() 
    {
        SceneManager.LoadScene("ShooterEndScene");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text PuntoOxxos;
    public Text PuntoOxxos2;
    private int currentScores_;

    public void Start()
    {
          currentScores_ = 0;
          UpdateScoreText();
    }

    private void OnEnable()
    {
        GameEvents.AddScores += AddScores;
        GameEvents.ResetScore += ResetScores;
    }

    private void OnDisable()
    {
        GameEvents.AddScores -= AddScores;
        GameEvents.ResetScore -= ResetScores;
    }

    private void AddScores(int scores)
    {
        currentScores_ += scores;
        PlayerPrefs.SetInt("Puntos", currentScores_);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        PuntoOxxos.text = "PuntOxxos: "+currentScores_.ToString();
        PuntoOxxos2.text = "PuntOxxos: "+currentScores_.ToString();
    }

    private void ResetScores()
    {
        currentScores_ = 0;
        PlayerPrefs.SetInt("Puntos", currentScores_);
        UpdateScoreText();
    }
}

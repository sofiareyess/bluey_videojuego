using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text PuntoOxxos;
    private int currentScores_;

    public void Start()
    {
          currentScores_ = 0;
          UpdateScoreText();
    }

    private void OnEnable()
    {
        GameEvents.AddScores += AddScores;
    }

    private void OnDisable()
    {
        GameEvents.AddScores -= AddScores;
    }

    private void AddScores(int scores)
    {
        currentScores_ += scores;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        PuntoOxxos.text = "PuntOxxos: "+currentScores_.ToString();
    }
}

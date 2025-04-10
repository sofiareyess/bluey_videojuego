using UnityEngine;

public class Panel : MonoBehaviour
{
   public GameObject PanelPreguntas;


     public void OnEnable()
    {
        GameEvents.ShowPanel += ShowPanel;
        GameEvents.HidePanel += HidePanel;
    }

    public void OnDisable()
    {
        GameEvents.ShowPanel -= ShowPanel;
        GameEvents.HidePanel -= HidePanel;
    }

    private void ShowPanel()
    {
        PanelPreguntas.SetActive(true);
    }

    private void HidePanel()
    {
        PanelPreguntas.SetActive(false);
    }
}

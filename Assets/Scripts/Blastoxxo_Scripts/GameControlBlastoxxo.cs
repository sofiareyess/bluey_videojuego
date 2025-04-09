using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class GameControlBlastoxxo : MonoBehaviour
{
    public void GoToPauseMenu()
    {
        GameEvents.GameOver(false);
        GameEvents.AddScores(0);
    }
}

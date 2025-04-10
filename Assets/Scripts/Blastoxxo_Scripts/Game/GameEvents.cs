using System;
using System.Net.NetworkInformation;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action ShowPanel;
    public static Action  HidePanel;
    public static Action<bool> GameOver;
    public static Action HidePopUp;
    public static Action<int> AddScores;
    public static Action ResetScore;
    public static Action CheckIfShapeCanBePlaced;
    public static Action MoveShapeToStartPosition;
    public static Action RequestNewShapes;
    public static Action SetShapeInactive;
}

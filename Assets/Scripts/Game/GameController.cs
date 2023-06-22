using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject gameContainer;

    [SerializeField]
    private GameObject sendScoreCanvas;

    [SerializeField]
    private int puntaje;

    private static GameController instance;

    public int Score { get => puntaje; }

    private void Awake()
    {
        instance = this;
    }

    public static GameController GetInstace()
    {
        return instance;
    }
    

    public void IncreaseScore()
    {
        puntaje++;
    }

    public void EndGame()
    {
        gameContainer.SetActive(false);
        sendScoreCanvas.SetActive(true);
    }

}

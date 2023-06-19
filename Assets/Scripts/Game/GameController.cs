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
    private int score;

    private static GameController instance;

    public int Score { get => score;}

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
        score++;
    }

    public void EndGame()
    {
        gameContainer.SetActive(false);
        sendScoreCanvas.SetActive(true);
    }

}

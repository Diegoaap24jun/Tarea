using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetScoreView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TMP_InputField nameInputField;

    [SerializeField]
    private Button sendButton;

    private GetScoreController controller;

    private void OnEnable()
    {
        controller = GetComponent<GetScoreController>();
        sendButton.onClick.AddListener(OnGetScore);
    }

    private void OnGetScore()
    {
        controller.GetScore(nameInputField.text, OnFinishRequest);
    }
    private void OnFinishRequest(ScoreData scoreData)
    {
        scoreText.text = $"Old Score: {scoreData.score}";
    }

}

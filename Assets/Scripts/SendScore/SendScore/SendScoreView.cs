using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SendScoreView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private string sceneName;

    [SerializeField]
    private TMP_InputField nameInputField;

    [SerializeField]
    private Button sendButton;

    private SendScoreController controller;

    private void OnEnable()
    {
        controller=GetComponent<SendScoreController>();
        scoreText.text = $"New Score: {GameController.GetInstace().Score}";
        sendButton.onClick.AddListener(OnSendScore);
    }

    private void OnSendScore()
    {
        controller.SendScore(nameInputField.text, GameController.GetInstace().Score, OnFinishRequest);
    }

    private void OnFinishRequest()
    {
        SceneManager.LoadScene(sceneName);
    }



}

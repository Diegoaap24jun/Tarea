using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetSUMView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TMP_InputField nameInputField;

    [SerializeField]
    private Button sendButton;

    private GetSUMController controller;

    private void OnEnable()
    {
        controller = GetComponent<GetSUMController>();
        sendButton.onClick.AddListener(OnGetSUM);
    }

    private void OnGetSUM()
    {
        controller.GetSUM(nameInputField.text, OnFinishRequest);
    }
    private void OnFinishRequest(SUMArrayData sumArrayData)
    {
        scoreText.text = "";
        foreach (SUMData sumData in sumArrayData.data)
        {
            scoreText.text += $"{sumData.Suma}\n";
        }
    }

}

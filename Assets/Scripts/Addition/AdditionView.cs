using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AdditionView : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField aInputField;
    [SerializeField]
    private TMP_InputField bInputField;

    [SerializeField]
    private TextMeshProUGUI resultText;

    [SerializeField]
    private Button executeButton;

    private AdditionController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponent<AdditionController>();
        executeButton.onClick.AddListener(OnExecuteButton);
    }

    void OnExecuteButton()
    {
        controller.ExecuteAddition(float.Parse(aInputField.text), float.Parse(bInputField.text), OnResult);
    }

    void OnResult(AdditionResultData resultData)
    {
        resultText.text = $"Resultado {resultData.result}";
    }

}

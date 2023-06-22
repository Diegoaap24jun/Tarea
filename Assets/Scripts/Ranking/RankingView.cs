using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RankingView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI rankingText;

    [SerializeField]
    private TMP_InputField show;

    private RankingController controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<RankingController>();
        controller.GetRanking(show.text, OnResult);
    }

    void OnResult(RankingDataArray rankingDataArray)
    {
        foreach (RankingData rankingData in rankingDataArray.data)
        {
            rankingText.text += $"{rankingData.nombreNivel} - {rankingData.nombre} -  {rankingData.puntaje}\n";
        }
    }
}

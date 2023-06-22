using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RankingController : MonoBehaviour
{
    [SerializeField]
    private RankingDataArray rankingDataArray;
    [SerializeField]
    private string nombreNivel;
    public void GetRanking(string nombre, Action<RankingDataArray> callback)
    {
        StartCoroutine(SendRankingRequest(nombre, callback));
    }

    IEnumerator SendRankingRequest(string nombre, Action<RankingDataArray> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombreNivel", nombreNivel);
        form.AddField("nombre", nombre);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/prograProm3/Tarea3.4Final/Tarea3_4_Ranking.php", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                RankingDataArray rankingDataArray = JsonUtility.FromJson<RankingDataArray>(www.downloadHandler.text);
                callback?.Invoke(rankingDataArray);
            }
        }

    }
}

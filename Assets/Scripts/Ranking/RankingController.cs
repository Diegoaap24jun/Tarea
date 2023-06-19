using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RankingController : MonoBehaviour
{
    [SerializeField]
    private RankingDataArray rankingDataArray;
    public void GetRanking(Action<RankingDataArray> callback)
    {
        StartCoroutine(SendRankingRequest(callback));
    }

    IEnumerator SendRankingRequest(Action<RankingDataArray> callback)
    {

        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/progral/e1/get_ranking.php"))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                rankingDataArray = JsonUtility.FromJson<RankingDataArray>(www.downloadHandler.text);
                callback?.Invoke(rankingDataArray);
            }
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetScoreController : MonoBehaviour
{
    public void GetScore(string username, Action<ScoreData> callback)
    {
        StartCoroutine(GetScoreRequest(username, callback));
    }

    IEnumerator GetScoreRequest(string username, Action<ScoreData> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/progral/e1/get_score.php", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                ScoreData scoreData=JsonUtility.FromJson<ScoreData>(www.downloadHandler.text);
                callback?.Invoke(scoreData);
            }
        }

    }
}

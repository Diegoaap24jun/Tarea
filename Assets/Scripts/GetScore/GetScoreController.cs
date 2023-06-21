using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetScoreController : MonoBehaviour
{
    [SerializeField]
    private string levelname;
    public void GetScore(string username, Action<ScoreArrayData> callback)
    {
        StartCoroutine(GetScoreRequest(username, callback));
    }

    IEnumerator GetScoreRequest(string username, Action<ScoreArrayData> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("levelname", levelname);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/progral/e2/get_score.php", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                ScoreArrayData scoreArrayData =JsonUtility.FromJson<ScoreArrayData>(www.downloadHandler.text);
                callback?.Invoke(scoreArrayData);
            }
        }

    }
}

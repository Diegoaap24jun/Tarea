
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendScoreController : MonoBehaviour
{
    [SerializeField]
    private string levelname;
    public void SendScore(string username, int score, Action callback)
    {
        StartCoroutine(SendScoreRequest(username, score, callback));
    }

    IEnumerator SendScoreRequest(string username, int score, Action callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("levelname", levelname);
        form.AddField("score", score);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/progral/e2/insert_score.php", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                callback?.Invoke();
            }
        }

    }
}

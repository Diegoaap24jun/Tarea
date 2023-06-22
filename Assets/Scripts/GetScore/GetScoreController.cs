using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetScoreController : MonoBehaviour
{
    [SerializeField]
    private string nombreNivel;
    public void GetScore(string nombre, Action<ScoreArrayData> callback)
    {
        StartCoroutine(GetScoreRequest(nombre, callback));
    }

    IEnumerator GetScoreRequest(string nombre, Action<ScoreArrayData> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", nombre);
        form.AddField("nombreNivel", nombreNivel);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/prograProm3/Tarea3.4Final/Tarea3_4_GetScore.php", form))
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


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendScoreController : MonoBehaviour
{
    [SerializeField]
    private string nombreNivel;
    public void SendScore(string nombre, int puntaje, Action callback)
    {
        StartCoroutine(SendScoreRequest(nombre, puntaje, callback));
    }

    IEnumerator SendScoreRequest(string nombre, int puntaje, Action callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", nombre);
        form.AddField("nombreNivel", nombreNivel);
        form.AddField("puntaje", puntaje);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/prograProm3/Tarea3.4Final/Tarea3_4_InsertScore.php", form))
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

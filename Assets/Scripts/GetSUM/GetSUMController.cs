using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetSUMController : MonoBehaviour
{
    [SerializeField]
    private string nombreNivel;
    public void GetSUM(string nombre, Action<SUMArrayData> callback)
    {
        StartCoroutine(GetSUMRequest(nombre, callback));
    }

    IEnumerator GetSUMRequest(string nombre, Action<SUMArrayData> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", nombre);
        form.AddField("nombreNivel", nombreNivel);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/prograProm3/Tarea3.4Final/Tarea3_4_SUM.php", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                SUMArrayData sumArrayData = JsonUtility.FromJson<SUMArrayData>(www.downloadHandler.text);
                callback?.Invoke(sumArrayData);
            }
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AdditionController : MonoBehaviour
{
    [SerializeField]
    private AdditionResultData resultData;

    public void ExecuteAddition(float a, float b, Action<AdditionResultData> callback)
    {
        StartCoroutine(SendAdditionRequest(a,b,callback));
    }

    IEnumerator SendAdditionRequest(float a, float b, Action<AdditionResultData> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("a", a.ToString());
        form.AddField("b", b.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/progral/unity/addition.php", form))
        {
            yield return www.SendWebRequest();
            if(www.result==UnityWebRequest.Result.ConnectionError || www.result==UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                resultData=JsonUtility.FromJson<AdditionResultData>(www.downloadHandler.text);
                callback?.Invoke(resultData);
            }
        }

    }
}

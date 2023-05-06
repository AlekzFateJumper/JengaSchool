using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using JengaSchool.Data;

namespace JengaSchool
{
    public class ApiCall : MonoBehaviour
    {
        IEnumerator GetData(Action<List<BlockData>> onSuccess)
        {
            using (UnityWebRequest req = UnityWebRequest.Get("https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack"))
            {
                yield return req.Send();
                while (!req.isDone)
                    yield return null;
                byte[] result = req.downloadHandler.data;
                string JSON = System.Text.Encoding.Default.GetString(result);
                List<BlockData> data = JsonUtility.FromJson<List<BlockData>>(JSON);
                onSuccess(data);
            }
        }
    }
}
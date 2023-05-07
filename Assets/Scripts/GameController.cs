using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using JengaSchool.Data;

namespace JengaSchool
{
    public class GameController : MonoBehaviour
    {
        public List<GameObject> stackPoints;
        public GameObject blockPrefab;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(GetData(MakeStacks));
        }

        // Update is called once per frame
        void Update()
        {

        }

        void MakeStacks(List<BlockData> data)
        {
            foreach (var item in data)
            {
                Debug.Log(item);
            }
        }

        IEnumerator GetData(Action<List<BlockData>> onSuccess)
        {
            using (UnityWebRequest req = UnityWebRequest.Get("https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack"))
            {
                yield return req.Send();
                while (!req.isDone)
                    yield return null;
                byte[] result = req.downloadHandler.data;
                string JSON_data = System.Text.Encoding.Default.GetString(result);
                JSON_data = "{\"list\":" + JSON_data + "}";
                ListData data = JsonUtility.FromJson<ListData>(JSON_data);
                onSuccess(data.list);
            }
        }
    }
}

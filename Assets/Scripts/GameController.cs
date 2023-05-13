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
        public List<String> stackNames;

        private List<int> stackFill;
        private Dictionary<String, List<BlockData>> stacks;

        void Start()
        {
            stackFill = new List<int>();
            stacks = new Dictionary<String, List<BlockData>>();
            for(int i = 0; i < stackPoints.Count; i++){
              stackFill.Add(0);
            }
            StartCoroutine(GetData(MakeStacks));
        }

        void MakeStacks(List<BlockData> data)
        {
            foreach (var item in data)
            {
                if (!stackNames.Contains(item.grade)) continue;
                if (!stacks.ContainsKey(item.grade))
                {
                    stacks.Add(item.grade, new List<BlockData>());
                }
                stacks[item.grade].Add(item);
            }

            if (stacks.Count > stackPoints.Count)
            {
              Debug.LogError("The API data has more stacks than the limit");
              return;
            }

            int i = 0;
            foreach (var stack in stacks)
            {
                // Debug.Log("Stack grade:" + stack.Key + " : " + stack.Value.Count);
                stacks[stack.Key].Sort(delegate(BlockData a, BlockData b)
                {
                    if (a.domain == b.domain)
                    {
                        if (a.cluster == b.cluster)
                        {
                            return a.standardid.CompareTo(b.standardid);
                        }
                        else
                        {
                            return a.cluster.CompareTo(b.cluster);
                        }
                    }
                    else
                    {
                        return a.domain.CompareTo(b.domain);
                    }
                });

                if(stackPoints[i].TryGetComponent<StackController>(out StackController stackObj)){
                    stackObj.setData(stack.Key, stacks[stack.Key]);
                }

                i++;
            }
        }

        IEnumerator GetData(Action<List<BlockData>> onSuccess)
        {
            using (UnityWebRequest req = UnityWebRequest.Get("https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack"))
            {
                yield return req.SendWebRequest();
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using JengaSchool.Data;

namespace JengaSchool
{
    public class StackController : MonoBehaviour
    {
        public GameObject blockPrefab;
        public TMP_Text gradeObj;

        private String grade;
        private List<BlockData> data;
        private List<GameObject> blocks;

        void Start()
        {
            data = new List<BlockData>();
            blocks = new List<GameObject>();
        }

        public void setData(String g, List<BlockData> d)
        {
            grade = g;
            data = d;
            gradeObj.text = grade;

            MakeBlocks();
        }

        private void MakeBlocks(){
            int i = 0;
            foreach (BlockData bData in data)
            {   
                int height = (int)Mathf.Floor( i / 3f );
                int turn = height % 2;
                float tilt = (i % 3) * 1.5f - 1.5f;
                float x = (turn * tilt);
                float y = .25f + (height * .5f);
                float z = ((1-turn) * tilt);
                Vector3 pos = new Vector3(x, y, z);
                GameObject block = InstantiateBlock(pos, turn, bData);
                blocks.Add(block);
                i++;
            }
        }

        private GameObject InstantiateBlock(Vector3 pos, int turn, BlockData bData)
        {
            GameObject block = Instantiate<GameObject>(blockPrefab, transform);
            Quaternion rot = Quaternion.Euler(0, (turn * 90), 0);
            block.transform.localPosition = pos;
            block.transform.localRotation = rot;
            if(block.TryGetComponent<Block>(out Block blockCtrl)){
                blockCtrl.Set(bData);
            }
            return block;
        }
    }
}

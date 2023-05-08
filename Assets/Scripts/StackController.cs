using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using JengaSchool.Data;

namespace JengaSchool
{
    public class StackController : MonoBehaviour
    {
        public GameObject blockPrefab;
        public

        private String grade;
        private List<BlockData> data;

        void Start()
        {
            data = new List<BlockData>();
        }

        public void setData(String g, List<BlockData> d)
        {
            grade = g;
            data = d;


        }
    }
}

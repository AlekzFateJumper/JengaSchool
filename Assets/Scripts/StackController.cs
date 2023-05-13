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

        void Start()
        {
            data = new List<BlockData>();
        }

        public void setData(String g, List<BlockData> d)
        {
            grade = g;
            data = d;
            gradeObj.text = grade;

            
        }
    }
}

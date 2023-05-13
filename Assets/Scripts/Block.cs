using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JengaSchool.Data;

namespace JengaSchool
{
    public class Block : MonoBehaviour
    {
        public List<Material> materials;

        private BlockData Data;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        public void Set(BlockData d)
        {
            Data = d;
        }
        // {Grade level}: {Domain}
        // {Cluster}
        // {Standard ID}: {Standard Description}


    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JengaSchool.Data;

namespace JengaSchool
{
    public class Block : MonoBehaviour
    {
        public List<Material> materials;
        public GameObject cube;

        private BlockData bData;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        public void Set(BlockData d)
        {
            bData = d;

            if(cube.TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
            {
                Material[] mat = mesh.materials;
                mat[0] = materials[bData.mastery];
                mesh.materials = mat;
            }
        }
        
        // {Grade level}: {Domain}
        // {Cluster}
        // {Standard ID}: {Standard Description}


    }
}
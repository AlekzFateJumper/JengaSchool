using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JengaSchool.Data;

namespace JengaSchool
{
    public class Block : MonoBehaviour
    {
        public List<Material> materials;

        [SerializeField]
        private BlockData bData;

        public void Set(BlockData d)
        {
            bData = d;

            if(TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
            {
                Material[] mat = mesh.materials;
                mat[0] = materials[bData.mastery];
                mesh.materials = mat;
            }
        }

        void OnMouseEnter(){
            if(transform.rotation.y > 0) transform.localPosition += new Vector3(0,0,-.3f);
            else transform.localPosition += new Vector3(-.3f,0,0);
        }

        void OnMouseExit(){
            if(transform.rotation.y > 0) transform.localPosition += new Vector3(0,0,.3f);
            else transform.localPosition += new Vector3(.3f,0,0);
        }

        void OnMouseOver()
        {
            if(Input.GetMouseButtonDown(2)){
                GameObject.Find("GameController").SendMessage("OpenDetails", bData);
            }
        }

    }
}

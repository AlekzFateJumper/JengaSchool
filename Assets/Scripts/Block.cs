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
        public BlockData bData;

        public void Set(BlockData d)
        {
            bData = d;

            if(TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
            {
                Material[] mat = mesh.materials;
                mat[0] = materials[bData.mastery];
                mesh.materials = mat;
            }
            if(TryGetComponent<Rigidbody>(out Rigidbody body))
            {
                body.mass = (bData.mastery + 1) * 5;
            }
        }

        void OnMouseEnter(){
            if(transform.localEulerAngles.y < 45 || transform.localEulerAngles.y > 300) transform.localPosition += new Vector3(-.25f,0,0);
            else transform.localPosition += new Vector3(0,0,-.25f);
        }

        void OnMouseExit(){
            if(transform.localEulerAngles.y < 45 || transform.localEulerAngles.y > 300) transform.localPosition += new Vector3(.25f,0,0);
            else transform.localPosition += new Vector3(0,0,.25f);
        }

        void OnMouseOver()
        {
            if(Input.GetMouseButtonDown(2)){
                GameObject.Find("GameController").SendMessage("OpenDetails", bData);
            }
        }

    }
}

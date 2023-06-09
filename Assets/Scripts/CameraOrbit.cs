using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JengaSchool
{
    public class CameraOrbit : MonoBehaviour {


        public List<GameObject> Alvos;
        public int Tempo;

        public GameObject BtnTestStack;
        public GameObject BtnResetStack;

        private GameObject Alvo;
        private int index = 1;
        private float VelocidadeHorizontal = 100f;
        private float VelocidadeVertical = 60f;


        void Start(){
            Alvo = Alvos[index];
        }

        void Update ()
        {
            Vector3 lilUp = Alvo.transform.position + new Vector3(0, 3, 0);
            transform.LookAt(lilUp, Vector3.up);
            if(Input.GetMouseButton(0)){
                float zs = Mathf.Sign(transform.position.z);
                var VelHorizontal = VelocidadeHorizontal * Input.GetAxis("Mouse X");
                var VelVertical = VelocidadeVertical * Input.GetAxis("Mouse Y") * zs;
                if( transform.position.y > 1.5f || ( zs * VelVertical < 0 )){
                    transform.RotateAround(lilUp, new Vector3(VelVertical, VelHorizontal, 0), Tempo * Time.deltaTime);
                }
            }
        }

        public void TestMyStack(){
            if(Alvo.TryGetComponent<StackController>(out StackController stackCtrl)){
                stackCtrl.SendMessage("TestMyStack");
                BtnTestStack.SetActive(false);
                BtnResetStack.SetActive(true);
            }
        }

        public void ResetStack(){
            if(Alvo.TryGetComponent<StackController>(out StackController stackCtrl)){
                stackCtrl.SendMessage("ResetStack");
                BtnTestStack.SetActive(true);
                BtnResetStack.SetActive(false);
            }
        }

        public void SetTarget(int step){
            index = ( index + step ) % Alvos.Count;
            Alvo = Alvos[index];
            transform.position = new Vector3(Alvo.transform.position.x, 5, -11);
            if(Alvo.TryGetComponent<StackController>(out StackController stackCtrl)){
                BtnTestStack.SetActive(!stackCtrl.testing);
                BtnResetStack.SetActive(stackCtrl.testing);
            }
        }
    }
}

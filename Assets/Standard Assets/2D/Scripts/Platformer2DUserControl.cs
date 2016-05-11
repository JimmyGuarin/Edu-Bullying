using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public bool puedeEmpezr = false;

        private bool saltoAnterior = false;


        public ArrayList fuerzaSalto = new ArrayList();
        public ArrayList estadoSalto = new ArrayList();


        private bool activoSegundo = false;
        private int contador = 0;

       
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
               
                    Debug.Log("cambieestado");
                    estadoSalto.Add(m_Jump);
                    saltoAnterior = m_Jump;
                
                
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
         
                fuerzaSalto.Add(h);
            
           

            // Pass all parameters to the character control script.
            if(activoSegundo ==false)
            {
                m_Character.Move(h, crouch, m_Jump);
            }
            
            if (transform.position.x >= 2)
            {
                m_Character.Move(h, crouch, m_Jump);
                puedeEmpezr = true;
                activoSegundo = true;
            }
           

            m_Jump = false;
        }
        
    }
}

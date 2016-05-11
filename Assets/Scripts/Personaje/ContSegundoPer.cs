using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;
using System.Collections;



[RequireComponent(typeof(PlatformerCharacter2D))]
public class ContSegundoPer : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;

    public GameObject personaje;
    private bool empezar = false;
    private bool saltoAnterior = false;






    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();


    }


    private void Update()
    {

        if (personaje.GetComponent<Platformer2DUserControl>().puedeEmpezr == true)
        {
            //Debug.Log("Puede EMpezar");
            empezar = true;
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        if (empezar == true)
        {

            if (personaje.GetComponent<Platformer2DUserControl>().fuerzaSalto.Count != 0)
            {


                bool salto = (bool)personaje.GetComponent<Platformer2DUserControl>().estadoSalto[0];
                float h = (float)personaje.GetComponent<Platformer2DUserControl>().fuerzaSalto[0];


                m_Character.Move(h, false, salto);

                personaje.GetComponent<Platformer2DUserControl>().fuerzaSalto.RemoveAt(0);
                personaje.GetComponent<Platformer2DUserControl>().estadoSalto.RemoveAt(0);
                


                //saltoAnterior = (bool)personaje.GetComponent<Platformer2DUserControl>().estadoSalto[0];


            }




        }


    }


}


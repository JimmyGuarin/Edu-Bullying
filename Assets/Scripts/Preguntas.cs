using UnityEngine;
using System.Collections;

public class Preguntas{


    private string enunciado;
    private string respuestaCorrecta;
    private string respuestaFalsa1;

    private bool multiple;

    private string[] respuestasMultiple;
    private string[] respuestasDual;

    
    public Preguntas(string rBuena,string rFalsa1,string rFalsa2,string rFalsa3){
 
        respuestasMultiple= new string[4]{ rBuena,rFalsa1,rFalsa2,rFalsa3};
        respuestaCorrecta = rBuena;
    }

    public Preguntas(string rBuena, string rFalsa){

        respuestasDual= new string[2] { rBuena, rFalsa};
        respuestaCorrecta = rBuena;
    }

    public string Enunciado{
        get
        {
            return enunciado;
        }

        set
        {
            enunciado = value;
        }
            
    }
    public void Barajar(string[] arreglo){
        for(int i = 0; i < arreglo.Length; i++){
            string temp = arreglo[i];
            int randomIndex = Random.Range(0,arreglo.Length);
            arreglo[i] = arreglo[randomIndex];
            arreglo[randomIndex] = temp;

        }
    }
}

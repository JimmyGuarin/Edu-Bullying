using UnityEngine;
using System.Collections;

public class Preguntas{


    private string enunciado;
    private string respuestaCorrecta;
    private string respuestaFalsa1;

    private bool multiple;

    private string[] respuestasMultiple;
    private string[] respuestasDual;

    
    public Preguntas(string enun,string rBuena,string rFalsa1,string rFalsa2,string rFalsa3){

        enunciado = enun;
        respuestasMultiple= new string[4]{ rBuena,rFalsa1,rFalsa2,rFalsa3};
        respuestaCorrecta = rBuena;
        multiple = true;
        Barajar(respuestasMultiple);
    }

    public Preguntas(string enun,string rBuena, string rFalsa){

        enunciado = enun;
        respuestasDual = new string[2] { rBuena, rFalsa};
        respuestaCorrecta = rBuena;
        multiple = false;
        Barajar(respuestasDual);
    }

    public string Enunciado{

        get {return enunciado;}
        set {enunciado = value;}
    }



    public bool IsMultiple{

        get { return multiple;}
    }


    public string[] Respuestas {

        get {
            if (multiple)
                return respuestasMultiple;
            else
                return respuestasDual;
        }
    }
    

    public bool EsCorrecta(string respuesta) {

        if (respuestaCorrecta.Equals(respuesta))
            return true;
        else
            return false;
    }

    public void Barajar(string[] arreglo){
        for(int i = 0; i < arreglo.Length; i++){
            string temp = arreglo[i];
            int randomIndex = Random.Range(0,arreglo.Length);
            arreglo[i] = arreglo[randomIndex];
            arreglo[randomIndex] = temp;

        }
    }

    public int IndexCorreta(){
        if (multiple){
            for (int i = 0; i <respuestasMultiple.Length; i++){
                if (respuestasMultiple[i].Equals(respuestaCorrecta))
                    return i;

            }
        }
        else{
            for (int i = 0; i < respuestasDual.Length; i++)
            {
                if (respuestasDual[i].Equals(respuestaCorrecta))
                    return i;
            }
        }
        return -1;
    }
}

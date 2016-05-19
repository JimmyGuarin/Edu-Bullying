﻿using UnityEngine;
using System.Collections;

public class BullyingPsicologico : MonoBehaviour {


    public Nivel miNivel;
    public MaquinaEstadosConver conversacion;


    void Awake()
    {
        //Creando Motor de preguntas del Nivel--------------------------------------------
        miNivel = new Nivel();

        PuntosRetro p1 = new PuntosRetro("Hay Bullying Psicológico cuando hay <color=#a52a2aff><b>persecución</b></color>, que es una manera agresiva y continua de acosar a alguien a fin de que haga lo que la otra persona quiere.");
        p1.misPreguntas.Add(new Preguntas("Existe Bullying Psicológico cuando hay", "Persecucione", "Robos", "Golpes", "Acoso sexual", true));
        p1.misPreguntas.Add(new Preguntas("¿En el Bullying Psicológico se presenta el acoso sexual?", "No", "Sí"));
        p1.Barajar();

        PuntosRetro p2 = new PuntosRetro("El Bullying Psicológico se presenta cuando hay <color=#a52a2aff><b> intimidación</b></color>, que significa causar o infundir miedo. El miedo es una angustia a causa de un riesgo o daño real o imaginario.");
        p2.misPreguntas.Add(new Preguntas("Existe Bullying Psicológico cuando hay", "Intimidaciones", "Robos", "Palizas", "Acoso sexual", true));
        p2.misPreguntas.Add(new Preguntas("¿ Si alguien provoca miedo en los demás compañeros les está causando Bullying Piscológico ?", "Si", "No"));
        p2.Barajar();

       

        miNivel.puntosRetro.Add(p1);
        miNivel.puntosRetro.Add(p2);

        GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().misPuntosRetro = miNivel.puntosRetro;
        GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().Barajar();

        //Creando Sistema de conversación del nivel------------------------------------------------------------------------------------------

        //EstadoConversacion ec0 = new EstadoConversacion(0, new Preguntas("Deseas que te pegue", "tal vez", "quiero hablarte del bullying", "ya me canse de eso", "", false));
        //EstadoConversacion ec1 = new EstadoConversacion(0, new Preguntas("Pues entonces lo haré", "No por favor", "Lo que sea", "Se lo diré a mi mamá", "", false));
        //EstadoConversacion ec2 = new EstadoConversacion(0, new Preguntas("Y que es esa cosa", "Es lo que tu me haces", "Es pegarle a los otros", "la profesora lo sabe", "", false));
        //EstadoConversacion ec3 = new EstadoConversacion(0, new Preguntas("Y que vas hacer", "Pegarte", "Se lo diré a mi mamá", "Decirle a tu mamá", "", false));
        //EstadoConversacion ec4 = new EstadoConversacion(0, new Preguntas("Por que no tendria que hacerlo", "Por que voy a hablarte de Bullying", "Por que aquí está la profe", "Se lo diré a mi mamá", "", false));
        //EstadoConversacion ec5 = new EstadoConversacion(0, new Preguntas("Te pegaré!!!", "No por favor", "Estoy listo", "la profesora lo sabra", "", false));
        //EstadoConversacion ec6 = new EstadoConversacion(0, new Preguntas("Pues digale", "Eso Haré", "Se lo diré a tu mamá", "tal vez", "", false));

        //ec0.AgregarProximos(new int[3] { 1, 2, 3 });
        //ec1.AgregarProximos(new int[3] { 4, 5, 6 });


        //conversacion.estados = new EstadoConversacion[7] { ec0, ec1, ec2, ec3, ec4, ec5, ec6 };



    }
}

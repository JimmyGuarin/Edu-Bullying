using UnityEngine;
using System.Collections;

public class EstadoConversacion{

    //Profesora a Player=0
    //Enemigo a Player=1
    //Profesora a Enemigo=2
    //Enemigo a Profesora=3
    public int tipo;

    //Si es de tipo 2 0 3 Respuesta buena
    //es el enunciado del receptor
    public Preguntas pregunta;
    public int[] proximos;


	public EstadoConversacion(int tip,Preguntas pregt)
    {
        tipo = tip;
        pregunta = pregt;
       

    }

    public void AgregarProximos(int[] proxs)
    {
        proximos = proxs;
    }


}

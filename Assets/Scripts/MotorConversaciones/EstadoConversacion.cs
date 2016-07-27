using UnityEngine;
using System.Collections;

public class EstadoConversacion{


    public int [] calificaciones;

    public Preguntas pregunta;
    public int[] proximos;


	public EstadoConversacion(int[] tip,Preguntas pregt)
    {
        calificaciones = tip;
        pregunta = pregt;
       

    }

    public void AgregarProximos(int[] proxs)
    {
        proximos = proxs;
    }


}

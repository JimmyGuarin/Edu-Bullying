using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MaquinaEstadosConver : MonoBehaviour{


    public EstadoConversacion[] estados;
    private int estadoActual;

    public Sprite imagenProfesora;
    public Sprite imagenVillano;


    public GameObject canvasPlayerNpc;
    public Image personajePlayerNpc;
    public Text textoPlayerNpc;
    public Button[] botonesNpc;

    void Start()
    {
        estadoActual = 0;
    }


    public void CambiarEstado(int i)
    {
        estadoActual = estados[estadoActual].proximos[i];
        Moldear();
    }

    public void Moldear()
    {
        EstadoConversacion converActual= estados[estadoActual];
        

        switch (converActual.tipo)
        {
            case 0:
                personajePlayerNpc.sprite = imagenProfesora;
                textoPlayerNpc.text = converActual.pregunta.Enunciado;
                for(int i = 0; i <3; i++)
                {

                    if (converActual.proximos!=null&& converActual.proximos.Length > 3)
                    {
                       
                        botonesNpc[i].onClick.AddListener(() => { CambiarEstado(converActual.proximos[i]); });
                    }
                    botonesNpc[i].GetComponentInChildren<Text>().text = converActual.pregunta.Respuestas[i];


                }
                canvasPlayerNpc.SetActive(true);
                break;

        }
    }



}

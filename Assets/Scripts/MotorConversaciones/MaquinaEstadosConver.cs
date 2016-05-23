using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MaquinaEstadosConver : MonoBehaviour{


    public EstadoConversacion[] estados;
    private int estadoActual;

    
    public Sprite[] imagenesVillano;

    //public Image personajePlayerNpc;
    public Text textoPlayerNpc;
    public Button[] botonesNpc;
    public Slider SliderVillano;
    public Image imagenActualVillano;
    void Start()
    {
        estadoActual = 0;
        Debug.Log(estados.Length);

        Moldear();
    }


    public void CambiarEstado(int i)
    {
     
        estadoActual = estados[estadoActual].proximos[i];
        int suma = estados[estadoActual].tipo;
        StartCoroutine(MoverSlider(suma));
        Moldear();
        
    }

    public void Moldear()
    {
        EstadoConversacion converActual= estados[estadoActual];
        

        //switch (converActual.tipo)
        //{
        //    case 0:
               // personajePlayerNpc.sprite = imagenProfesora;
                textoPlayerNpc.text = converActual.pregunta.Enunciado;
                for(int i = 0; i <3; i++)
                {

                    if (converActual.proximos!=null&& converActual.proximos.Length > 3)
                    {
                       
                        botonesNpc[i].onClick.AddListener(() => { CambiarEstado(converActual.proximos[i]); });
                    }
                    botonesNpc[i].GetComponentInChildren<Text>().text = converActual.pregunta.Respuestas[i];


                }
               // gameObject.SetActive(true);
              //  break;

       // }
    }

    IEnumerator MoverSlider(int valor)
    {
        Debug.Log(valor);

        while (valor != 0)
        {
           
            if (valor < 0)
            {
               
                valor++;
                SliderVillano.value -= 1;
            }

            else
            {
                SliderVillano.value += 1;
                valor--;
            }
                

            switch ((int)SliderVillano.value)
            {
                case 20:

                    imagenActualVillano.sprite = imagenesVillano[0];   
                    break;
                case 30:
                    imagenActualVillano.sprite = imagenesVillano[1];
                    break;
                case 50:
                    imagenActualVillano.sprite = imagenesVillano[2];
                    break;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

}

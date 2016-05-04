using UnityEngine;
using System.Collections;

public class Nivel {

    public ArrayList puntosRetro;



    public Nivel() {

        puntosRetro = new ArrayList();
    }


    public void Barajar()
    {
        for (int i = 0; i < puntosRetro.Count; i++)
        {
            Preguntas temp = (Preguntas)puntosRetro[i];
            int randomIndex = Random.Range(0, puntosRetro.Count);
            puntosRetro[i] = puntosRetro[randomIndex];
            puntosRetro[randomIndex] = temp;

        }
    }


}

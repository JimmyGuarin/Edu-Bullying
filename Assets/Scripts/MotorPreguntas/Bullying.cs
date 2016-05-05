using UnityEngine;
using System.Collections;

public class Bullying : MonoBehaviour {


    public ArrayList misPuntosRetro;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Barajar()
    {
        for (int i = 0; i < misPuntosRetro.Count; i++)
        {
            PuntosRetro temp = (PuntosRetro)misPuntosRetro[i];
            int randomIndex = Random.Range(0, misPuntosRetro.Count);
            misPuntosRetro[i] = misPuntosRetro[randomIndex];
            misPuntosRetro[randomIndex] = temp;

        }
    }
}

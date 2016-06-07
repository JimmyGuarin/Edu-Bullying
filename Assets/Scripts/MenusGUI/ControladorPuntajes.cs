using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControladorPuntajes : MonoBehaviour {


    


	// Use this for initialization
	void Start () {
	

        for(int i = 1; i < 6; i++)
        {
            transform.GetChild(i-1).GetChild(0).GetComponent<Text>().text= ""+ PlayerPrefs.GetString("nombre"+i)+" "+PlayerPrefs.GetInt("highscorePos" + i);
        }
        if (ControladorHUD.posicionPuntajes != 0)
        {
            transform.GetChild(ControladorHUD.posicionPuntajes - 1).GetChild(0).GetComponent<Text>().color = Color.red;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class HideMouse : MonoBehaviour {

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out Point pos);


    Point cursorPos = new Point();
    

    // Use this for initialization
    void Start () {

        GetCursorPos(out cursorPos);
        
    }
	
	// Update is called once per frame
	void Update () {

      //  SetCursorPos(0,0);
	
	}
}

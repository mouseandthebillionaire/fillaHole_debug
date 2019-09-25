using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
	    DontDestroyOnLoad(this);
	    Screen.SetResolution(300,400,false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

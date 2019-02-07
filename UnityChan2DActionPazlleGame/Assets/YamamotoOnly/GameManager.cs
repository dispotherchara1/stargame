using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    bool GameOver = false;
    

	void Start () {

	}
	

	void Update () {
		
	}


    public void Setgameover(int a)
    {
        if (a == 0) GameOver = true;
        else GameOver = false;
    }
    public bool Getgameover()
    {
        return GameOver;
    }
}
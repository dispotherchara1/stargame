using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    bool GameOver = false,GameClear=false;
    
    void Awake()
    {
        Debug.Log("汚れつちまつた悲しみに　今日も小雪の降りかかる\n汚れつちまつた悲しみに　今日も風さえ吹きかかる");
    }

	void Start () {
        
	}
	

	void Update () {
	    
	}

    public void Setgameclear(int a)
    {
        if (a == 0) GameClear = true;
        else GameClear = false;
    }
    public bool Getgameclear()
    {
        return GameClear;
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
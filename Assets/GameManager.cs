using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public string _stageName = "Stage Zero";

    public enum GameStage
    {
        inti = 0,
        dataLoad = 1,
        start = 2,
        GameLoop = 3,
        GameEnd = 4,
        destory = 5
    }

    public GameStage state;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        switch (state)
        {
            case GameStage.inti:
                {
                    Debug.Log("My state is init");
                }
                break;

                case GameStage.dataLoad:
                {
                    Debug.Log("My state is DataLoad");
                }
                break;
                case GameStage.start:
                {

                    Debug.Log("My state is start");
                }
                break;
                case GameStage.GameLoop:
                {
                    Debug.Log("My state is gameloop");
                }
                break;

                case GameStage.GameEnd:
                {
                    Debug.Log("My state is gameend");
                }
                break;

                case GameStage.destory: 
                {
                    Debug.Log("My state is destory");
                }
                break;
        }
    }
}


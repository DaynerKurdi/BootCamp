using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private string _stageName = "Stage Zero";

    private GMBaseState _currentState;

    private InitState _initStaet = new InitState();
    private LoadDataState _loadStaet = new LoadDataState();

    private ResourcesLoader _resourcesLoader;

    private PlayerMainManger _playerManager;
    private EnemeyMainManger _enemyMainManger;
    private BulletMainManger _bulletMainManger;
    private GameUiMainManager _gameUiMainManager;

    private EventSystemRef _eventSystem;

    public void SwitchState(GMBaseState nextState)
    {
        _currentState.OnExitState(this);
        _currentState = nextState;
        _currentState.OnEnterState(this);
    }

    public void InitStateOnEnterState()
    {
        Debug.Log("this is on Enter for init State");


        _playerManager = FindAnyObjectByType<PlayerMainManger>();
        _enemyMainManger = FindAnyObjectByType<EnemeyMainManger>();
        _bulletMainManger = FindAnyObjectByType<BulletMainManger>();
        _eventSystem = FindAnyObjectByType<EventSystemRef>();
        _gameUiMainManager = FindAnyObjectByType<GameUiMainManager>();
        _resourcesLoader = GetComponent<ResourcesLoader>();

        _resourcesLoader.Init();

        _playerManager.Init();
        _enemyMainManger.Init();
        _bulletMainManger.Init();
        _eventSystem.Init();
        _gameUiMainManager.Init();


        SwitchState(_loadStaet);
    }

    public void InitStateOnUpdateState()
    {
        Debug.Log("this is on Update for init State");
    }

    public void InitStateOnExitState()
    {
        Debug.Log("this is on Exit for init State");
    }

    public void DataLoadStateOnEnterState()
    {
        _resourcesLoader.LoadSprite();
        Debug.Log("this is on Enter for Load Data State");
    }

    public void DataLoadStateOnUpdateState()
    {
        Debug.Log("this is on Update for Load Data State");
        _playerManager.UpdateScript();
        _enemyMainManger.UpdateScript();
        _bulletMainManger.UpdateScript();
    }

    public void DataLoadStateOnExitState()
    {
        Debug.Log("this is on Exit for Load Data State");
    }


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

        _currentState = _initStaet;
        _initStaet.OnEnterState(this);
    }

   
    public void Update()
    {
        _currentState.OnUpdateState(this);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchState(_loadStaet);
        }
    }
}


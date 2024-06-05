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

    private LoadDataState _loadState = new LoadDataState();
    private InitState _initSate = new InitState();
    private GameLoopState _gameLoopState = new GameLoopState();

    private ResourcesLoader _resourcesLoader;
    private PlayerMainManger _playerManager;
    private EnemeyMainManger _enemyMainManger;
    private BulletMainManger _bulletMainManger;
    private GameUiMainManager _gameUiMainManager;
    private ExplosionManager _explosionManager;

    private EventSystemReference _eventSystem;

    public void SwitchState(GMBaseState nextState)
    {
        _currentState.OnExitState(this);
        _currentState = nextState;
        _currentState.OnEnterState(this);
    }

    public void DataLoadStateOnEnterState()
    {
        Debug.Log("this is on Enter for Load Data State");

        _eventSystem = GetComponent<EventSystemReference>();
        _resourcesLoader = GetComponent<ResourcesLoader>();

        _eventSystem.Initialize();

        _resourcesLoader.Initialize();

        _resourcesLoader.LoadSprite();

        SwitchState(_initSate); 

    }

    public void DataLoadStateOnUpdateState()
    {
        Debug.Log("this is on Update for Load Data State");
    }

    public void DataLoadStateOnExitState()
    {
        Debug.Log("this is on Exit for Load Data State");
    }

    public void InitStateOnEnterState()
    {
        Debug.Log("this is on Enter for init State");
       
        _playerManager = FindAnyObjectByType<PlayerMainManger>();
        _enemyMainManger = FindAnyObjectByType<EnemeyMainManger>();
        _bulletMainManger = FindAnyObjectByType<BulletMainManger>();
        _gameUiMainManager = FindAnyObjectByType<GameUiMainManager>();
        _explosionManager = FindAnyObjectByType<ExplosionManager>();

        _playerManager.Initialize();
        _enemyMainManger.Initialize();
        _bulletMainManger.Initialize();
        _gameUiMainManager.Initialize();
        _explosionManager.Initialize();

        SwitchState(_gameLoopState);
    }

    public void InitStateOnUpdateState()
    {
        Debug.Log("this is on Update for init State");
    }

    public void InitStateOnExitState()
    {
        Debug.Log("this is on Exit for init State");
    }

    public void GameLoopOnEnterState()
    {
        _enemyMainManger.BeginWave(45);
        _playerManager.SetScore();
        DataPersistenceManager.Instance.LoadGame();
    }

    public void OnGameLoopOnUpdateState()
    {
        _playerManager.UpdateScript();
        _enemyMainManger.UpdateScript();
        _bulletMainManger.UpdateScript();
        _explosionManager.UpdateScript();
    }

    public void OnGameLoopExitState()
    {

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

        _currentState = _loadState;
        _currentState.OnEnterState(this);
    }

    public void Start()
    {
        
    }


    public void Update()
    {
        _currentState.OnUpdateState(this);
    }

    public void OnApplicationQuit()
    {
        DataPersistenceManager.Instance.SaveGame();
    }
}


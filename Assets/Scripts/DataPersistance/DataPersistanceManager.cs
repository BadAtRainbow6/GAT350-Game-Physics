using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class DataPersistanceManager : MonoBehaviour
{
    [SerializeField] string fileName;

    private GameData gameData;

    private List<IDataPersistance> dataPersistanceObjects;
    private FileDataHandler dataHandler;

    public static DataPersistanceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one data manager in scene.");
        }
        Instance = this;
    }

    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();

        // only runs if there's no game data; creates a new game
        if(gameData == null)
        {
            Debug.Log("No game data found. Initializing to defaults.");
            NewGame();
        }
        foreach(IDataPersistance obj in dataPersistanceObjects)
        {
            obj.LoadData(gameData);
        }
        Debug.Log("Player Pos Loaded: " + gameData.playerPos);
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void SaveGame()
    {
        foreach (IDataPersistance obj in dataPersistanceObjects)
        {
            obj.SaveData(ref gameData);
        }
        Debug.Log("Player Pos Saved: " + gameData.playerPos);
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}

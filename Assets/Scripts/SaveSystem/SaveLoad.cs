using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad Instance;
    [SerializeField] private KeyBinder _keybinder;
    [SerializeField] private ObjectsConfig _objectsConfig;
    private string _fileName = "save";
    private string _saveFolder;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _saveFolder = Application.persistentDataPath + "/Save/";
    }

    private void Start()
    {
        Load(_fileName);
    }

    public void Save(string fileName)
    {
        string saveResult = null;
        
        if (!Directory.Exists(_saveFolder))
        {
            Directory.CreateDirectory(_saveFolder);
        }
        
        foreach (var savableStatic in SceneObjectKeeper.Instance.GetStaticObjects())
        {
           saveResult += savableStatic.GetSaveFormat() + "\n";
        }

        foreach (var savableDynamic in SceneObjectKeeper.Instance.FindDynamicObjects())
        {
            saveResult += savableDynamic.GetSaveFormat() + "\n";
        }

        File.WriteAllText(_saveFolder + fileName + ".sav", saveResult);
    }

    public void Load(string fileName)
    {
        if (Directory.Exists(_saveFolder) && File.Exists(_saveFolder + fileName + ".sav"))
        {
            LoadStatic(0, out int endedLine);
            LoadDynamic(endedLine);
        }
    }

    private void LoadStatic(int loadStartLine, out int endedLine)
    {
        int endLine = 0;
        SavableObjectStatic[] staticObjects = SceneObjectKeeper.Instance.GetStaticObjects();
        string[] jsonLines = File.ReadAllLines(_saveFolder + _fileName + ".sav");
            for (int i = loadStartLine; i < jsonLines.Length; i++)
            {
                if (jsonLines[i].StartsWith("#static"))
                {
                    endLine++;
                    
                    string readyLine = jsonLines[i].Replace("#static", "");
                    
                    var parsedId = JObject.Parse(readyLine);
                    
                    int objectId = parsedId["_gameObjectId"].Value<int>();
                    
                    SavableObjectStatic staticObject = (from x in staticObjects where x.GetId()==objectId select x).ElementAtOrDefault(0);
                    JsonUtility.FromJsonOverwrite(readyLine,staticObject);
                    staticObject.Initialize();
                }
                else
                {
                    break;
                }
            }
            endedLine = endLine;
    }

    private void LoadDynamic(int loadStartLine)
    {
        string[] jsonLines = File.ReadAllLines(_saveFolder + _fileName + ".sav");
            for (int i = loadStartLine; i < jsonLines.Length; i++)
            {
                if (!jsonLines[i].StartsWith("#static"))
                { 
                    string key = jsonLines[i].Split(' ')[0];
                    string newLine = jsonLines[i].Replace(key, "");
                    
                    Enum.TryParse(key, out ObjectType lineKey);
                    
                    SavableObjectDynamic newObject = Instantiate(_objectsConfig.AllObjects[lineKey]);
                    
                    JsonUtility.FromJsonOverwrite(newLine,newObject);
                    
                    newObject.Initialize();
                }
            }
    }

    private SavableObject[] GetObjectsForSave()
    {
        return SceneObjectKeeper.Instance.FindAllObjects();
    }

}

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Data : ScriptableObject
{
    public enum TypesOfSpawn 
    {
        FromPrefabs,
        Random
    }
    [HideInInspector] public GameObject FirstSceneTeleport;
    [HideInInspector] public GameObject FirstTeleport;
    [HideInInspector] public GameObject SecondTeleport;
    [HideInInspector] public GameObject ThirdTeleport;
    [HideInInspector] public GameObject FourthTeleport;

    private List<GameObject> _newObjects = new List<GameObject>();
    private List<Vector3> _objectPositions = new List<Vector3>();

    [Header("Настройки значений")]
    public int StartHP;
    public int StartXP;
    public int XPForClick;
    public int HPForClick;
    public int ClicksForDestroy;

    [Header("Телепорт во второй сцене")]
    public GameObject SecondSceneTeleport;

    [Header("Тип спавна объектов")]
    public TypesOfSpawn TypeOfSpawn;

    [Header("Префабы с нужными позициями")]
    [SerializeField] private List<GameObject> _objectsPrefabs = new List<GameObject>();

    public void SpawnFromPrefabs()
    {
        _objectPositions.Clear();
        foreach (GameObject obj in _objectsPrefabs)
        {
            Instantiate(obj);
            _objectPositions.Add(obj.transform.position);
            switch (obj.name)
            {
                case "TeleportToSecondScene":
                    FirstSceneTeleport = obj;
                    break;
                case "FirstTeleport":
                    FirstTeleport = obj;
                    break;
                case "SecondTeleport":
                    SecondTeleport = obj;
                    break;
                case "ThirdTeleport":
                    ThirdTeleport = obj;
                    break;
                case "FourthTeleport":
                    FourthTeleport = obj;
                    break;
                default:
                    break;
            }
        }
    }

    public void RandomSpawn()
    {
        _objectPositions.Clear();
        _newObjects.Clear();
        foreach (GameObject obj in _objectsPrefabs)
        {
            _objectPositions.Add(obj.transform.position);
        }
        int _capacity = _objectPositions.Capacity;
        int n = _capacity;
        for (int i = 0; i < _capacity; i++)
        {
            int r = Random.Range(0, n);
            GameObject newObj = Instantiate(_objectsPrefabs[i]);
            newObj.transform.position = _objectPositions[r];
            _newObjects.Add(newObj);
            _objectPositions.RemoveAt(r);
            n--;
        }
        foreach (GameObject obj in _newObjects)
        {
            _objectPositions.Add(obj.transform.position);
            switch (obj.name)
            {
                case "TeleportToSecondScene(Clone)":
                    FirstSceneTeleport = obj;
                    break;
                case "FirstTeleport(Clone)":
                    FirstTeleport = obj;
                    break;
                case "SecondTeleport(Clone)":
                    SecondTeleport = obj;
                    break;
                case "ThirdTeleport(Clone)":
                    ThirdTeleport = obj;
                    break;
                case "FourthTeleport(Clone)":
                    FourthTeleport = obj;
                    break;
                default:
                    break;
            }
        }
    }

    public void ReSpawnObjects()
    {
        for (int i = 0; i < _objectsPrefabs.Capacity; i++)
        {
            GameObject newObj = Instantiate(_objectsPrefabs[i]);
            newObj.transform.position = _objectPositions[i];
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController singleton { get; private set; }

    public Data Data;
    [HideInInspector] public static bool IsNewGame = false;
    [HideInInspector] public UnityAction GameOverAction;

    [SerializeField] private GameObject _player;

    [HideInInspector] public bool CanMove = true;
    [HideInInspector] public bool IsFirstSceneTeleport = true;
    [HideInInspector] public Vector3 FirstTeleportPos;
    [HideInInspector] public Vector3 SecondTeleportPos;
    [HideInInspector] public Vector3 ThirdTeleportPos;
    [HideInInspector] public Vector3 FourthTeleportPos;
    [HideInInspector] public Vector3 FirstSceneTeleportPos;
    [HideInInspector] public Vector3 SecondSceneTeleportPos;


    private void Awake()
    {
        if (!singleton)
        {
            singleton = this;
            DontDestroyOnLoad(this);
            if (Data.TypeOfSpawn == Data.TypesOfSpawn.FromPrefabs)
            {
                Data.SpawnFromPrefabs();
            }
            else
            {
                Data.RandomSpawn();
            }
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "GameScene")
                Data.ReSpawnObjects();
            Destroy(gameObject);
        }
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            Instantiate(_player);
        }
    }

    void Start()
    {
        FirstTeleportPos = Data.FirstTeleport.transform.position;
        SecondTeleportPos = Data.SecondTeleport.transform.position;
        ThirdTeleportPos = Data.ThirdTeleport.transform.position;
        FourthTeleportPos = Data.FourthTeleport.transform.position;

        FirstSceneTeleportPos = Data.FirstSceneTeleport.transform.position;
        SecondSceneTeleportPos = Data.SecondSceneTeleport.transform.position;
    }

    public void NewGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        CanMove = true;
        _player.GetComponent<Player>().HP = Data.StartHP;
        _player.GetComponent<Player>().XP = Data.StartXP;
    }

    public IEnumerator DisableMovement()
    {
        CanMove = false;
        yield return new WaitForSeconds(.1f);
        CanMove = true;
    }
}

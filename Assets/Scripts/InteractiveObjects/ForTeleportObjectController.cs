using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForTeleportObjectController : InteractiveObject
{
    private enum TypeOfTeleport
    {
        inScene,
        betweenScene
    }

    private enum NumberOfTeleport
    {
        First,
        Second,
        Third,
        Fourth
    }

    [SerializeField] private TypeOfTeleport _typeOfTeleport;
    [SerializeField] private NumberOfTeleport _numberOfTeleport;

    private string _tag = "ForTeleport";
    private InteractiveAreaController _areaController;
    private GameObject _player;

    void Start()
    {
        _areaController = transform.Find("InteractiveAreaCollider").GetComponent<InteractiveAreaController>();
    }

    void Update()
    {
        _isInteractive = _areaController.InArea;
        _player = _areaController.Player;

        if (_isInteractive && Input.GetMouseButtonDown(0))
        {
            if (IsOurObject(_tag))
            {

                if (_typeOfTeleport == TypeOfTeleport.inScene)
                {
                    ToAnoterTeleport(_numberOfTeleport);
                }
                else
                {
                    ToAnotherScene();
                }
            }
        }
    }

    void ToAnoterTeleport(NumberOfTeleport numberOfTeleport)
    {
        StartCoroutine(GameController.singleton.DisableMovement());
        switch (numberOfTeleport)
        {
            case NumberOfTeleport.First:
                _player.transform.position = new Vector3(GameController.singleton.SecondTeleportPos.x, _player.transform.position.y, GameController.singleton.SecondTeleportPos.z + 1f);
                break;
            case NumberOfTeleport.Second:
                _player.transform.position = new Vector3(GameController.singleton.FirstTeleportPos.x, _player.transform.position.y, GameController.singleton.FirstTeleportPos.z + 1f);
                break;
            case NumberOfTeleport.Third:
                _player.transform.position = new Vector3(GameController.singleton.FourthTeleportPos.x, _player.transform.position.y, GameController.singleton.FourthTeleportPos.z + 1f);
                break;
            case NumberOfTeleport.Fourth:
                _player.transform.position = new Vector3(GameController.singleton.ThirdTeleportPos.x, _player.transform.position.y, GameController.singleton.ThirdTeleportPos.z + 1f);
                break;
        }
    }

    void ToAnotherScene()
    {
        DontDestroyOnLoad(_player);
        if (GameController.singleton.IsFirstSceneTeleport)
        {
            StartCoroutine(LoadNextScene("TeleportScene"));
            _player.transform.position = new Vector3(GameController.singleton.SecondSceneTeleportPos.x, _player.transform.position.y, GameController.singleton.SecondSceneTeleportPos.z + 1f);
            GameController.singleton.IsFirstSceneTeleport = false;
        }
        else
        {
            StartCoroutine(LoadNextScene("GameScene"));
            _player.transform.position = new Vector3(GameController.singleton.FirstSceneTeleportPos.x, _player.transform.position.y, GameController.singleton.FirstSceneTeleportPos.z + 1f);
            GameController.singleton.IsFirstSceneTeleport = true;
        }
    }

    IEnumerator LoadNextScene(string sceneName)
    {
        yield return GameController.singleton.DisableMovement();
        SceneManager.LoadScene(sceneName);
    }
}

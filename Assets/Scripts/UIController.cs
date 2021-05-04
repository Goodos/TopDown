using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _currXP;
    [SerializeField] private Text _currHP;
    [SerializeField] private GameObject _gameOverPanel;
    private GameObject _player;
    private Transform _canvas;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _canvas = gameObject.transform;
        GameController.singleton.GameOverAction += ShowGameOverPanel;
    }

    void Update()
    {
        _currHP.text = "HP = " + (_player.GetComponent<Player>().HP < 0 ? 0 : _player.GetComponent<Player>().HP).ToString();
        _currXP.text = "XP = " + _player.GetComponent<Player>().XP.ToString();
    }

    void ShowGameOverPanel()
    {
        Instantiate(_gameOverPanel, _canvas);
    }
}

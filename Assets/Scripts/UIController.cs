using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _currXP;
    [SerializeField] private Text _currHP;
    [SerializeField] private GameObject _gameOverPanel;
    private GameObject _player;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        GameController.singleton.GameOverAction += ShowGameOverPanel;
    }

    void Update()
    {
        _currHP.text = "HP = " +_player.GetComponent<Player>().HP.ToString();
        _currXP.text = "XP = " + _player.GetComponent<Player>().XP.ToString();
    }

    void ShowGameOverPanel()
    {
        Instantiate(_gameOverPanel,transform);
    }
}

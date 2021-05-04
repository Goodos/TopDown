using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForHurtObjectController : InteractiveObject
{
    private string _tag = "ForHurtObject";
    private InteractiveAreaController _areaController;
    private GameObject _player;

    private int _minusHPForClick;

    void Start()
    {
        _areaController = transform.Find("InteractiveAreaCollider").GetComponent<InteractiveAreaController>();
        _minusHPForClick = GameController.singleton.Data.HPForClick;
    }

    void Update()
    {
        _isInteractive = _areaController.InArea;
        _player = _areaController.Player;
        
        if (_isInteractive && Input.GetMouseButtonDown(0))
        {
            if (_player.GetComponent<Player>().HP < 0)
            {
                _isInteractive = false;
            }
            if (IsOurObject(_tag))
            {
                _player.GetComponent<Player>().HP -= _minusHPForClick;
                if (_player.GetComponent<Player>().HP == 0)
                {
                    GameController.singleton.GameOverAction.Invoke();
                }
            }
        }
    }
}

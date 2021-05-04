using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForXPObjectController : InteractiveObject
{
    private string _tag = "ForXPObject";
    private InteractiveAreaController _areaController;
    private GameObject _player;

    private int _plusXPForClick;

    void Start()
    {
        _areaController = transform.Find("InteractiveAreaCollider").GetComponent<InteractiveAreaController>();
        _plusXPForClick = GameController.singleton.Data.XPForClick;
    }

    void Update()
    {
        _isInteractive = _areaController.InArea;
        _player = _areaController.Player;
        if (_isInteractive && Input.GetMouseButtonDown(0))
        {
            if (IsOurObject(_tag))
            {
                _player.GetComponent<MovementController>().XP += _plusXPForClick;
            }
        }
    }
}

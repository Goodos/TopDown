using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForDestroyObjectController : InteractiveObject
{
    private string _tag = "ForDestroyObject";
    private InteractiveAreaController _areaController;
    private int _clickCounter = 0;

    private int _clicksForDestroy;

    void Start()
    {
        _areaController = transform.Find("InteractiveAreaCollider").GetComponent<InteractiveAreaController>();
        _clicksForDestroy = GameController.singleton.Data.ClicksForDestroy - 1;
    }

    void Update()
    {
        _isInteractive = _areaController.InArea;
        if (_isInteractive && Input.GetMouseButtonDown(0))
        {
            if (IsOurObject(_tag))
            {
                if (_clickCounter >= _clicksForDestroy)
                {
                    Destroy(gameObject);
                }
                else
                {
                    _clickCounter++;
                }
            }
        }
    }

}

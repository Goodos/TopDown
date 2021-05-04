using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForDestroyObjectController : InteractiveObject
{
    [SerializeField] private Text _clicksText;
    [SerializeField] private Canvas _canvas;
    private string _tag = "ForDestroyObject";
    private InteractiveAreaController _areaController;
    private int _clickCounter = 0;
    private int _clicksForDestroy;

    void Start()
    {
        _areaController = transform.Find("InteractiveAreaCollider").GetComponent<InteractiveAreaController>();
        _clicksForDestroy = GameController.singleton.Data.ClicksForDestroy - 1;
        _clicksText.text = "Кликни что бы уничтожить  " + (_clicksForDestroy + 1).ToString();
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
                    _clicksText.text = "Кликни что бы уничтожить  " + (_clicksForDestroy - _clickCounter).ToString();
                    _clickCounter++;
                }
            }
        }
    }
    private void LateUpdate()
    {
        _canvas.transform.LookAt(Camera.main.transform);
        _canvas.transform.Rotate(0f, 180f, 0f);
    }
}

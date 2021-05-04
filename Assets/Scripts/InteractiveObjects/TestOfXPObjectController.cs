using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestOfXPObjectController : InteractiveObject
{
    private string _tag = "TestOfXP";
    private InteractiveAreaController _areaController;
    private GameObject _player;
    private int _requiredXP = 50;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private Text _info;
    [SerializeField] private GameObject _visual;
    [SerializeField] private Material _nonInteractiveMat;
    [SerializeField] private Material _normalMat;

    void Start()
    {
        _areaController = transform.Find("InteractiveAreaCollider").GetComponent<InteractiveAreaController>();
        _visual.GetComponent<MeshRenderer>().sharedMaterial = _nonInteractiveMat;
    }

    void Update()
    {
        _isInteractive = _areaController.InArea;
        _player = _areaController.Player;

        if (_isInteractive && Input.GetMouseButtonDown(0))
        {
            if (IsOurObject(_tag))
            {
                if (_player.GetComponent<Player>().XP >= _requiredXP)
                {
                    _info.text = "Достаточно опыта!";
                    _visual.GetComponent<MeshRenderer>().sharedMaterial = _normalMat;
                }
                else
                {
                    _info.text = "Нужно еще " + (_requiredXP - _player.GetComponent<Player>().XP).ToString() + " опыта";
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

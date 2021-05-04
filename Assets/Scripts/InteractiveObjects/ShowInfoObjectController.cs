using UnityEngine;

public class ShowInfoObjectController : InteractiveObject
{
    private string _tag = "ShowInfoObject";
    private InteractiveAreaController _areaController;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _info;

    void Start()
    {
        _areaController = transform.Find("InteractiveAreaCollider").GetComponent<InteractiveAreaController>();
    }

    void Update()
    {
        _isInteractive = _areaController.InArea;
        if (_isInteractive && Input.GetMouseButtonDown(0))
        {
            if (IsOurObject(_tag))
            {
                ShowInfo();
            }
        }
    }

    private void LateUpdate()
    {
        _canvas.transform.LookAt(Camera.main.transform);
        _canvas.transform.Rotate(0f, 180f, 0f);
    }

    void ShowInfo()
    {
        _info.SetActive(true);
    }

    void HideInfo()
    {
        _info.SetActive(false);
    }
}

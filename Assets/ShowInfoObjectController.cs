using UnityEngine;

public class ShowInfoObjectController : InteractiveObject
{
    private bool _isInteractive = false;
    private string _name = "ShowInfoObject";

    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _info;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInteractive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInteractive = false;
        }
    }

    void Start()
    {
    }

    void Update()
    {
        if (_isInteractive && Input.GetMouseButtonDown(0))
        {
            if (IsOurObject())
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

    bool IsOurObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.transform.CompareTag(_name) && hit.collider.GetType() == typeof(BoxCollider))
            {
                Debug.Log("This is a " + _name);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    void ShowInfo()
    {
        _info.SetActive(true);
    }
}

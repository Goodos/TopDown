using UnityEngine;

public class MovementController : Player
{
    private CharacterController _cc;
    private Vector3 _targetPosition;
    private Vector3 _directionVector;
    private Vector3 _targetToMove;
    private bool _canMove = true;
    private float _speed = 10f;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_canMove && Input.GetMouseButtonDown(0))
        {
            ClickToMove();
        }
        if (_canMove)
        {
            Movement(_targetToMove);
        }
    }

    void ClickToMove()
    {
        RaycastHit hit;
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            return;
        if (!hit.transform)
            return;
        if (!hit.transform.CompareTag("Player"))
        {
            _targetToMove = new Vector3(hit.point.x, 0, hit.point.z);
            transform.LookAt(new Vector3(_targetToMove.x, _cc.height / 2f));
        }
    }

    void Movement(Vector3 target)
    {
        _targetPosition = target;
        _directionVector = target - transform.position;
        if (_directionVector.magnitude > 1)
        {
            _directionVector = _directionVector.normalized;
        }
        _cc.Move(_directionVector * Time.deltaTime * _speed);
        Vector3 diff = _targetPosition - transform.position;
        if (diff.magnitude < .1f)
        {
            transform.position = _targetPosition;
        }
    }
}

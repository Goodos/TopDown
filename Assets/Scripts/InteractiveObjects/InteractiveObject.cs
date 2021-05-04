using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    protected LayerMask _ignoreMe =  ~(1 << 8);
    protected bool _isInteractive = false;

    protected bool IsOurObject(string name)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, _ignoreMe))
        {
            if (hit.transform.CompareTag(name))// && hit.collider.GetType() == typeof(BoxCollider)
            {
                Debug.Log("This is a " + name);
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
}

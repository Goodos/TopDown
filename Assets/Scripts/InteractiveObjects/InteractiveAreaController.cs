using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveAreaController : MonoBehaviour
{
    [HideInInspector]
    public bool InArea = false;
    [HideInInspector]
    public GameObject Player;
    [SerializeField] private GameObject _light;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InArea = true;
            Player = other.gameObject;
            _light.SetActive(InArea);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InArea = false;
            _light.SetActive(InArea);
        }
    }

    private void Update()
    {
        
    }
}

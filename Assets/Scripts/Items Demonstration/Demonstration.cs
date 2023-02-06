using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Demonstration : MonoBehaviour
{
    bool _isInDemo;
    public Transform _cameraPosition;
    public TextMeshProUGUI _nameUI;
    public TextMeshProUGUI _descriptionUI;

    private void Update() {
        if(_isInDemo)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50,~LayerMask.NameToLayer("Tool")) && Input.GetMouseButtonDown(1))
            {
                _nameUI.text = hit.transform.GetComponentInChildren<Item>()._name;
                _descriptionUI.text = hit.transform.GetComponentInChildren<Item>()._description;
            }
            if (Physics.Raycast(ray, out hit, 50,~LayerMask.NameToLayer("Tool")) && Input.GetMouseButtonDown(0))
            {
                //Lancer l'animation
            }
        }
    }
    public void SetupDemo() {
            SetupCamera();
            _isInDemo = true;
    }
    public void StopDemo() {
            _isInDemo = false;
    }
    public void SetupCamera() {
            Camera.main.transform.position = _cameraPosition.position;
            Camera.main.transform.rotation = _cameraPosition.rotation;
    }
}
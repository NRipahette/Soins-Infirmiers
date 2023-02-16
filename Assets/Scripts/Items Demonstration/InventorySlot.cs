using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item _item;
    public GameObject _modelInSlot;
    public TextMeshProUGUI _TextInSlot;

    public bool _isSelected;


    public Image _selectedIndicator;
    public Sprite _selectedSprite;
    public Sprite _unselectedSprite;

    private void Awake()
    {
        //SetupSlot();
    }
    public void InstantiateModel()
    {
        // GameObject model = Instantiate(_item._model, transform.TransformPoint(_modelInSlot.transform.position), Quaternion.identity, _modelInSlot.transform);
        // //model.transform.parent = _modelInSlot.transform;
        // model.layer = 5;
        // model.transform.LookAt(model.transform.position + model.transform.parent.forward, model.transform.parent.up);
        //model.GetComponentInChildren<MeshRenderer>().material.color = Color.white;

        //StartCoroutine(InstantateLate());
    }
    public IEnumerator InstantateLate()
    {
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        Material NewMaterial = meshRenderer.material;
        Material oldMaterial = meshRenderer.material;
        Color oldColor = oldMaterial.color;
        NewMaterial.color = Color.black;
        // Set the new material on the GameObject
        meshRenderer.material = NewMaterial;
        yield return new WaitForSeconds(0.5f);

        //oldMaterial.color = oldColor;  

        
    }


    public void ToggleSelection()
    {
        _isSelected = !_isSelected;

        if (_isSelected)
        {
            _selectedIndicator.sprite = _selectedSprite;
        }
        else
        {
            _selectedIndicator.sprite = _unselectedSprite;
        }
    }

    public void SetupSlot()
    {
        //_modelInSlot = _item._model;
        _TextInSlot.text = _item._name;
        InstantiateModel();
        ApplyMaskToChildrens();
    }

    public void UpdateBigObject()
    {
        GameObject.Find("InventoryMenu").GetComponent<Inventory>().UpdateBigObject(_item, _modelInSlot.transform.parent);
    }

    void ApplyMaskToChildrens()
    {
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in renderers)
        {
            //renderer.gameObject.layer = 5;
            foreach (var item in  renderer.materials)
            {
                item.renderQueue = 3002;
            }
            
        }
    }
}

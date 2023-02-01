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

    private void Awake() {
        SetupSlot();
    }
    public void InstantiateModel()
    {
        Instantiate(_item._model,_modelInSlot.transform.position,Quaternion.identity,_modelInSlot.transform).layer = 5;
    }
   

    public void ToggleSelection()
    {
        _isSelected = !_isSelected;

        if(_isSelected)
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
    }
    public void UpdateBigObject()
    {
        GameObject.Find("InventoryMenu").GetComponent<Inventory>().UpdateBigObject(_item);
    }

}

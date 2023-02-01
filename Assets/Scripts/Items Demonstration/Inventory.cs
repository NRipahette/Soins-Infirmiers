using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> _selectedItems;
    public List<InventorySlot> _slots;
    public MenuNaviguation _menuNaviguation;
    public GameObject _content;
    public GameObject _bigObject;
    public Item _selectedItem;


    public void SubmitSelection()
    {
        _selectedItems = new List<Item>();
        foreach (InventorySlot slot in _content.GetComponentsInChildren<InventorySlot>())
        {
            if (slot._isSelected)
            {
                _selectedItems.Add(slot._item);
            }
        }
        if (_selectedItems.Count >= 1)
        {

            _menuNaviguation.OpenCartMenu();
            foreach (Transform transform in GameObject.Find("Tools").transform)
            {
                transform.gameObject.SetActive(true);
            }
            foreach (Item tool in GameObject.Find("Tools").GetComponentsInChildren<Item>())
            {

                if (_selectedItems.Any(item => item._id == tool._id))
                {
                }
                else
                {
                    tool.gameObject.SetActive(false);
                }
            }
        }


    }


    public void UpdateBigObject(Item item)
    {
        foreach (Transform transform in _bigObject.transform)
        {
            Destroy(transform.gameObject);
        }
        _selectedItem = item;
        Instantiate(item._model, _bigObject.transform.position, Quaternion.identity, _bigObject.transform).layer = 5;
    }
}

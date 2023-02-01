using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> _items;
    public List<InventorySlot> _slots;
    public GameObject _inventorySlot;
    public GameObject _content;
    public GameObject _bigObject;
    public Item _selectedItem;



    public void DisplayInventory()
    {
        foreach (var item in _items)
        {
            Instantiate(_inventorySlot,Vector3.zero,Quaternion.identity,_content.transform);
        }
    }
    public void UpdateBigObject(Item item)
    {
        foreach (Transform transform in _bigObject.transform)
        {
            Destroy(transform.gameObject);
        }
        _selectedItem = item;
        Instantiate(item._model,_bigObject.transform.position,Quaternion.identity,_bigObject.transform).layer = 5;
    }
}

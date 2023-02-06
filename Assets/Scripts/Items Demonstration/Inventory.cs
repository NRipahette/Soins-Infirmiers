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
    public Demonstration _demonstration;



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

        _demonstration.SetupDemo();


    }


    public void UpdateBigObject(Item item, Transform parentTransform)
    {
        foreach (Transform transform in _bigObject.transform)
        {
            Destroy(transform.gameObject);
        }
        _selectedItem = item;
        GameObject model = Instantiate(item._model, _bigObject.transform.position, item._model.transform.rotation, _bigObject.transform);
        model.layer = 5;
        model.transform.LookAt(model.transform.position +parentTransform.forward,parentTransform.up);
        //model.transform.localScale =  parentTransform.localScale;
    }
}

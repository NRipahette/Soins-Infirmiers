//===========================================================================//
//                        (c) 2023 Noé Ripahette                           //
//===========================================================================//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNaviguation : MonoBehaviour
{

    bool _isInFlyMode;
    bool _isInDemoMode;
    public GameObject _background;
    public GameObject _mainMenu;
    public GameObject _inventoryMenu;
    public GameObject _cartMenu;
    public Demonstration _demonstration;
    public FreeFlyCamera _flyCamera;
    // Start is called before the first frame update
    void Start()
    {
        _mainMenu.SetActive( true);
        _inventoryMenu.SetActive( false);
        _cartMenu.SetActive( false);
        _background.SetActive( true);
        _flyCamera.Toggle(false);
    }
    

    public void StartFreeLook()
    {
        _mainMenu.SetActive( false);
        _inventoryMenu.SetActive( false);
        _cartMenu.SetActive( false);
        _background.SetActive( false);
        _flyCamera.Toggle(true);
        _isInFlyMode = true;
        _isInDemoMode = false;
        Cursor.visible = false;
        //IF Mouse & keyboard to gain focus
        MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
        MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
    }
    
    public void OpenMainMenu()
    {
        if(!_demonstration._isShowingAnim)
        {
        _flyCamera.Toggle(false);
        _isInFlyMode = false;        
        _isInDemoMode = false;
        _background.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        _mainMenu.SetActive(true);
        _inventoryMenu.SetActive(false);
        _cartMenu.SetActive( false);


        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        }
        
    
    }
    public void OpenSoinsMenu()
    {
        _flyCamera.Toggle(false);
        _isInFlyMode = false;        
        _isInDemoMode = false;
        _background.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        _mainMenu.SetActive(false);
        _inventoryMenu.SetActive(true);
        foreach(InventorySlot slot in _inventoryMenu.GetComponentsInChildren<InventorySlot>())
        {
            slot.SetupSlot();
        }
        _cartMenu.SetActive( false);


        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
    public void OpenCartMenu()
    {
        

        _flyCamera.Toggle(false);
        _isInFlyMode = false;        
        _isInDemoMode = true;
        _background.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;      

        _mainMenu.SetActive(false);
        _inventoryMenu.SetActive(false);
        _cartMenu.SetActive( true);  

        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    private void Update()
    {
        if (!_isInFlyMode && !_isInDemoMode)
        {
         //   return;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                OpenMainMenu();
            }
        }
    }

    public void QuitApplication()
    {
       Application.Quit();
    }
}

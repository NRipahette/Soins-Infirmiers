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
    public GameObject _background;
    public GameObject _mainMenu;
    public GameObject _inventoryMenu;
    public FreeFlyCamera _flyCamera;
    // Start is called before the first frame update
    void Start()
    {
        _mainMenu.SetActive( true);
        _inventoryMenu.SetActive( false);
        _background.SetActive( true);
        _flyCamera.Toggle(false);
    }
    

    public void StartFreeLook()
    {
        _mainMenu.SetActive( false);
        _inventoryMenu.SetActive( false);
        _background.SetActive( false);
        _flyCamera.Toggle(true);
        _isInFlyMode = true;
        Cursor.visible = false;
        //IF Mouse & keyboard to gain focus
        MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
        MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
    }
    
    public void OpenMainMenu()
    {
        _flyCamera.Toggle(false);
        _isInFlyMode = false;
        _background.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        _mainMenu.SetActive(true);
        _inventoryMenu.SetActive(false);

        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
    public void OpenSoinsMenu()
    {
        _flyCamera.Toggle(false);
        _isInFlyMode = false;
        _background.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        _mainMenu.SetActive(false);
        _inventoryMenu.SetActive(true);

        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    private void Update()
    {
        if (!_isInFlyMode)
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

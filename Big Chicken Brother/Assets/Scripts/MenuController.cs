using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private bool Side_Menu_Toggle = false;
    void Update()
    {
      gameObject.transform.Find("Side_Menu").gameObject.SetActive(Side_Menu_Toggle);
      if(Input.GetKeyDown (KeyCode.Escape)){
        Side_Menu_Toggle = !Side_Menu_Toggle;

      }
    }
}

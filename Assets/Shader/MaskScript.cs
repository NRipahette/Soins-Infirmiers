using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
          MeshRenderer[] renderers =   GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.material.renderQueue = 2002;
            }
    }
    


}

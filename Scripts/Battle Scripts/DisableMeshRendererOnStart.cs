using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeshRendererOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer visible = GetComponent<MeshRenderer>();
        visible.enabled = false;
    }


}

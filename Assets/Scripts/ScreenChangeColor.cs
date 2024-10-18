using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenChangecolor : MonoBehaviour
{
    public RawImage rawImageScreen;
    void Start()
    {
        rawImageScreen.color = Color.white;
    }
}

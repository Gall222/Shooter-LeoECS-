using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScreenScript : MonoBehaviour
{
    public virtual void Show(bool state = true)
    {
        gameObject.SetActive(state);
    }
}

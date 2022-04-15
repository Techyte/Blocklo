using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchReporter : MonoBehaviour
{
    public bool isTouched;

    private void OnMouseDown()
    {
        isTouched = true;
    }

    private void OnMouseUp()
    {
        isTouched = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReposition : MonoBehaviour
{
    public List<RectTransform> destinations;
    public List<RectTransform> newObject;

    [ContextMenu("Reposition")]
    public void Reposition()
    {
        for (int i = 0; i < destinations.Count; i++)
        {
            newObject[i].position = destinations[i].position;
            newObject[i].sizeDelta = destinations[i].sizeDelta;
            newObject[i].localScale = destinations[i].localScale;
        }
    }
}

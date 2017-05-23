using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/GameZone/DestroyByBoundary")]
public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        // This assumes, only one version of this interface lies on any given object
        // - Which is true for this game
        ICanExceedBounds temp = other.GetComponent<ICanExceedBounds>();
        temp.OnBoundsExit();
    }
}

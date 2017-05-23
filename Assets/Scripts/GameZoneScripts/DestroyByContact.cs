using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/GameZone/DestroyByContact")]
public class DestroyByContact : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        // This assumes, only one version of this interface lies on any given object
        // - Which is true for this game
        IContactDestroyable temp = other.GetComponent<IContactDestroyable>();
        if(temp != null)
            temp.OnObjectHit(other.gameObject);
    }
}

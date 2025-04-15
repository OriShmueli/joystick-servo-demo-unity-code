using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : MonoBehaviour, IInteractable
{
    [SerializeField] protected Component_SO _component_SO;

    public virtual void OnInteraction()
    {
        
    }

    public virtual void OnSideClick()
    {
        
    }

}

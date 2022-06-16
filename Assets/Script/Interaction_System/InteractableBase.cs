using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class InteractableBase : MonoBehaviour, IInteractable
{
    #region Variable
        [Space,Header("Interactable Setting")]
    
        [Space]
        [SerializeField]private bool holdInteract = true;
        [ShowIf("holdInteract")][SerializeField] private float holdDuration = 1f;
        
        [Space]
        [SerializeField]private bool multipleUse = false;
        [SerializeField]private bool isInteractable = true;

        [SerializeField] private string tooltipMessage = "interact";
    #endregion

    #region Properties
    public float HoldDuration => holdDuration;

        public bool HoldInteract => holdInteract;
        public bool MultipleUse => multipleUse;
        public bool IsInteractable => isInteractable;
        public string TooltipMessage => tooltipMessage;
    #endregion

    #region Method
    public virtual void OnInteract() {
            Debug.Log("INTERACTED: " + gameObject.name);
        }
    #endregion
}

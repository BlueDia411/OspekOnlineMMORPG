using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    #region Variable
        [Space,Header("Data")]
        [SerializeField] private InteractionInputData InteractionInputData = null;
        [SerializeField] private InteractionData InteractionData = null;

        [Space, Header("UI")]
        [SerializeField] private InteractionUIPanel uiPanel;

        [Space,Header("Ray Setting")]
        [SerializeField] private float rayDistance = 0f;
        [SerializeField] private float raySphereRadius = 0f;
        [SerializeField] private LayerMask interactableLayer = ~0;


        #region private
            private Camera m_cam;

            private bool m_interacting;
            private float m_holdTimer = 0f;
        #endregion

    #endregion

    #region build In Method
    private void Awake()
        {
            m_cam = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            CheckForInteractable();
            CheckForInteractableInput();
        }
    #endregion

    #region Custom Method
        void CheckForInteractable() {
        Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
        RaycastHit _hitInfo;

        bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius, out _hitInfo, rayDistance, interactableLayer);

        if (_hitSomething)
        {
            InteractableBase _interactable = _hitInfo.transform.GetComponent<InteractableBase>();

            if (_interactable != null)
            {
                if (InteractionData.IsEmpty())
                {
                    InteractionData.Interactable = _interactable;
                    uiPanel.SetTooltip(_interactable.TooltipMessage);
                }
                else
                {
                    if (!InteractionData.IsSameInteracttable(_interactable))
                    {
                        InteractionData.Interactable = _interactable;
                        uiPanel.SetTooltip(_interactable.TooltipMessage);
                    }
                }
            }
        }
        else
        {
            uiPanel.ResetUI();
            InteractionData.ResetData(); 
        }
        Debug.DrawRay(_ray.origin, _ray.direction * rayDistance, _hitSomething ? Color.green : Color.red);
        }

        void CheckForInteractableInput() {

            if (InteractionData.IsEmpty())
                return;

            if (InteractionInputData.InteractedClicked)
            {
                m_interacting = true;
                m_holdTimer = 0f;
            }

        if (InteractionInputData.InteractedRelease) {
            m_interacting = false;
            m_holdTimer = 0f;
            uiPanel.UpdateProgressBar(0f);
        }

        if (m_interacting)
        {
            if (!InteractionData.Interactable.IsInteractable)
                return;

            if (InteractionData.Interactable.HoldInteract)
            {
                m_holdTimer += Time.deltaTime;

                float heldPercent = m_holdTimer / InteractionData.Interactable.HoldDuration;
                uiPanel.UpdateProgressBar(heldPercent);

                if (heldPercent >= 1f)
                {

                    InteractionData.Interact();
                    m_interacting = false;
                }
            }
            else
            {
                InteractionData.Interact();
                m_interacting = false;
            }
        }
        
        }
    #endregion
}

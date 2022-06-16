using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace VHS
{

public class InputHandler : MonoBehaviour
{
        #region Data
        [BoxGroup("Input Data")]
        public InteractionInputData interactionInputData;
        #endregion

        #region BuiltIn Method
        // Start is called before the first frame update
        void Start()
        {
            interactionInputData.Reset();
        }

        // Update is called once per frame
        void Update()
        {
            GetInteractionInputData();
        }
        #endregion

        #region Custom Method
        void GetInteractionInputData() {
            interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);

            interactionInputData.InteractedRelease = Input.GetKeyUp(KeyCode.E);

        }
        #endregion
    }
}

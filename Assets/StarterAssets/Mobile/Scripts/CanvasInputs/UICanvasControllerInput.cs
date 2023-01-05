using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public StarterAssetsInputs starterAssetsInputs;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            starterAssetsInputs.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            starterAssetsInputs.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            starterAssetsInputs.SprintInput(virtualSprintState);
        }

        public void VirtualPickUpInput(bool virtualPickUpState)
        {
            starterAssetsInputs.pickupInput(virtualPickUpState);
        }
        public void VirtualFlashlightInput(bool virtualPickUpState)
        {
            starterAssetsInputs.flashlightInput(virtualPickUpState);
        }
        public void VirtualBackpackInput(bool virtualPickUpState)
        {
            starterAssetsInputs.backpackInput(virtualPickUpState);
        }


    }

}

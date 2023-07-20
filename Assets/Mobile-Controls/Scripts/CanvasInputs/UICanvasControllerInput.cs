using UnityEngine;

public class UICanvasControllerInput : MonoBehaviour
{

    [Header("Output")]
    public FPSControler inputs;
    public PickUp pickUp;
    public scenemanager scenemanager;

    public void VirtualMoveInput(Vector2 virtualMoveDirection)
    {
        inputs.move = virtualMoveDirection;
    }

    public void VirtualLookInput(Vector2 virtualLookDirection)
    {
        inputs.look = virtualLookDirection;
    }

    public void VirtualPickUpInput(bool virtualPickUpState)
    {
        pickUp.canPickupMobile = virtualPickUpState;
    }
    public void VirtualDropInput(bool virtualDropState)
    {
        pickUp.canDropMobile = virtualDropState;
    }
    public void VirtualRotateRightInput(bool virtualRotateRightState)
    {
        pickUp.canRotateRightMobile = virtualRotateRightState;
    }
    public void VirtualRotateLeftInput(bool virtualRotateLeftState)
    {
        pickUp.canRotateLeftMobile = virtualRotateLeftState;
    }
    public void VirtualPlayInput(bool virtualPlayState)
    {
        scenemanager.startMinigame = virtualPlayState;
    }    
}
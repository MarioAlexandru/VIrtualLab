using UnityEngine;

public class UICanvasControllerInput : MonoBehaviour
{

    [Header("Output")]
    public FPSControler inputs;
    public PickUpMobile pickUp;
    public scenemanager scenemanager;
    public TurnOnDialMobile turnOnDial;
    public NewBehaviourScript1 area;

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
    public void VirtualOpenFlame(bool virtualOpenFlameState)
    {
        turnOnDial.canTwistMobile = virtualOpenFlameState;
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
    public void VirtualPlayStoreInput(bool virtualPlayStoreState)
    {
        scenemanager.startStoreMinigame = virtualPlayStoreState;
    }
    public void VirtualOpenShopInput(bool virtualOpenShopState)
    {
        area.openShopMobile = virtualOpenShopState;
    }
    public void VirtualCloserShopInput(bool virtualCloseShopState)
    {
        area.closeShopMobile = virtualCloseShopState;
    }
    public void VirtualThrowInput(bool virtualThrowState)
    {
        pickUp.canThrowMobile = virtualThrowState;
    }
}
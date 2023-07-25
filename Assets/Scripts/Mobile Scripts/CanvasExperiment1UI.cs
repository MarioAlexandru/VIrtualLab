using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasExperiment1UI : MonoBehaviour
{
    [Header("Output")]
    public FPSControler inputs;
    public PickUpMobileExperiment pickUp;
    public TurnOnDialMobile turnOnDial;
    public TriggerMenuMobile menu;

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
    public void VirtualMenuInput(bool virtualMenuState)
    {
        menu.canOpenMenu = virtualMenuState;
    }
    public void VirtualThrowInput(bool virtualThrowState)
    {
        pickUp.canThrowMobile = virtualThrowState;
    }
}

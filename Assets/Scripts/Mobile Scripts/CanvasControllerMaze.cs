using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControllerMaze : MonoBehaviour
{
    public MazeManagerMobile maze;

    public void VirtualTiltLeftInput(bool virtualTiltLeftState)
    {
        maze.canTiltLeft = virtualTiltLeftState;
    }
    public void VirtualTiltRightInput(bool virtualTiltRightState)
    {
        maze.canTiltRight = virtualTiltRightState;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public struct NetworkInputData : INetworkInput
{
    public Vector2 movementInput;
    public float rotationInput;
    public NetworkBool isJumpPressed;
    public NetworkBool isLeftHolding;
    public NetworkBool isRightHolding;
    public NetworkBool isFrontHolding;
    public NetworkBool isBackHolding;
    public NetworkBool isShiftHolding;
}

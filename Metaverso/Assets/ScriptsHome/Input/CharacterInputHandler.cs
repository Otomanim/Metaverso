using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    Vector2 moveInputVector = Vector2.zero;
    Vector2 viewInputVector = Vector2.zero;
    bool isLeftHolding = false;
    bool isRightHolding = false;
    bool isFrontHolding = false;
    bool isBackHolding = false;
    bool isJumpButtonPressed = false;
    bool isShiftHolding = false;
    bool isInteractKeyPressed = false;

    //Other components
    CharacterMovementHandler characterMovementHandler;
    private void Awake()
    {
        characterMovementHandler = GetComponent<CharacterMovementHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //View input
        viewInputVector.x = Input.GetAxis("Mouse X") * 1.5f;
        viewInputVector.y = (Input.GetAxis("Mouse Y") * 1.5f) * -1; //Invert the mouse look

        characterMovementHandler.SetViewInputVector(viewInputVector);

        //Move input
        moveInputVector.x = Input.GetAxis("Horizontal");
        moveInputVector.y = Input.GetAxis("Vertical");

        if (Input.GetAxisRaw("Vertical") < 0)
            isBackHolding = true;
        else
            isBackHolding = false;

        if (Input.GetAxisRaw("Vertical") > 0)
            isFrontHolding = true;
        else
            isFrontHolding = false;

        if (Input.GetAxisRaw("Horizontal") < 0)
            isLeftHolding = true;
        else
            isLeftHolding = false;

        if (Input.GetAxisRaw("Horizontal") > 0)
            isRightHolding = true;
        else
            isRightHolding = false;


        //Interaction
        if (Input.GetKeyDown(KeyCode.E))
            isInteractKeyPressed = true;

        //Run
        if (Input.GetButton("Fire3"))
            isShiftHolding = true;

        //Jump
        if (Input.GetButtonDown("Jump"))
            isJumpButtonPressed = true;
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        //View data
        networkInputData.rotationInput = viewInputVector.x;

        //Move data
        networkInputData.movementInput = moveInputVector;

        //Shift Data
        networkInputData.isShiftHolding = isShiftHolding;

        //Jump data
        networkInputData.isJumpPressed = isJumpButtonPressed;

        //Move front and back Data
        networkInputData.isFrontHolding = isFrontHolding;
        networkInputData.isBackHolding = isBackHolding;

        //Sides Data
        networkInputData.isRightHolding = isRightHolding;
        networkInputData.isLeftHolding = isLeftHolding;

        //InteractKey data
        networkInputData.isInteractKeyPressed = isInteractKeyPressed;


        //Reset variables now that we have read their states
        isFrontHolding = false;
        isBackHolding = false;
        isJumpButtonPressed = false;
        isShiftHolding = false;
        isLeftHolding = false;
        isRightHolding = false;
        isInteractKeyPressed = false;


        return networkInputData;
    }
}

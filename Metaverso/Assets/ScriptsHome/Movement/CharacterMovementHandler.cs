using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterMovementHandler : NetworkBehaviour
{
    Vector2 viewInput;

    //Rotation
    float cameraRotationX = 0;

    //Other components
    NetworkCharacterControllerPrototypeCustom networkCharacterControllerPrototypeCustom;
    Camera localCamera;

    private void Awake()
    {
        networkCharacterControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
        localCamera = GetComponentInChildren<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        cameraRotationX += viewInput.y * Time.deltaTime * networkCharacterControllerPrototypeCustom.viewUpDownRotationSpeed;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90, 90);

        localCamera.transform.localRotation = Quaternion.Euler(cameraRotationX, 0, 0);
    }

    public override void FixedUpdateNetwork()
    {
        //Get the input from the network
        if (GetInput(out NetworkInputData networkInputData))
        {


            //Rotate the view
            networkCharacterControllerPrototypeCustom.Rotate(networkInputData.rotationInput);

            //Move
            Vector3 moveDirection = transform.forward * networkInputData.movementInput.y + transform.right * networkInputData.movementInput.x;
            moveDirection.Normalize();

            networkCharacterControllerPrototypeCustom.Move(moveDirection);

            if (networkInputData.isFrontHolding)
                networkCharacterControllerPrototypeCustom.AnimationWalk();
            else
                networkCharacterControllerPrototypeCustom.StopAnimationWalk();

            if (networkInputData.isBackHolding)
                networkCharacterControllerPrototypeCustom.AnimationWalkBack();
            else
                networkCharacterControllerPrototypeCustom.StopAnimationWalkBack();

            if (networkInputData.isRightHolding)
                networkCharacterControllerPrototypeCustom.AnimationRight();
            else
                networkCharacterControllerPrototypeCustom.StopAnimationRight();

            if (networkInputData.isLeftHolding)
                networkCharacterControllerPrototypeCustom.AnimationLeft();
            else
                networkCharacterControllerPrototypeCustom.StopAnimationLeft();
            

            //Shift
            if(networkInputData.isShiftHolding)
            {
                networkCharacterControllerPrototypeCustom.AnimationRun();
            }else
                networkCharacterControllerPrototypeCustom.StopAnimationRun();

            //Jump
            if (networkInputData.isJumpPressed)
                networkCharacterControllerPrototypeCustom.Jump();

            

            CheckFallRespawn();


        }
    }

    void CheckFallRespawn()
    {
        if (transform.position.y < -12)
            transform.position = Utils.GetRandomSpawnPoint();
    }
    public void SetViewInputVector(Vector2 viewInput)
    {
        this.viewInput = viewInput;
    }
}

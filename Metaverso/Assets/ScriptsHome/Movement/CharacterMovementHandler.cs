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

    //public bool isInteractive = false;
    public bool isSit = false;
    public int escolheAnimation;
    private NetworkMecanimAnimator animator;
    private void Awake()
    {
        networkCharacterControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
        localCamera = GetComponentInChildren<Camera>();

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<NetworkMecanimAnimator>();
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
            if (!isSit)
            networkCharacterControllerPrototypeCustom.Rotate(networkInputData.rotationInput);

            //Move
            Vector3 moveDirection = transform.forward * networkInputData.movementInput.y + transform.right * networkInputData.movementInput.x;
            moveDirection.Normalize();

            if(!isSit)
            networkCharacterControllerPrototypeCustom.Move(moveDirection);

            if (networkInputData.isFrontHolding)
                animator.Animator.SetBool("Walking", true);
            else
                animator.Animator.SetBool("Walking", false);

            if (networkInputData.isBackHolding)
                animator.Animator.SetBool("WalkBack", true);
            else
                animator.Animator.SetBool("WalkBack", false);

            if (networkInputData.isRightHolding)
                animator.Animator.SetBool("WalkRight", true);
            else
                animator.Animator.SetBool("WalkRight", false);

            if (networkInputData.isLeftHolding)
                animator.Animator.SetBool("WalkLeft", true);
            else
                animator.Animator.SetBool("WalkLeft", false);

            //InteractKey(E)
            if (networkInputData.isInteractKeyPressed && networkCharacterControllerPrototypeCustom.isInteractive && !isSit)
            {
                transform.localPosition = networkCharacterControllerPrototypeCustom.posicao;
                transform.eulerAngles = networkCharacterControllerPrototypeCustom.rotacao;
                EscolheAnimation(networkCharacterControllerPrototypeCustom.escolheAnimation);
                //networkCharacterControllerPrototypeCustom.EscolheAnimation(networkCharacterControllerPrototypeCustom.escolheAnimation);
            }
            else if (networkInputData.isInteractKeyPressed && networkCharacterControllerPrototypeCustom.isInteractive)
            {
                EscolheAnimation(4);
                //networkCharacterControllerPrototypeCustom.EscolheAnimation(4);
            }


            //Shift
            if (networkInputData.isShiftHolding)
            {
                networkCharacterControllerPrototypeCustom.AnimationRun();
            }
            else
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

    public void EscolheAnimation(int animationNumber)
    {
        switch (animationNumber)
        {
            case 1:
                animator.Animator.SetBool("Sitting", true);
                isSit = true;
                animator.Animator.SetBool("SittingPose", true);
                break;
            case 2:
                animator.Animator.SetBool("Sitting", true);
                isSit = true;
                animator.Animator.SetBool("SitCadeiraGamer", true);
                break;
            case 3:
                animator.Animator.SetBool("Sitting", true);
                isSit = true;
                animator.Animator.SetBool("SittingPose2", true);
                break;
            case 4:
                animator.Animator.SetBool("Sitting", false);
                animator.Animator.SetBool("SittingPose", false);
                animator.Animator.SetBool("SitCadeiraGamer", false);
                animator.Animator.SetBool("SittingPose2", false);
                isSit = false;
                break;
        }

    }
}

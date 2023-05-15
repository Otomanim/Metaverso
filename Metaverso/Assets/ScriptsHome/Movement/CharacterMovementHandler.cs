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
    [Networked]
    public bool front { get; set; }
    [Networked]
    public bool back { get; set; }
    [Networked]
    public bool right { get; set; }
    [Networked]
    public bool left { get; set; }
    [Networked]
    public bool shift { get; set; }
    [Networked]
    public bool interact { get; set; }
    public bool isInteractive = false;
    public bool isSit = false;
    public Vector3 rotacao;
    public Vector3 posicao;
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

            if (!isSit) { 
            networkCharacterControllerPrototypeCustom.Move(moveDirection);
            }
            if (networkInputData.isFrontHolding)
                front = true;
            else
                front = false;

            if (networkInputData.isBackHolding)
                back = true;
            else
            back = false;

            if (networkInputData.isRightHolding)
                right = true;
            else
            right = false;
            
            if (networkInputData.isLeftHolding)
                left = true;
                
            else
            left = false;
            
            //Shift
            if (networkInputData.isShiftHolding)
             {
                shift = true;              
             }
               else
             {
                shift = false;
              }

            //InteractKey(E)
            if (networkInputData.isInteractKeyPressed && isInteractive && !isSit)
            {
                networkCharacterControllerPrototypeCustom.transform.position = posicao;
                networkCharacterControllerPrototypeCustom.transform.eulerAngles = rotacao;
                interact = true;
                //EscolheAnimation(escolheAnimation);
            }
            else if (networkInputData.isInteractKeyPressed && isInteractive)
            {
                
                interact = false;
                EscolheAnimation(4);
            }
          
            //Jump
            if (networkInputData.isJumpPressed)
                networkCharacterControllerPrototypeCustom.Jump();

            CheckFallRespawn();
        }
    }

    private void FixedUpdate()
    {
        isInteractive = false;
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
                {
                    animator.Animator.SetBool("Sitting", true);
                    isSit = true;
                    animator.Animator.SetBool("SittingPose", true);
                }
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
                {
                    animator.Animator.SetBool("Sitting", false);
                    animator.Animator.SetBool("SittingPose", false);
                    animator.Animator.SetBool("SitCadeiraGamer", false);
                    animator.Animator.SetBool("SittingPose2", false);
                    isSit = false;
                }
                break;
        }

    }

    public override void Render()
    {
        if(front)
            animator.Animator.SetBool("Walking", true);
        else
            animator.Animator.SetBool("Walking", false);

        if(back)
            animator.Animator.SetBool("WalkBack", true);
        else
            animator.Animator.SetBool("WalkBack", false);

        if(right)
            animator.Animator.SetBool("WalkRight", true);
        else
            animator.Animator.SetBool("WalkRight", false);
        if(left)
            animator.Animator.SetBool("WalkLeft", true);
        else
            animator.Animator.SetBool("WalkLeft", false);
        if(shift)
            animator.Animator.SetBool("Run", true);
        else
            animator.Animator.SetBool("Run", false);

        if (interact)
            EscolheAnimation(escolheAnimation);
        else
            EscolheAnimation(4);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("escada"))
        {
            networkCharacterControllerPrototypeCustom.gravity = -1000.0f;
        }
        if (other.gameObject.CompareTag("cadeiraJardim"))
        {
            isInteractive = true;
            posicao = new Vector3(other.transform.localPosition.x, other.transform.localPosition.y, other.transform.localPosition.z);
            rotacao = new Vector3(other.transform.eulerAngles.x, other.transform.eulerAngles.y, other.transform.eulerAngles.z);
            escolheAnimation = 1;
        }
        if (other.gameObject.CompareTag("cadeiraGamer"))
        {
            isInteractive = true;
            posicao = new Vector3(other.transform.localPosition.x, other.transform.localPosition.y, other.transform.localPosition.z);
            rotacao = new Vector3(other.transform.eulerAngles.x, other.transform.eulerAngles.y, other.transform.eulerAngles.z);
            escolheAnimation = 2;
        }
        if (other.gameObject.CompareTag("Puff"))
        {
            isInteractive = true;
            posicao = new Vector3(other.transform.localPosition.x, other.transform.localPosition.y, other.transform.localPosition.z);
            rotacao = new Vector3(other.transform.eulerAngles.x, other.transform.eulerAngles.y, other.transform.eulerAngles.z);
            escolheAnimation = 3;
        }
    }
    
    

}

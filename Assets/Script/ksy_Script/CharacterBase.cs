using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterBase : MonoBehaviour
{
    [Header("플레이어 데이터")]
    //--------------------Public---------------------------

    public float moveSpeed = 1.0f;      //이동속도
    public float turnSpeed = 1.0f;     //회전속도

    //--------------------private---------------------------
    private Animator anim;
    private Rigidbody rigid;

    [Header("입력 처리용")]
    private PlayerInput inputActions;

    private Vector3 inputDir = Vector3.zero;
    Vector3 V3;

    IEnumerator actionCoroutine;    //공격용 코루틴

    bool isAction = false;


    //----------------------------------일반 함수-------------------------------
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        inputActions = new PlayerInput();
        actionCoroutine = ActionCoroutine();
    }

    private void OnEnable()
    {
        inputActions.CharacterMove.Enable();
        inputActions.CharacterMove.Move.performed += OnMoveInput;
        inputActions.CharacterMove.Move.canceled += OnMoveInput;
        inputActions.CharacterMove.Activity.performed += OnAvtivity;
        inputActions.CharacterMove.Activity.canceled += OnAvtivityStop;
        inputActions.CharacterMove.Interaction_Item.performed += OnGrab;
        inputActions.CharacterMove.Interaction_Item.canceled += OnGrab;

        //Time.timeScale = 0.1f;

    }

    private void OnDisable()
    {
        inputActions.CharacterMove.Move.canceled -= OnMoveInput;
        inputActions.CharacterMove.Move.performed -= OnMoveInput;
        inputActions.CharacterMove.Activity.performed -= OnAvtivity;
        inputActions.CharacterMove.Activity.canceled -= OnAvtivityStop;
        inputActions.CharacterMove.Interaction_Item.performed -= OnGrab;
        inputActions.CharacterMove.Interaction_Item.canceled -= OnGrab;
        inputActions.CharacterMove.Disable();

    }

    private void FixedUpdate()
    {
        Move();
    }

    //----------------------------------인풋용 함수-------------------------------
    //--- 이동용 함수(wsad)---
    private void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector3 dir = context.ReadValue<Vector3>();

        anim.SetInteger("InputMove", (int)dir.x);
        anim.SetInteger("InputMove2", (int)dir.z);
        inputDir = dir;
    }

    void Move()
    {
        float movex = Input.GetAxis("Horizontal");
        float movez = Input.GetAxis("Vertical");
        V3 = new Vector3(0, Input.GetAxis("Mouse X"), 0);

        transform.Rotate(V3 * turnSpeed);
        rigid.MovePosition(transform.TransformDirection(inputDir) + Time.fixedDeltaTime * moveSpeed * inputDir + transform.position);
    }

    //--- 공격용 함수(left click)---

    private void OnAvtivity(InputAction.CallbackContext _obj)
    {
        isAction = true;
        StartCoroutine(ActionCoroutine());
    }

    private void OnAvtivityStop(InputAction.CallbackContext _obj)
    {
        isAction = false;
        StopCoroutine(ActionCoroutine());
    }

    //---공격용 코루틴---
    IEnumerator ActionCoroutine()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("axe");

        while (true)    //누르면 지속적으로 어택 모션 취하기
        {
            if (isAction == true)
            {
                anim.SetTrigger("Attack-trigger");
            }
            yield return new WaitForSeconds(2.5f);
        }

    }

    //----------------------------------그랩용 함수-------------------------------

    private void OnGrab(InputAction.CallbackContext context)
    {
        anim.SetBool("ItemGrab", !context.canceled);
    }

    //----------------------------------장소 상호작용 함수-------------------------------
}

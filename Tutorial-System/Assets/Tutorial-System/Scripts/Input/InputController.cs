using System;
using Tutorial_System.Scripts.EventChannel;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
   [SerializeField] private VoidEventChannel lmbTutorialCheck;
   [SerializeField] private VoidEventChannel eTutorialCheck;
   [SerializeField] private VoidEventChannel cTutorialCheck;
   
   private InputSystem_Actions _inputSystem;
   
   private void Awake()
   {
      _inputSystem = new InputSystem_Actions();
   }

   private void LmbClick(InputAction.CallbackContext ctx)
   {
      lmbTutorialCheck.CallEvent();
   }

   private void EButton(InputAction.CallbackContext ctx)
   {
      eTutorialCheck.CallEvent();
   }
   
   private void CButton(InputAction.CallbackContext ctx)
   {
      cTutorialCheck.CallEvent();
   }

   void OnEnable()
   {
      _inputSystem.Enable();
      _inputSystem.Player.Attack.performed += LmbClick;
      _inputSystem.Player.Jump.performed += EButton;
      _inputSystem.Player.Crouch.performed += CButton;
   }

   void OnDisable()
   {
      _inputSystem.Disable();
      _inputSystem.Player.Attack.performed -= LmbClick;
      _inputSystem.Player.Jump.performed -= EButton;
      _inputSystem.Player.Crouch.performed -= CButton;
   }
}

using System;
using Tutorial_System.Scripts.EventChannel;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
   [SerializeField] private VoidEventChannel tutorialCheckChannel;
   
   private InputSystem_Actions _inputSystem;
   
   private void Awake()
   {
      _inputSystem = new InputSystem_Actions();
   }

   private void LmbClick(InputAction.CallbackContext ctx)
   {
      tutorialCheckChannel.CallEvent();
   }

   void OnEnable()
   {
      _inputSystem.Enable();
      _inputSystem.Player.Attack.performed += LmbClick;
   }

   void OnDisable()
   {
      _inputSystem.Disable();
      _inputSystem.Player.Attack.performed -= LmbClick;
   }
}

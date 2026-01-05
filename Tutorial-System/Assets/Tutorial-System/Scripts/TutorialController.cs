using System;
using System.Collections.Generic;
using Tutorial_System.Scripts;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [Tooltip("The list that contains all tutorial steps")]
    [SerializeField]
    private List<GameObject> tutorialSteps;

    private int _currentStep = 0;

    private ITutorialStep _currentStepLogic;
    
    /// <summary>
    /// Calls exit logic for current step and moves to next step
    /// </summary>
    /// <remarks>
    /// Called by event
    /// </remarks>
    public void AdvanceStep(object sender, EventArgs args)
    {
        if (_currentStep > tutorialSteps.Count)
            return;
        
        //Check current step null, do exit logic 
        _currentStepLogic?.ExitStep();
        
        //Advance to next step
        _currentStep++;
        if (_currentStep > tutorialSteps.Count)
            return;

        //Try to get interface
        if (!tutorialSteps[_currentStep].TryGetComponent(out _currentStepLogic)) return;
        
        //Do entry logic
        _currentStepLogic.EnterStep();
        _currentStepLogic.OnComplete += AdvanceStep;
    }
}

using System;
using DG.Tweening;
using UnityEngine;

namespace Tutorial_System.Scripts
{
    public class SimpleTutorialStep : MonoBehaviour, ITutorialStep
    {
        [Header("Animation Settings")]
        [Tooltip("The speed at which the tutorial window opens")]
        [SerializeField] private float tutorialWindowOpenSpeed;
    
        [Tooltip("The easing function used when opening the tutorial window")]
        [SerializeField] private Ease tutorialWindowOpenEase;
    
        [Tooltip("The speed at which the tutorial window closes")]
        [SerializeField] private float tutorialWindowCloseSpeed;
    
        [Tooltip("The easing function used when closing the tutorial window")]
        [SerializeField] private Ease tutorialWindowCloseEase;
    
        public bool IsComplete => _isComplete;
        
        public EventHandler<EventArgs> OnComplete { get; set; }
        
        private bool _isComplete;
    
        public void EnterStep()
        {
            transform.DOKill();
            transform.DOScaleY(1, tutorialWindowOpenSpeed).SetEase(tutorialWindowOpenEase);
        }

        /// <summary>
        /// Checks if the tutorial step has been complete, completes it if it hasn't
        /// </summary>
        public void CheckComplete()
        {
            if (IsComplete) return;
        
            //If y scale is 0, that means it is minimized and we shouldn't do anything
            if (transform.localScale.y == 0) return;
            
            _isComplete = true;
            OnComplete?.Invoke(this, EventArgs.Empty);
        }

        public void ExitStep()
        {
            transform.DOKill();
            transform.DOScaleY(0, tutorialWindowCloseSpeed).SetEase(tutorialWindowCloseEase);
        }
    }
}

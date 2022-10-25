using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimatorManager : MonoBehaviour
{
    public enum AnimationType
    {
        DEATH,
        IDLE,
        RUN
    }

    public Animator animator;
    public List<AnimatorSetup> animations;

    public void PlayAnimationType(AnimationType type, float currentSpeedFactor = 1f)
    {
        foreach (var anim in animations)
        {
            if (anim.animationType == type)
            {
                animator.SetTrigger(anim.animationTrigger);
                animator.speed = anim.animationSpeed * currentSpeedFactor;
                return;
            }
        }
    }

    [System.Serializable]
    public class AnimatorSetup
    {
        public AnimationType animationType;
        public string animationTrigger;
        public float animationSpeed = 1f;
    }

}

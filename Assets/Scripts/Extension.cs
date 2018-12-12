using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class AnimationNames
    {
        public const string Bark = "Base Layer.Bark";
        public const string Idle = "Base Layer.Idle";
        public const string Jump = "Base Layer.Jump";
        public const string Run = "Base Layer.Run";
        public const string Walk = "Base Layer.Walk";
    }

    public static class AnimationParameters
    {
        public const string Bark = "Bark";
        public const string Bite = "Bite";
        public const string IsRunning = "IsRunning";
        public const string IsWalking = "IsWalking";
        public const string Jump = "Jump";
        
    }

    public static class AxisNames
    {
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
        public const string MouseX = "Mouse X";
        public const string MouseY = "Mouse Y";
    }

    public static class MouseButtonId
    {
        public const int LeftClick = 0;
        public const int RightClick = 1;
    }


    public static class Methods
    {
        
        // Checks if animation is being played
       
        public static bool AnimationBeingPlayed(Animator animator, string animationName)
        {
            return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
        }
    }
}

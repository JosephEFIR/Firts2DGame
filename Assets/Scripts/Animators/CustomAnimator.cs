using Scripts.Enums;
using UnityEngine;

namespace Scripts.Animators
{
    [RequireComponent(typeof(Animator))]
    public class CustomAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Play(EAnimationType type)
        {
            switch (type)
            {
                case EAnimationType.Idle:
                    _animator.SetTrigger("isIdle");
                    break;
                case EAnimationType.Run:
                    _animator.SetTrigger("isRun");
                    break;
                case EAnimationType.Jump:
                    _animator.SetTrigger("isJump");
                    break;
                case EAnimationType.Landing:
                    _animator.SetTrigger("isLanding");
                    break;
                case EAnimationType.Attack:
                    _animator.SetTrigger("isAttack");
                    break;
                case EAnimationType.Die:
                    _animator.SetTrigger("isDeath");
                    break;
                case EAnimationType.GetDamage:
                    _animator.SetTrigger("isGetDamage");
                    break;
            }
        }

        public void SetMoveSpeed(float value)
        {
            _animator.SetFloat("Speed", value);
        }
    }
}
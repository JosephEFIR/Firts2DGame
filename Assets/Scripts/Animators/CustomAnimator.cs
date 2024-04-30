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
                case EAnimationType.Move:
                    _animator.SetTrigger("isMove");
                    break;
                case EAnimationType.Run:
                    _animator.SetTrigger("isRun");
                    break;
                case EAnimationType.Jump:
                    _animator.SetTrigger("isJump");
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

        public void SetRun(bool value)
        {
            _animator.SetBool("isRun", value);   
        }

        public void SetLanding(bool value)
        {
            _animator.SetBool("isLanding" , value);
        }
    }
}
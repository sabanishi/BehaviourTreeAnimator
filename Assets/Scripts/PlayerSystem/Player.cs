using System;
using UnityEngine;

namespace Sabanishi.BehaviourTreeeAnimator.PlayerSystem
{
    [RequireComponent(typeof(PlayerAnimatorController))]
    public class Player : MonoBehaviour
    {
        [SerializeField]private PlayerAnimatorController animatorController;
        [SerializeField] private CapsuleCollider2D collider;
        [SerializeField] private Rigidbody2D rigidbody;
        
        private const float XSpeed = 5.0f;
        private const float JumpPower = 5.0f;

        private void Awake()
        {
            animatorController.Activate();
        }

        private void OnDestroy()
        {
            animatorController.Deactivate();
        }

        private void Update()
        {
            var isGround = CheckIsGround();
            var xSpeed = CalcXSpeed();
            if (isGround && IsJumpKeyDown())
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpPower);
            }
            else
            {
                rigidbody.velocity = new Vector2(xSpeed, rigidbody.velocity.y);
            }

            var ySpeed = MathF.Round(rigidbody.velocity.y,2);
            
            animatorController.SetXVelocity(xSpeed);
            animatorController.SetYVelocity(ySpeed);
            animatorController.SetIsGround(isGround);
            
            //画像の向きを決める
            var size = transform.localScale.y;
            if (xSpeed > 0)
            {
                transform.localScale = new Vector3(-1,1,1) * size;
            }
            else if(xSpeed<0)
            {
                transform.localScale = Vector3.one * size;
            }
        }

        private bool IsJumpKeyDown()
        {
            return Input.GetKeyDown(KeyCode.W);
        }

        /// <summary>
        /// 入力を読み取り、X方向の速度を計算する
        /// </summary>
        /// <returns></returns>
        private float CalcXSpeed()
        {
            if (Input.GetKey(KeyCode.A)) return -XSpeed;
            if (Input.GetKey(KeyCode.D)) return XSpeed;
            return 0;
        }

        /// <summary>
        /// 接地判定を取る
        /// </summary>
        private bool CheckIsGround()
        {
            //自身の左右から下方向にRayを飛ばし、地面タグがついたObjectと衝突したら接地判定を返す
            var size = collider.size*transform.localScale;
            var nowPosition = transform.position;
            var pos = new Vector2(nowPosition.x,nowPosition.y)+collider.offset;
            var groundTag = "Ground";
            
            var left = Physics2D.Raycast(pos + Vector2.left * size.x / 2,
                Vector2.down,size.y/2+0.15f, LayerMask.GetMask(groundTag));
            var right = Physics2D.Raycast(pos + Vector2.right * size.x / 2,
                Vector2.down,size.y/2+0.15f,LayerMask.GetMask(groundTag));
            return left.collider != null || right.collider != null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            var size = collider.size*transform.localScale;
            var nowPosition = transform.position;
            var pos = new Vector2(nowPosition.x,nowPosition.y)+collider.offset;
            Gizmos.DrawRay(pos + Vector2.left * size.x / 2,
                new Vector3(0,-size.y / 2 - 0.15f,0));
            Gizmos.DrawRay(pos + Vector2.right * size.x / 2,
                new Vector3(0,-size.y / 2 - 0.15f,0));
        }
    }
}
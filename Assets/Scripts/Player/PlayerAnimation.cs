using CapRunner.Obstacle;
using EZCameraShake;
using UnityEngine;
using UnityEngine.Events;

namespace CapRunner.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator anim;
        private int PlayerHitTrigger = Animator.StringToHash("Hit");
        [SerializeField] private UnityEvent GameOverEvent;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacles"))
            {               
                if (collision.gameObject.GetComponent<Obstacles>().obstalceType != Utilites.ObstalceType.boxs)
                {
                    CameraShaker.Instance.ShakeOnce(1f, 1f, 0.2f, 0.2f);
                    GetComponent<Animator>().SetTrigger(PlayerHitTrigger);
                }
                
                GetComponent<PlayerDamage>().IsDamage(collision.gameObject.GetComponent<Obstacles>().obstalceType);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {            
            if (collision.gameObject.CompareTag("Obstacles"))
            {
                anim.Play("Walk");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Collecter"))
            {
                Debug.Log("Game Over");
                GameOverEvent.Invoke();
            }
        }
    }
}

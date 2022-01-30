using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CapRunner.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator anim;
        
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacles"))
            {
                anim.Play("Idle");
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {            
            if (collision.gameObject.CompareTag("Obstacles"))
            {
                anim.Play("Walk");
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CapRunner.Player
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private AudioClip jumpClip;
        [SerializeField] private float jumpForce = 12f;
        [SerializeField] private float forwordForce = 0f;
        [SerializeField] private Button jumpButton;

        private Rigidbody2D myRigidbody;
        private bool canJump;

        // Start is called before the first frame update
        void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
            jumpButton.onClick.AddListener(() => Jump());
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log($" normal {myRigidbody.velocity.y} and abs {Mathf.Abs(myRigidbody.velocity.y)}");
            if(Mathf.Abs(myRigidbody.velocity.y)==0)
            {
                canJump = true;
            }            
        }

        private void Jump()
        {
            if (canJump)
            {
                canJump = false;
                
                //Debug.Log(Mathf.RoundToInt(transform.position.x));

                if (Mathf.RoundToInt(transform.position.x)<0)
                {
                    forwordForce = .5f;
                }
                else
                {
                    forwordForce = 0;
                }

                myRigidbody.velocity = new Vector2(forwordForce, jumpForce);
            }
            else
            {
                Debug.Log("<color=red> is not jump </color>");
            }
            
        }
    }
}

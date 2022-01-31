using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CapRunner.Utilites;

namespace CapRunner.Obstacle
{    
    public class Obstacles : MonoBehaviour,IIncreseSpeed
    {
        [SerializeField] private float moveSpeed = -3f;
        [SerializeField] private ObstalceType types;

        public ObstalceType obstalceType { get => types; }

        private Rigidbody2D myRigidBody;

        // Start is called before the first frame update
        void Start()
        {
            myRigidBody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log("trigger enter "+collision.gameObject.tag);

            if (collision.gameObject.CompareTag("Collecter"))
            {
                gameObject.SetActive(false);
            }
        }

        public void IncreseSpeed()
        {
            moveSpeed -= 0.1f;
        }
    }
}

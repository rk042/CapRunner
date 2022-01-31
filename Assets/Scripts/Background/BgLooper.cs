using CapRunner.Obstacle;
using UnityEngine;
using CapRunner.Utilites;

namespace CapRunner.Background
{    
    public class BgLooper : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float increseSpeedValue = 15f;

        private Vector2 offset=Vector2.zero;
        private Material myMaterial;
        private float increseValue=0;
        private ObstacleSpawner os;

        private void Start() 
        {
            myMaterial=GetComponent<MeshRenderer>().material; 
            offset=myMaterial.GetTextureOffset("_MainTex");
            os = FindObjectOfType<ObstacleSpawner>();
        }

        private void Update()
        {
            increseValue += Time.deltaTime;

            if (increseValue>increseSpeedValue)
            {
                increseValue = 0;
                moveSpeed += 0.5f;
                
                foreach (var item in FindObjectsOfType<Obstacles>())
                {
                    item.IncreseSpeed();
                }

                os.IncreseSpeed();
            }

            offset.x+=moveSpeed/10 *Time.deltaTime;
            myMaterial.SetTextureOffset("_MainTex",offset);
        }
    }
}

using UnityEngine;

namespace CapRunner.Background
{    
    public class BgLooper : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private Vector2 offset=Vector2.zero;
        private Material myMaterial;

        private void Start() 
        {
            myMaterial=GetComponent<MeshRenderer>().material; 
            offset=myMaterial.GetTextureOffset("_MainTex");
        }

        private void Update()
        {
            offset.x+=moveSpeed/10 *Time.deltaTime;
            myMaterial.SetTextureOffset("_MainTex",offset);
        }
    }
}

using UnityEngine;

namespace CapRunner.Background
{    
    public class BgScaler : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var height =Camera.main.orthographicSize * 2f;    
            var widht = height *Screen.width/Screen.height;

            if (name=="BackgroundQuad")
            {
                transform.localScale=new Vector3(widht,height,0);
            } 
            
            if (name=="GroundQuad")
            {
                transform.localScale=new Vector3(widht+3f,1f,0);
            } 
            test();
        }    

        private void test()
        {
            test();
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CapRunner.Utilites
{
    public enum ObstalceType
    {
        enemy, spike, spikebox, boxs
    }

    public class UiManager : MonoBehaviour
    {
        [SerializeField] private GameObject GameOverScreen;
        [SerializeField] private Toggle onOff;
        [SerializeField] private GameObject TutorialScreen;

        private void Start()
        {
            SoundManager.instance.StartMusicAccordingToScene();
            if (onOff!=null)
            {
                onOff.isOn = SoundManager.instance.Play;
            }
            
            //if (SoundManager.instance.IsFristTimePlay)
            //{
            //    TutorialScreen.SetActive(true);
            //}
            //else
            //{
            //    btn_skip();
            //}
        }
        public void btn_Play()
        {
            SoundManager.instance.ButtonClick();
            
            if (SoundManager.instance.IsFristTimePlay)
            {
                StartCoroutine(COR_PlayTutorialScreen());
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
        private IEnumerator COR_PlayTutorialScreen()
        {
            TutorialScreen.SetActive(true);
            yield return new WaitForSecondsRealtime(2f);
            TutorialScreen.SetActive(false);
            SceneManager.LoadScene(1);
            SoundManager.instance.IsFristTimePlay = false;
        }

        public void btn_Sound()
        {
            Debug.Log(" == wait for code == ");
            SoundManager.instance.ButtonClick();
        }

        public void OpenGameOverScreen()
        {
            GameOverScreen.SetActive(true);
            SoundManager.instance.GameOver();
            Time.timeScale = 0;
        }

        public void btn_home()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
            SoundManager.instance.ButtonClick();
        }        

        public void ToggelOnOff()
        {
            SoundManager.instance.IsPlay(onOff.isOn);
        }

        public void OpenLinkProfile()
        {
            Application.OpenURL("https://www.linkedin.com/in/ketan-rathod-rk/");
        }

        public void btn_skip()
        {
            TutorialScreen.SetActive(false);
            SoundManager.instance.IsFristTimePlay = false;
        }
    }
}

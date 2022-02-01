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

        private void Start()
        {
            SoundManager.instance.StartMusicAccordingToScene();
            if (onOff!=null)
            {
                onOff.isOn = SoundManager.instance.Play;
            }
        }
        public void btn_Play()
        {
            SceneManager.LoadScene(1);
            SoundManager.instance.ButtonClick();
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CapRunner.Utilites
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        [SerializeField] private AudioSource buttonClick;
        [SerializeField] private AudioSource mainMenuBgMusic;
        [SerializeField] private AudioSource gameBgMusic;
        [SerializeField] private AudioSource playerHit;
        [SerializeField] private AudioSource gameOver;
        [SerializeField] private AudioSource playerJump;

        private bool isFristTimePlay = true;
        private bool isPlay=true;

        public bool Play => isPlay;
        public bool IsFristTimePlay { get => isFristTimePlay; set => isFristTimePlay = value; }
        
        private void Awake()
        {
            if (instance==null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void StartMusicAccordingToScene()
        {
            if (isPlay)
            {
                if (SceneManager.GetActiveScene().name == "Main Menu")
                {
                    mainMenuBgMusic.Play();
                    gameBgMusic.Stop();
                }
                else if (SceneManager.GetActiveScene().name == "Main Game")
                {
                    gameBgMusic.Play();
                    mainMenuBgMusic.Pause();
                }            
            }
        }

        public void StopAllSounds()
        {
            foreach (Transform item in transform)
            {
                if (item.GetComponent<AudioSource>()!=null)
                {
                    item.GetComponent<AudioSource>().Stop();
                }
            }
        }

        public void EnableMusic()
        {
            if (isPlay)
            {
                StartMusicAccordingToScene();
            }
        }

        public void ButtonClick()
        {
            if (isPlay)
            {
                buttonClick.PlayOneShot(buttonClick.clip);
            }
        }

        public void GameOver()
        {
            if (isPlay)
            {
                gameBgMusic.Stop();
                gameOver.Play();
            }
        }

        public void PlayerHit()
        {
            if (isPlay)
            {
                playerHit.PlayOneShot(playerHit.clip);
            }
        }
        public void PlayerJump()
        {
            if (isPlay)
            {
                playerJump.PlayOneShot(playerJump.clip);
            }
        }
        public void IsPlay(bool onOff)
        {
            if (onOff)
            {
                isPlay = true;
                StartMusicAccordingToScene();
            }
            else
            {
                isPlay=false;
                StopAllSounds();
            }
        }
    }
}

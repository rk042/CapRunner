using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CapRunner.Utilites
{
    public enum ObstalceType
    {
        enemy, spike, spikebox, boxs
    }

    public class UiManager : MonoBehaviour
    {
        public void btn_Play()
        {
            SceneManager.LoadScene(1);
        }

        public void btn_Sound()
        {
            Debug.Log(" == wait for code == ");
        }
    }
}

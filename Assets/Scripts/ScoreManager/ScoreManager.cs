using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CapRunner.Score
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;

        private Coroutine StopStartScore;
        public int Score { get; private set; }
        
        // Start is called before the first frame update
        void Start()
        {
            StopStartScore = StartCoroutine(COR_ScorebyTimerLape());
        }        

        private IEnumerator COR_ScorebyTimerLape()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(1f);
                Score++;
                scoreText.text = "Score " + Score;
            }
        }

        public void StopScore()
        {
            if (StopStartScore!=null)
            {
                StopCoroutine(StopStartScore);
            }
        }
    }
}

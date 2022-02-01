using UnityEngine;
using CapRunner.Utilites;
using UnityEngine.UI;
using UnityEngine.Events;

namespace CapRunner.Player
{
    public class PlayerDamage : MonoBehaviour
    {
        [SerializeField] private int playerHealth;
        [SerializeField] private Slider playerHelthSlider;
        [SerializeField] private ParticleSystem psDamage;

        [SerializeField] private UnityEvent GameOver;

        private void Start()
        {
            playerHelthSlider.value = playerHealth;
        }

        public void IsDamage(ObstalceType types)
        {
            switch (types)
            {
                case ObstalceType.enemy:
                    playerHealth -= 10;
                    SoundManager.instance.PlayerHit();
                    psDamage.Play();
                    break;
                case ObstalceType.spike:
                    playerHealth -= 2;
                    SoundManager.instance.PlayerHit();
                    psDamage.Play();
                    break;
                case ObstalceType.spikebox:
                    playerHealth -= 5;
                    SoundManager.instance.PlayerHit();
                    psDamage.Play();
                    break;
                default:
                    break;
            }
            
            playerHelthSlider.value = playerHealth;

            if (playerHealth<=0)
            {
                GameOver.Invoke();
                return;
            }
        }
    }
}

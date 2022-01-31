using UnityEngine;
using CapRunner.Utilites;
using UnityEngine.UI;

namespace CapRunner.Player
{
    public class PlayerDamage : MonoBehaviour
    {
        [SerializeField] private int playerHealth;
        [SerializeField] private Slider playerHelthSlider;

        public void IsDamage(ObstalceType types)
        {
            switch (types)
            {
                case ObstalceType.enemy:
                    playerHealth -= 10;
                    break;
                case ObstalceType.spike:
                    playerHealth -= 2;
                    break;
                case ObstalceType.spikebox:
                    playerHealth -= 5;
                    break;
                default:
                    break;
            }

            playerHelthSlider.value = playerHealth;
        }
    }
}

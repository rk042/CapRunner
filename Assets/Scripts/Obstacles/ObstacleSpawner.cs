using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CapRunner.Obstacles
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] obstacles;
        [SerializeField] private float waitTime;

        private List<GameObject> obstaclesList = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            InitializeObstacles();

            StartCoroutine(SpawnRandomObstacle());
        }    
        
        private void InitializeObstacles()
        {
            int index = 0;
            for (int i = 0; i < obstacles.Length * 3; i++)
            {
                GameObject obj = Instantiate(obstacles[index], GetSpawnPosition(), Quaternion.identity);
                obstaclesList.Add(obj);
                obstaclesList[i].SetActive(false);

                index++;
                if (index == obstacles.Length)
                {
                    index = 0;
                }

            }
        }

        private Vector3 GetSpawnPosition()
        {
            return new Vector3(transform.position.x, transform.position.y, -2);
        }

        private void Shuffle()
        {
            for (int i = 0; i < obstaclesList.Count; i++)
            {
                GameObject temp = obstaclesList[i];
                int random = Random.Range(i, obstaclesList.Count);
                obstaclesList[i] = obstaclesList[random];
                obstaclesList[random] = temp;
            }
        }

        private IEnumerator SpawnRandomObstacle()
        {
            yield return new WaitForSecondsRealtime(Random.Range(1.5f, 4.5f));

            int index = Random.Range(0, obstaclesList.Count);
            
            while (true)
            {
                if (!obstaclesList[index].activeInHierarchy)
                {
                    obstaclesList[index].SetActive(true);
                    obstaclesList[index].transform.position = GetSpawnPosition();
                    break;
                }
                else
                {
                    index = Random.Range(0, obstaclesList.Count);
                }
            }

            StartCoroutine(SpawnRandomObstacle());
        }
    }
}

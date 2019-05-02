using System.Collections;//using quarinten
using UnityEngine.UI; 
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;
    public Wave[] waves; 
    public Transform spawnPoint; 

    public float timeBetweenWaves = 2f;

    public Text waveCountDownText; 
    public float countdown = 2f;

    private int waveIndex = 0;

    void Update()
    {
        //if (EnemiesAlive > 0)
       // {
           // return;
       // }
        if (countdown <= 0f)
        {

            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;//once countdown reaches 0 from 10 it will spawn out a new wave. 
            return;
        }
        countdown -= Time.deltaTime;//time from last from frame
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDownText.text = string.Format("{0:00.00}", countdown);//floor cuts off the decimal places
    }

    IEnumerator SpawnWave ()//lets us pause the code
    {
       
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];//save all index wave
        for (int i = 0; i < wave.count; i++)
        {
            spawnEnemy(wave.enemey);
           // spawnEnemy(wave.enemy1);
            
            yield return new WaitForSeconds(1f/ wave.rate);// makes enemies be separated. 
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("Level won");
            this.enabled = false;
        }



    }
    
    void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}

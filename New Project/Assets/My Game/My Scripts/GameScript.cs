using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

    public Transform level2Enemies;
    private bool level2Complete = true;
    public GameObject level2Rewards;
    public EnemySpawner spawner;
    public int wave = 0;
    public int maxWave = 10;
    public GameObject finalCutscene;
    public AudioSource music;
    public AudioClip battleMusic;
    public int enemyCount;

	// Use this for initialization
	protected void Start () {
        enemyCount = wave * 2;
        level2Rewards.SetActive(false);
        EnemySpawner.activated = false;
        finalCutscene.SetActive(false);
        music.Play();
    }

    public void SpawnWave()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            spawner.Invoke("Spawn", i / 2);
        }
    }

    // Update is called once per frame
    protected void Update() {
        if (level2Enemies.childCount == 0 && level2Complete)
        {
            HUD.Message("ACHIVEMENT: All enemies in level 2 destroyed!");
            level2Rewards.SetActive(true);
            level2Complete = false;
        }

        if (spawner.transform.childCount == 0 && EnemySpawner.activated && !IsInvoking())
        {
            if (wave == maxWave)
            {
                spawner.gameObject.SetActive(false);
                finalCutscene.SetActive(true);
                music.Stop();
                return;
            }

            if (wave == 0)
            {
                music.clip = battleMusic;
                music.Play();
            }
            wave++;
            enemyCount = Random.Range(wave * 1, wave * 2);
            HUD.Message("Wave " + wave + " !");
            Invoke("SpawnWave", 3);
            
        }
    }
}
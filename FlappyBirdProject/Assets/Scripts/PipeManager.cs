using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//TODO : Choose when to init
//TODO : Pipe Pooling
public class PipeManager : MonoBehaviour
{
    public Pipe pipePrefab;
    public List<Pipe> pipesList = new List<Pipe>();

    public float tarvelDistance = 0f;

    public float pipeDistance = 5f;
    public float pipeHeightVariation = 2f;

    public Transform pipeSpawnPosition;
    public Transform pipeDestructPosition;

    private void Start()
    {
        pipesList.Add(SpawnPipe());
    }

    void Update()
    {
        //Move all pipes
        tarvelDistance += Pipe.globalSpeed * Time.deltaTime;
        foreach (Pipe pipe in pipesList)
        {
            pipe.Move(Time.deltaTime);
        }

        //Spawn a new pipe
        if (tarvelDistance >= pipeDistance)
        {
            tarvelDistance = 0;
            pipesList.Add(SpawnPipe());
        }

        for (int i = pipesList.Count - 1; i >= 0; i--)
        {
            Pipe currentPipe = pipesList[i];
            if(currentPipe.transform.position.x < pipeDestructPosition.position.x)
            {
                pipesList.Remove(currentPipe);
                Destroy(currentPipe.gameObject);
            }
        }

    }

    public Pipe SpawnPipe()
    {
        //Créer un nouveau pipe
        Pipe newPipe = Instantiate(pipePrefab, pipeSpawnPosition.position, Quaternion.identity);
        //Offeset height
        newPipe.transform.position += Vector3.up * Random.Range(-pipeHeightVariation, pipeHeightVariation);

        return newPipe;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

static class MyExtensions
{
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot>_slotPrefabs;
    [SerializeField] private List<PuzzlePiece> _piecePrefab;
    [SerializeField] private Transform _slotParent, _pieceParent;
    public GameObject endCanvas;
    public GameObject TimeManager;
    public TimeManager timeManager;
    public int slotsFilled;
    public TextMeshProUGUI scoreText;
    public int score;

    void Start()
    {
        timeManager = TimeManager.GetComponent<TimeManager>();
        Spawn();
    }
    void Spawn()
    {
        //var randomPiece = _piecePrefab.OrderBy(s => Random.value).Take(3).ToList();
        List<int> positions = new List<int>{ 0, 1, 2, 3, 4, 5 };
        positions.Shuffle();
        positions.Shuffle();
        int index = 0;
        while(index < positions.Count)
        {
            if (positions[index] == index)
            {
                positions.Shuffle();
                index = 0;
            }
            else
            {
                index++;
            }
        }
        
        var randomSet = _slotPrefabs.OrderBy(s => UnityEngine.Random.value).Take(6).ToList();
        randomSet.Shuffle();

        for(int i=0;i< randomSet.Count; i++)
        {
            var spawnedSlot = Instantiate(randomSet[i],_slotParent.GetChild(i).position, Quaternion.identity);
            //PuzzlePiece spawnedPiece = null;

            PuzzlePiece spawnedPiece = Instantiate(_piecePrefab[spawnedSlot.tagIndex], _pieceParent.GetChild(positions[i]).position, Quaternion.identity,spawnedSlot.transform);
            
            spawnedPiece.tag = "pieces";
            spawnedPiece.Init(spawnedSlot);
        }
    }

    private void Update()
    {
        if(slotsFilled == 6)
        {
            endCanvas.SetActive(true);
            timeManager.timeEnd = true;
            slotsFilled = 0;
        }
    }
}

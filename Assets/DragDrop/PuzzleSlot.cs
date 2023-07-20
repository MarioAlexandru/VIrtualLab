using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PuzzleSlot : MonoBehaviour
{
    private GameObject puzzleManagerObject;
    private GameObject timeManagerObject;
    private TextMesh MyPrefab;
    private PuzzleManager puzzleManager;
    private TimeManager timeManager;
    public SpriteRenderer Renderer;
    public int tagIndex;

    private void Start()
    {
        MyPrefab = Resources.Load<TextMesh>("FloatingScore");
        puzzleManagerObject = GameObject.Find("PuzzleManager");
        timeManagerObject = GameObject.Find("TimeManager");
        puzzleManager = puzzleManagerObject.GetComponent<PuzzleManager>();
        timeManager = timeManagerObject.GetComponent<TimeManager>();
    }

    public void Placed(Transform pieceTransform)
    {
        int time = (int)timeManager.time;

        TextMesh scoreText = null;
        //TextMesh prefab = MyPrefab.GetComponentInChildren<TextMesh>();
        if(time < 10)
        {
            puzzleManager.score += 50;
            scoreText = Instantiate(MyPrefab,pieceTransform.position, Quaternion.identity);
            scoreText.text = "50";
            scoreText.GetComponent<MeshRenderer>().sortingOrder = 2;
        }
        else if(time > 10 &&  time < 30) 
        {
            puzzleManager.score += 30;
            scoreText = Instantiate(MyPrefab, pieceTransform.position, Quaternion.identity);
            scoreText.text = "30";
            scoreText.GetComponent<MeshRenderer>().sortingOrder = 2;
        }
        else if(time > 30)
        {
            puzzleManager.score += 10;
            scoreText = Instantiate(MyPrefab, pieceTransform.position, Quaternion.identity);
            scoreText.text = "10";
            scoreText.GetComponent<MeshRenderer>().sortingOrder = 2;
        }

        puzzleManager.scoreText.text = "Scor: " + puzzleManager.score.ToString(); 
        puzzleManager.slotsFilled++;  
    }
    
     
}

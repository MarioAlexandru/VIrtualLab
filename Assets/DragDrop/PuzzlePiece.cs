using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    private bool _dragging, _placed; 
    public bool canBePickedUp;
    private Vector2 _offset, originalPosition;
    private PuzzleSlot _slot;
    private GameObject _manager;
    private GameObject _managerT;
    private TextMesh MyPrefab;
    private PuzzleManager _puzzleManager;
    private TimeManager _timeManager;
    private string spriteName;

    public void Init(PuzzleSlot slot)
    {
        
       //_renderer.sprite = slot.Renderer.sprite;
        //spriteName =slot.Renderer.sprite.name;
        _slot = slot;
    }


    void Awake()
    {
        /*if (spriteName == "apa")
        {
            _rendered.sprite=ChangeSprite("");
        }*/
        MyPrefab = Resources.Load<TextMesh>("FloatingScore");
        _manager = GameObject.Find("PuzzleManager");
        _managerT = GameObject.Find("TimeManager");
        _puzzleManager = _manager.GetComponent<PuzzleManager>();
        _timeManager = _managerT.GetComponent<TimeManager>();
        originalPosition = transform.position;
    }

    void Update()

    {

        if (_placed) return;
        if (!_dragging) return;
        if (!canBePickedUp) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;
    }
    void OnMouseDown()
    {
        if(canBePickedUp) _dragging = true;
    }
    void OnMouseUp()
    {
        if(Vector2.Distance(transform.position, _slot.transform.position) < 1 && canBePickedUp)
        {
            transform.position = new Vector3 (_slot.transform.position.x,_slot.transform.position.y - 0.3f, _slot.transform.position.z);
            _slot.Placed(transform);
   
            _placed = true;
            canBePickedUp = false;
        }
        else
        {
            if(canBePickedUp)
            {
                transform.position = originalPosition;
                _dragging = false;

                int time = (int)_timeManager.time;

                TextMesh scoreText = null;
                if (time < 10)
                {
                    _puzzleManager.score -= 30;
                    scoreText = Instantiate(MyPrefab, transform.position, Quaternion.identity);
                    scoreText.text = "-30";
                    scoreText.GetComponent<MeshRenderer>().sortingOrder = 2;
                }
                else if(time > 10 && time<30)
                {
                    _puzzleManager.score -= 10;
                    scoreText = Instantiate(MyPrefab, transform.position, Quaternion.identity);
                    scoreText.text = "-10";
                    scoreText.GetComponent<MeshRenderer>().sortingOrder = 2;
                }
                else if(time > 30)
                {
                    _puzzleManager.score -= 5;
                    scoreText = Instantiate(MyPrefab, transform.position, Quaternion.identity);
                    scoreText.text = "-5";
                    scoreText.GetComponent<MeshRenderer>().sortingOrder = 2;
                }
                _puzzleManager.scoreText.text = "Scor: " + _puzzleManager.score.ToString();
            }
            
        }
        
    }
    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 16f));
    }








}

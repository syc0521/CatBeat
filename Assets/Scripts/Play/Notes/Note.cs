using UnityEngine;

public abstract class Note : MonoBehaviour
{
    public NoteData Data { set; get; }

    public Vector3 startPos, endPos;
    [HideInInspector]
    public float moveTime;
    private void Awake()
    {
        moveTime = NoteController.noteSpeed;
    }
    public virtual void FixedUpdate()
    {
        Move();
    }
    public virtual void Move()
    {
        if (gameObject.transform.position.x > endPos.x)
        {
            var time = Time.timeSinceLevelLoad;
            var endTime = Data.Time + moveTime;
            transform.position = new Vector3(Utils.Lerp(time, Data.Time, endTime, startPos.x, endPos.x),
                transform.position.y);
            
        }
    }
    public abstract void Judge();
    public abstract void noteDestroy();
}

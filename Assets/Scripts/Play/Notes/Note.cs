using System;
using System.Collections;
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
    public virtual void Update()
    {
        Move();
    }
    public virtual void Move()
    {
        if (Time.timeSinceLevelLoad < Data.Time + moveTime)
        {
            var time = Time.timeSinceLevelLoad;
            var endTime = Data.Time + moveTime;
			var fixedEndPos = endPos.x + 0.1f;
			transform.position = new Vector3(Utils.Lerp(time, Data.Time, endTime, startPos.x, fixedEndPos),
                transform.position.y);
        }
        else
        {
			transform.position = endPos;
        }
    }
    public void OnNoteDestroy()
    {
        StartCoroutine(DestroyNote());
        //Invoke(nameof(DestroyNote), 0.02f);
    }
    //private void DestroyNote()
    //{
    //    if (Data.Index < NoteController.noteCount - 1)
    //    {
    //        NoteController.notes[Data.Index + 1].CanJudge = true;
    //    }
    //}
    private IEnumerator DestroyNote()
    {
        yield return new WaitForSeconds(0.02f);
        if (Data.Index < NoteController.noteCount - 1)
        {
            NoteController.notes[Data.Index + 1].CanJudge = true;
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class NoteSpawner : MonoBehaviour
{
    [System.Serializable]
    public class NoteData
    {
        public float time; // 노트 타이밍 (초)
        public int lane;   // 라인 번호 (예: 0~3)
    }

    public GameObject notePrefab;
    public Transform[] lanes;
    public List<NoteData> notePattern;

    private int nextNoteIndex = 0;

    void Update()
    {
        if (nextNoteIndex < notePattern.Count)
        {
            float currentTime = MusicManager.Instance.GetMusicTime();

            if (notePattern[nextNoteIndex].time - currentTime <= 2.0f) // 2초 전에 미리 생성
            {
                SpawnNote(notePattern[nextNoteIndex]);
                nextNoteIndex++;
            }
        }
    }

    void SpawnNote(NoteData data)
    {
        Transform lane = lanes[data.lane];
        Instantiate(notePrefab, lane.position, Quaternion.identity, lane);
    }
}

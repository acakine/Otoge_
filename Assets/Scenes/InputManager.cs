using UnityEngine;
using System.Linq;

public class InputManager : MonoBehaviour
{
    public KeyCode[] laneKeys; // 각 라인에 대응하는 키 (예: A, S, D, F)

    void Update()
    {
        for (int i = 0; i < laneKeys.Length; i++)
        {
            if (Input.GetKeyDown(laneKeys[i]))
            {
                HandleInput(i);
            }
        }
    }

    void HandleInput(int lane)
    {
        float inputTime = MusicManager.Instance.GetMusicTime();

        // 해당 라인에 있는 노트 중 가장 가까운 것 찾기
        Note nearestNote = FindObjectsOfType<Note>()
            .Where(n => Mathf.Abs(n.transform.position.x - lane) < 0.5f)
            .OrderBy(n => Mathf.Abs(n.targetTime - inputTime))
            .FirstOrDefault();

        if (nearestNote != null)
        {
            string result = NoteJudge.Instance.GetJudge(nearestNote.targetTime, inputTime);
            Debug.Log($"판정: {result}");
            Destroy(nearestNote.gameObject);
        }
    }
}

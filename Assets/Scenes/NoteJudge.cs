using UnityEngine;

public class NoteJudge : MonoBehaviour
{
    public static NoteJudge Instance;

    [Header("판정 기준 (ms 단위)")]
    public float perfectRange = 0.05f; // 50ms
    public float goodRange = 0.1f;     // 100ms

    private void Awake()
    {
        Instance = this;
    }

    public string GetJudge(float noteTime, float inputTime)
    {
        float diff = Mathf.Abs(noteTime - inputTime);

        if (diff <= perfectRange) return "Perfect";
        else if (diff <= goodRange) return "Good";
        else return "Miss";
    }
}

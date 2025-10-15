using UnityEngine;

public class Note : MonoBehaviour
{
    public float targetTime; // 도달해야 할 시간
    public float speed = 5f; // 낙하 속도

    private void Update()
    {
        float currentTime = MusicManager.Instance.GetMusicTime();
        float timeDiff = targetTime - currentTime;

        // 남은 시간에 따라 위치를 조정 (예: 아래로 이동)
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 너무 늦으면 Miss 처리
        if (timeDiff < -0.2f)
        {
            Debug.Log("Miss!");
            Destroy(gameObject);
        }
    }
}

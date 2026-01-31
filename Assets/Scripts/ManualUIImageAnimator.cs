using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ManualUIImageAnimator : MonoBehaviour
{
    [Header("Animation")]
    public Sprite[] frames;
    public float frameRate = 12f;
    public bool loop = true;
    public bool playOnStart = true;

    private Image targetImage;
    private int currentFrame = 0;
    private float timer = 0f;
    private bool isPlaying = false;

    private void Awake()
    {
        targetImage = GetComponent<Image>();
    }

    private void Start()
    {
        if (frames.Length == 0)
            return;

        if (playOnStart)
            Play();
        else
            targetImage.sprite = frames[0];
    }

    private void Update()
    {
        if (!isPlaying || frames.Length == 0)
            return;

        timer += Time.deltaTime;

        if (timer >= 1f / frameRate)
        {
            timer = 0f;
            NextFrame();
        }
    }

    void NextFrame()
    {
        currentFrame++;

        if (currentFrame >= frames.Length)
        {
            if (loop)
                currentFrame = 0;
            else
            {
                currentFrame = frames.Length - 1;
                Stop();
                return;
            }
        }

        targetImage.sprite = frames[currentFrame];
    }

    // ===== CONTROLS =====

    public void Play()
    {
        if (frames.Length == 0) return;

        isPlaying = true;
        targetImage.sprite = frames[currentFrame];
    }

    public void Stop()
    {
        isPlaying = false;
    }

    public void ResetAnimation()
    {
        currentFrame = 0;
        timer = 0f;

        if (frames.Length > 0)
            targetImage.sprite = frames[0];
    }

    public void PlayFromStart()
    {
        ResetAnimation();
        Play();
    }
}

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ManualSpriteAnimator : MonoBehaviour
{
    [Header("Animation")]
    public Sprite[] frames;
    public float frameRate = 12f;
    public bool loop = true;
    public bool playOnStart = true;

    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float timer = 0f;
    private bool isPlaying = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (playOnStart)
            Play();
        else if (frames.Length > 0)
            spriteRenderer.sprite = frames[0];
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

        spriteRenderer.sprite = frames[currentFrame];
    }

    public void SetFrame(int index)
    {
        if(index >= frames.Length)
        {
            throw new System.Exception("Index de sprite non existant");
        }

        currentFrame = index;
        spriteRenderer.sprite = frames[currentFrame];
    }

    // ===== CONTROLS =====

    public void Play()
    {
        if (frames.Length == 0) return;

        isPlaying = true;
        spriteRenderer.sprite = frames[currentFrame];
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
            spriteRenderer.sprite = frames[0];
    }

    public void PlayFromStart()
    {
        ResetAnimation();
        Play();
    }
}

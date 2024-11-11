using UnityEngine;

/// <summary>
/// Script qui gère l'ouverture et la fermeture du niveau
/// </summary>
public class AnimationFonduManager : MonoBehaviour
{
    [SerializeField]
    private Animation _start;

    public static AnimationFonduManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _start.Play();
        Time.timeScale = 1.0f;
    }

    public void MakeAnimation(AnimationClip newClip)
    {
        _start.clip = newClip;
        _start.Play();
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("MyTools/Testing Tools")]
[HelpURL("https://docs.unity.com/Manual/Attributes")]
//[RequireComponent(typeof(Rigidbody))]
public class TestingTools : MonoBehaviour
{
    private const int MAX_HEALTH = 100;
    private const float MAX_MANA = 200f;

    [Header("References")]
    [SerializeField] TextMeshPro text;

    [Header("Stats")]

    [Range(0, MAX_HEALTH)]
    [SerializeField] int health;

    [Range(0, MAX_MANA)]
    [SerializeField] float mana;

    [Space(2)]

    [Header("Description")]

    [SerializeField] string playerName;
    
    [Multiline(3)]
    [SerializeField] string shortDescription;
    
    [TextArea(4, 7)]
    [SerializeField] string longDescription;

    [Tooltip("Use long description instead of short description")]
    [SerializeField] bool useLongDescription = false;

    [HideInInspector]
    [SerializeField] bool isAlive = true;
    
    /// <summary>
    /// Permite randomizar los stats del jugador
    /// </summary>
    /// <returns></returns>
    [ContextMenu("Randomize Stats")]
    public void RandomizeStats()
    {
        Debug.Log($"The player is alive: {isAlive}");
        health = Random.Range(0, MAX_HEALTH + 1);
        mana = Random.Range(0, MAX_MANA);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValidate()
    {
        if (text != null)
            text.text = $"{playerName}\nHealth: {health}\nMana: {mana}";
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }

    public void Reset()
    {
        playerName = "";
        health = 0;
        mana = 0;
    }
}

using UnityEngine;

public class Singleton : MonoBehaviour
{

    private static Singleton instance;

    public static Singleton Instance
    {
        get
        {
            if ( instance == null )
            {
                instance = FindAnyObjectByType<Singleton>();

                if (instance == null)
                {
                    GameObject gameobj = new GameObject();
                    instance = gameobj.AddComponent<Singleton>();
                    DontDestroyOnLoad(gameobj);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(gameObject);
            Debug.Log("이미 존재하는 객체 입니다.");
        }
    }
}
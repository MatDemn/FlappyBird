using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    Transform[] backgrounds;
    int backgroundIndex = 0;

    [SerializeField]
    float scrollTime;

    [SerializeField]
    float scrollSpeed;

    [SerializeField]
    Vector3 scrollVector;

    bool _canScroll = false;

    [SerializeField]
    Transform targetPos;

    Vector3 beginPos;
    // Start is called before the first frame update
    void Start()
    {
        beginPos = backgrounds[1].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ScrollBackground()
    {
        while (_canScroll)
        {
            //Direction for scrolling
            scrollVector = (targetPos.position - backgrounds[0].position).normalized;
            foreach(var background in backgrounds)
            {
                background.position += scrollVector * scrollSpeed * Time.deltaTime;
                if( Vector3.Distance(background.position, targetPos.position) < 0.5f)
                {
                    backgrounds[backgroundIndex].position = beginPos;
                    backgroundIndex = (backgroundIndex+1)% backgrounds.Length;
                }
            }
            yield return null;
        }
    }

    public void StartScrolling()
    {
        _canScroll = true;
        StartCoroutine(ScrollBackground());
    }

    public void StopScrolling()
    {
        _canScroll = false;
    }

    public Transform GetCurrentVisibleBackground()
    {
        return backgrounds[backgroundIndex];
    }
}

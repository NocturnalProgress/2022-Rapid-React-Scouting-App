using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSwipe : MonoBehaviour
{

    [SerializeField] GameObject scrollbar;

    [SerializeField] [Range(1f, 1.5f)] float selectedSize = 1.1f;
    [SerializeField] [Range(0.01f, 0.5f)] float animationSpeed = 0.1f;

    [SerializeField] float scrollPosition;
    [SerializeField] float[] position;
    private float distance;
    private float distanceThreshold;
    private Scrollbar scrollbarComponent;
    private Vector3 selectedSizeVerVector3;

    private void Start()
    {
        position = new float[transform.childCount];
        distance = 1f / (position.Length - 1f);
        distanceThreshold = distance / 2;
        selectedSizeVerVector3 = new Vector3(selectedSize, selectedSize);
        scrollbarComponent = scrollbar.GetComponent<Scrollbar>();
        for (var i = 0; i < position.Length; i++)
        {
            position[i] = distance * i;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            scrollPosition = scrollbarComponent.value;
        }
        else
        {
            foreach (var currentSwipePosition in position)
            {
                if (scrollPosition < currentSwipePosition + distanceThreshold && scrollPosition > currentSwipePosition - distanceThreshold)
                {
                    scrollbarComponent.value = Mathf.Lerp(scrollbarComponent.value, currentSwipePosition, animationSpeed);
                }
            }
        }

        for (var i = 0; i < position.Length; i++)
        {
            var selected = transform.GetChild(i);
            if (scrollPosition < position[i] + distanceThreshold && scrollPosition > position[i] - distanceThreshold)
            {
                selected.localScale = Vector3.Lerp(selected.localScale, selectedSizeVerVector3, animationSpeed);
                for (var j = 0; j < position.Length; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    var unselected = transform.GetChild(j);
                    unselected.localScale = Vector3.Lerp(unselected.localScale, Vector3.one, animationSpeed);
                }
            }
        }
    }

    public void GoToSavedData()
    {
        scrollPosition = position[5];
    }

    public void GoToBeforeMatch()
    {
        scrollPosition = position[0];
    }
}
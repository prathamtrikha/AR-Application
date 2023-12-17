using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PrefabCreator : MonoBehaviour
{

    //reference to AR Tracking Image Manager
    [SerializeField] private ARTrackedImageManager _trackedImageManager;

    //List of prefabs to instantiate
    public GameObject[] arPrefabs;

    //Keep record of created prefabs
    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();


    private void Awake()
    {
        //attach event handler when tracked images change
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        // remove the eventHandler
        _trackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    private void OnDisable()
    {
        _trackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    //Event Handler
    private void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //new tracked Image is being detected
        foreach (var trackedImage in eventArgs.added)
        {
            var imageName = trackedImage.referenceImage.name;

            foreach (var curPrefab in arPrefabs)
            {
                if (string.Compare(curPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0
                    && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);

                    _instantiatedPrefabs[imageName] = newPrefab;
                }
            }
        }


        //for updating the tracked Image in the scene
        foreach (var trackedImage in eventArgs.updated)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        //when removing the TrackedObject when goes out of view
        foreach (var trackedImage in eventArgs.removed)
        {
            Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);

            _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
        }
    }
}

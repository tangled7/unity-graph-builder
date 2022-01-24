using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Graph : MonoBehaviour {
	[SerializeField] 
    Transform pointPrefab;
    
    [SerializeField, Range(10, 100)] 
    private int resolution = 10;

    private Transform[] points;

    private void Awake() {
        var step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;

        points = new Transform[resolution];

        for (var i = 0; i < points.Length; i++) {
            var point = points[i] = Instantiate(pointPrefab, transform, false);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
        }
    }

    private void Update()
    {
        float time = Time.time;
        for (var i = 0; i < points.Length; i++) {
            var point = points[i];
            Vector3 position = point.localPosition;
            position.y = FunctionLibrary.Wave(position.x, time);
            point.localPosition = position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmithingManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public Canvas mainCanvas;
    public Image spawnArea;

    public Image bladeBase;
    public Color startingColor;
    private Color targetColor;

    public int targetAmount;
    public int targetsHit = 0;

    public float minDistance;

    private List<Image> targets = new List<Image>();

    public bool isCompleted;

    public float quality = 1;
    public float qualityDecay = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        targetColor = bladeBase.color;
        bladeBase.color = startingColor;

        PointerEvent pointerEvent = bladeBase.gameObject.AddComponent<PointerEvent>();
        pointerEvent.OnClick.AddListener(delegate { OnMiss(); });

        SpawnTargets();
    }

    private void Update()
    {

        // Temporary reset code
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            DeleteTargets();
            quality = 0;
            targetsHit = 0;
            bladeBase.color = startingColor;
            SpawnTargets();
        }

        if (targetsHit >= targetAmount)
            isCompleted = true;
    }

    private void DeleteTargets() 
    {
        foreach (Image target in targets) 
        {
            Destroy(target.gameObject);
        }

        targets.Clear();
    }

    private void SpawnTargets() 
    {
        Rect spawnRect = new Rect(spawnArea.rectTransform.localPosition, spawnArea.rectTransform.sizeDelta);

        for (int i = 0; i < targetAmount; i++) 
        {
            // Instantiate new target frm prefab
            Image newTarget = Instantiate(targetPrefab).GetComponent<Image>();
            newTarget.rectTransform.SetParent(mainCanvas.transform);
            newTarget.transform.localScale = Vector3.one;

            // Generate initial spawn location within blade bounds
            Vector3 spawnPos = new Vector3(Random.Range(spawnRect.x, spawnRect.x+spawnRect.width), Random.Range(spawnRect.y, spawnRect.y + spawnRect.height),0);

            foreach (Image target in targets) 
            {
                // Regenerate spawn location if its too close to another point
                /// Doesn't work very well yet
                while (Vector3.Distance(target.rectTransform.localPosition, spawnPos) < minDistance) 
                {
                    spawnPos = new Vector3(Random.Range(spawnRect.x, spawnRect.x + spawnRect.width), Random.Range(spawnRect.y, spawnRect.y + spawnRect.height),0);
                }
            }

            newTarget.rectTransform.localPosition = spawnPos;

            // Add on click listener
            PointerEvent pointerEvent = newTarget.gameObject.AddComponent<PointerEvent>();
            pointerEvent.OnClick.AddListener(delegate { OnHit(newTarget); });
            targets.Add(newTarget);
        }
    }

    private void OnMiss() 
    {
        quality -= qualityDecay;
        if (quality < 0)
            quality = 0;
    }

    private void OnHit(Image target) 
    {
        // Add target hit count
        targetsHit++;
        targets.Remove(target);
        Destroy(target.gameObject);

        // Change blade color
        float progress = (float)targetsHit / (float)targetAmount;
        Color color = Color.Lerp(startingColor, targetColor, progress);
        color.a = 1;

        bladeBase.color = color;
    }
}

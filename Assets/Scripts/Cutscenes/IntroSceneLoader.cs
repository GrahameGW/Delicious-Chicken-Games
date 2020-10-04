using System.Collections;
using UnityEngine;

public class IntroSceneLoader : MonoBehaviour
{
    public IntroManager yarnManager = default;
    [SerializeField]
    private float waitBeforeInput = 3.0f;
    public float speed = 1.0f;

    [SerializeField] GameObject textToContinue = default;
    [SerializeField] SpriteRenderer truck = default;

    private void Start()
    {
        StartCoroutine(WaitForPan());
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(-1f, 0, 0)) < 0.05f) {
            StartYarn();
            StartCoroutine(HideCar());
        }
    }

    IEnumerator WaitForPan()
    {
        while (Vector3.Distance(transform.position, new Vector3(-2f, 0f, 0f)) > 0.05f ) {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);

            yield return null;
        }
        transform.position = Vector3.zero;
    }

    private void StartYarn()
    {
        yarnManager.gameObject.SetActive(true);
        textToContinue.SetActive(false);
    }


    IEnumerator HideCar()
    {
        for (float ft = 1f; ft >= 0; ft -= Time.deltaTime * speed) {
            truck.material.color = new Color(1f, 1f, 1f, ft);
            yield return null;
        }
        truck.gameObject.SetActive(false);

    }
}


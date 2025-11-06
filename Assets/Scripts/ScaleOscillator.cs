using UnityEngine;

public class ScaleOscillator : MonoBehaviour
{
    public float scalingFactor = 1f;  // Controls the speed of scaling (how much to scale per second)
    public float duration = 0.75f;    // How long to scale in one direction before reversing
    public Timer timer;
    private int scaleSign;            // Direction multiplier: 1 = growing, -1 = shrinking
    
    void Start()
    {
        scaleSign = 1;                // Start by growing the object
        timer = GetComponent<Timer>();
        timer.Duration = duration;    // Set how long each scaling phase lasts
        timer.Run();                  // Start the first scaling phase
    }

    void Update()
    {
        // Calculate how much to scale this frame based on direction, speed, and frame time
        float scaleDelta = scaleSign * scalingFactor * Time.deltaTime;
        
        // Apply uniform scaling to all axes (X, Y, Z change equally)
        transform.localScale += new Vector3(scaleDelta, scaleDelta, scaleDelta);

        // Check if current scaling phase duration has completed
        if (timer.Finished)
        {
            // REVERSE DIRECTION: Flip sign to switch between growing/shrinking
            scaleSign *= -1;

            // Reset timer for the next scaling phase
            timer.ResetTimer();
            timer.Run();
        }
    }
}
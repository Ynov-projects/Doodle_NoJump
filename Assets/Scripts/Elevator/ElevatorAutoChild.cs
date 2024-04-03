using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ElevatorAutoChild : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot mainMusic;
    [SerializeField] private AudioMixerSnapshot elevator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent != transform)
        {
            if (collision.tag == "LegPlayer") collision.transform.parent.parent = transform;
            else if (collision.tag != "Player") collision.transform.parent = transform;
            if (collision.tag == "Player" || collision.tag == "LegPlayer") SwitchMusic(true);
        }
    }

    private void SwitchMusic(bool activation)
    {
        if (activation) elevator.TransitionTo(.5f);
        else mainMusic.TransitionTo(.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent != transform)
        {
            if (collision.tag == "LegPlayer") collision.transform.parent.parent = null;
            else if (collision.tag != "Player") collision.transform.parent = null;
            if (collision.tag == "Player" || collision.tag == "LegPlayer") SwitchMusic(false);
        }
    }
}

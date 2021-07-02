using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterHouse : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _exit;

    public event UnityAction Entered
    {
        add => _entered.AddListener(value);
        remove => _entered.RemoveListener(value);
    }

    public event UnityAction Exit
    {
        add => _exit.AddListener(value);
        remove => _exit.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Thief thief))
        {
            _entered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Thief thief))
        {
            _exit?.Invoke();
        }
    }
}

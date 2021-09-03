namespace Bang.Events;
public abstract class RegistrableEvent
{
    public bool CanBeCancelled
    {
        get;
    }

    public bool IsCancelled
    {
        get; set;
    }
}

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
sealed class RegisterAttribute : Attribute
{
    public RegisterAttribute(Type eventType)
    {
        EventType = eventType;
    }

    public Type EventType
    {
        get; init;
    }
}

/// <summary>
/// The interface, implementing the necessary properties for the controls
/// </summary>

public interface IInput
{
    float Horizontal { get; }

    float Vertical { get; }

    float Boost { get; }

    bool AddForce { get; }

    float RightHorizontal { get; }

    float RightVertical { get; }
}

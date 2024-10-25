namespace Sources.Scripts.Editor.Configs.CameraConfigs
{
    public interface ICameraConfig
    {
        float Sensitivity { get; }
        float MinXRotation { get; }
        float MaxXRotation { get; }
    }
}
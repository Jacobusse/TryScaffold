namespace TryScaffold.Models;

public partial class Track
{
    public string TrackInfo => $"Name:{this.Name}; Composer:{this.Composer}; Sec:{this.Milliseconds / 1000.0}";
}
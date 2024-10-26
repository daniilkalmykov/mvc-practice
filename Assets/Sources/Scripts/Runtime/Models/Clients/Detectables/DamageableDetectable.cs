using System.Runtime.CompilerServices;
using Sources.Scripts.Runtime.Models.Clients.Health;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Sources.Scripts.Runtime.Models.Clients.Detectables
{
    internal sealed class DamageableDetectable : Detectable<IDamageable>
    {
    }
}
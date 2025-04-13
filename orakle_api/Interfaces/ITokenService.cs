using orakle_api.Entities;

namespace orakle_api.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Owner user);
    }
}

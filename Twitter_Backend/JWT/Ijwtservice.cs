using Twitter_Backend.DTO;

namespace Twitter_Backend.JWT
{
    public interface Ijwtservice
    {
        string GenerateToken(LoginDTO model);
    }
}

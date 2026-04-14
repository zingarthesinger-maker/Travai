using travai;
using travai.Airline.DTOs.Chat;

namespace travai.Airline.Services.ChatService
{
    public interface IChatService
    {
        Task<List<ChatMessageDto>> GetChatHistoryAsync(long bookingId, long userId, string role);
        Task<ChatMessageDto> SendMessageAsync(long userId, string role, SendMessageDto dto);
    }
}




using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.UserManager.Commands.AddFavorite
{
    public class AddFavoriteCommand:ICommand<bool>
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
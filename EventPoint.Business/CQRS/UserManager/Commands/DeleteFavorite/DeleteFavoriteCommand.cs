using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.UserManager.Commands.DeleteFavorite
{
    public class DeleteFavoriteCommand:ICommand<bool>
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
﻿using FluentValidation;

namespace EventPoint.Business.CQRS.Events.Queries.GetEventWithParticipants
{
    public class GetEventWithParticipantsQueryValidator : AbstractValidator<GetEventWithParticipantsQuery>
    {
        public GetEventWithParticipantsQueryValidator()
        {
            RuleFor(x => x.EventId).NotEmpty().GreaterThan(0);
        }
    }
}
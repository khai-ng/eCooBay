﻿using Core.IntegrationEvents;

namespace Core.EntityFramework.ServiceDefault
{
    public interface IDomainEvent : IDomainEvent<Ulid> { }
}

using Akka.Persistence;
using Akkatecture.Aggregates;
using Akkatecture.Aggregates.Snapshot;
using Akkatecture.Commands;
using Akkatecture.Core;

namespace Akkatecture.TestFixtures.Aggregates
{
    public interface IFixtureArranger<TAggregate, TIdentity>
        where TAggregate : ReceivePersistentActor, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        IFixtureArranger<TAggregate, TIdentity> For(TIdentity aggregateId);
        IFixtureExecutor<TAggregate, TIdentity> GivenNothing();
        IFixtureExecutor<TAggregate, TIdentity> Given(params IAggregateEvent<TAggregate, TIdentity>[] aggregateEvents);
        IFixtureExecutor<TAggregate, TIdentity> Given(IAggregateSnapshot<TAggregate, TIdentity> aggregateSnapshot, long snapshotSequenceNumber);
        IFixtureExecutor<TAggregate, TIdentity> Given(params ICommand<TAggregate, TIdentity>[] commands);
    }
}
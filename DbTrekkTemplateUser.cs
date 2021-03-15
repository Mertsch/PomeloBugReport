using JetBrains.Annotations;

namespace PomeloPrimaryKeyBug
{
    public sealed class DbTrekkTemplateUser
    {
        //public int Id { get; [UsedImplicitly] private set; }

        public int TrekkTemplateId { get; [UsedImplicitly] private set; }
        [CanBeNull]
        public DbTrekkTemplate TrekkTemplate { get; [UsedImplicitly] private set; }

        public int WorkerId { get; [UsedImplicitly] private set; }
        [CanBeNull]
        public DbWorker Worker { get; [UsedImplicitly] private set; }

        [UsedImplicitly]
        public DbTrekkTemplateUser() { }

        public DbTrekkTemplateUser(int trekkTemplateId, int workerId)
        {
            this.TrekkTemplateId = trekkTemplateId;
            this.WorkerId = workerId;
        }

        public DbTrekkTemplateUser([NotNull] DbTrekkTemplate trekkTemplate, int workerId)
        {
            this.TrekkTemplate = trekkTemplate;
            this.WorkerId = workerId;
        }

        public DbTrekkTemplateUser([NotNull] DbTrekkTemplate trekkTemplate, [NotNull] DbWorker worker)
        {
            this.TrekkTemplate = trekkTemplate;
            this.Worker = worker;
        }

        [NotNull, Pure]
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.TrekkTemplateId} -> {this.WorkerId}";
        }
    }
}
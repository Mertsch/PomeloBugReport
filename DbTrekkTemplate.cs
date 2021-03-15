using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PomeloPrimaryKeyBug
{
    public sealed class DbTrekkTemplate
    {
        public int Id { get; [UsedImplicitly] private set; }

        [CanBeNull, ItemNotNull]
        public ICollection<DbWorker> Users { get; [UsedImplicitly] private set; }

        [UsedImplicitly]
        public DbTrekkTemplate() { }
    }
}
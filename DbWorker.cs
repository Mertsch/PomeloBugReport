using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PomeloPrimaryKeyBug
{
    public sealed class DbWorker
    {
        public int Id { get; [UsedImplicitly] private set; }

        [CanBeNull, ItemNotNull]
        public ICollection<DbTrekkTemplate> Templates { get; [UsedImplicitly] private set; }

        [UsedImplicitly]
        public DbWorker() { }
    }
}
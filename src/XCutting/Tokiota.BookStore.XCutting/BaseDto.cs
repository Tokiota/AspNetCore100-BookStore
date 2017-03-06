using System;

namespace Tokiota.BookStore.XCutting
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        public abstract bool IsValid();
    }
}

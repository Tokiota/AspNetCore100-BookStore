namespace Tokiota.BookStore.Context
{
    using System;
    using XCutting;
    public class Initializer : IInitializer
    {
        private readonly LibraryContext context;

        public Initializer(LibraryContext ctx)
        {
            this.context = ctx;
        }
        public void Execute()
        {
            LibraryContextInitializer.Initialize(this.context);
        }
    }
}

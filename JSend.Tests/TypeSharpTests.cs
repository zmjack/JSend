using TypeSharp;
using Xunit;

namespace Ajax.Tests
{
    public class TypeSharpTests
    {
        [Fact]
        public void TypeSharpTest()
        {
            var typeSharpVersion = typeof(TypeScriptModelBuilder).Assembly.GetName().Version;
            var builder = new TypeScriptModelBuilder();
            builder.CacheType(typeof(JSend<>));

            var code = builder.Compile();
            Assert.Equal($@"/* Generated by TypeSharp v{typeSharpVersion} */" +
@"

declare namespace Ajax {
    interface JSend<TData> {
        status?: string;
        data?: TData;
        exData?: any;
        message?: string;
        code?: string;
    }
}
", code);
        }

    }
}

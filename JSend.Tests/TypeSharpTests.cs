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
            builder.CacheType<JSend>();
            builder.CacheType(typeof(JSuccess<>));
            builder.CacheType(typeof(JFail<>));
            builder.CacheType(typeof(JError<>));
            builder.AddDeclaredType(typeof(JSuccess), "JSuccess<any>");
            builder.AddDeclaredType(typeof(JFail), "JFail<any>");
            builder.AddDeclaredType(typeof(JError), "JError<any>");

            var code = builder.Compile();
            Assert.Equal($@"/* Generated by TypeSharp v{typeSharpVersion} */" +
@"

declare namespace Ajax {
    interface JSend {
        status?: string;
        data?: any;
    }
    interface JSuccess<TData> {
        status?: string;
        data?: TData;
    }
    interface JFail<TData> {
        status?: string;
        data?: TData;
    }
    interface JError<TData> {
        status?: string;
        code?: string;
        message?: string;
        data?: TData;
    }
}
", code);
        }

    }
}

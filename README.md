

# JSend

**JSend** is a specification for a simple, no-frills, **JSON** based format for application-level communication.

Referring: https://github.com/omniti-labs/jsend

<br/>

- Language：[English](https://github.com/zmjack/JSend/blob/master/README.md)  |  [中文](https://github.com/zmjack/JSend/blob/master/README.cn.md)

<br/>

## Why JSend?

There are lots of web services out there providing **JSON** data, and each has its own way of formatting responses. Also, developers writing for JavaScript? front-ends continually re-invent the wheel on communicating data from their servers.

While there are many common patterns for structuring this data, there is no consistency in things like naming or types of responses.

Also, this helps promote happiness and unity between backend developers and frontend designers, as everyone can come to expect a common approach to interacting with one another.

<br/>

## So how does it work?

A basic **JSend**-compliant response is as simple as this:

```js
{
    status : "success",
    data : {
        "post" : { "id" : 1, "title" : "A blog post", "body" : "Some useful content" }
     }
}
```

When setting up a **JSON API**, you'll have all kinds of different types of calls and responses. **JSend** separates responses into some basic types, and defines required and optional keys for each type:

| Type    | Description                                                  | Required Keys   | Optional Keys |
| ------- | ------------------------------------------------------------ | --------------- | ------------- |
| success | All went well, and (usually) some data was returned.         | status, data    |               |
| fail    | There was a problem with the data submitted, or some pre-condition of the API call wasn't satisfied. | status, data    |               |
| error   | An error occurred in processing the request, i.e. an exception was thrown. | status, message | code, data    |

<br/>

## .NET Version of JSend

This version focuses on the implementation of the **.NET platform**.

<br/>

### Usage

1. Install **JSend** library from **NuGet**:

```powershell
dotnet add package JSend
```

<br/>

2. Create the **JSend** instance:

Easy to understand, we provide three simply functions to create instance:

- **JSend.Success**
- **JSend.Fail**
- **JSend.Error**

For example, create an instance of **Success** (**JSuccess**)：

```c#
JSend.Success();                // No data
JSend.Success("OK");            // string data
JSend.Success(new { ... });     // object data
```

instance of **Fail** (**JFail**):

```c#
JSend.Fail();                   // No data
JSend.Fail("Oops");             // string data
JSend.Fail(new { ... });        // object data
```

instance of **Error** (**JError**):

```c#
JSend.Error("Crashed"));                        // No data
JSend.Error("Crashed", "#0"));                  // string data
JSend.Error("Crashed", "#0", new { ... }));     // object data
```

<br/>

3. Return the common type **JSend**:

In general, we don't need to use the common type **JSend** directly. But we might convert the other three types to **JSend**.

For example, Web API need return a **JSend** of **JSuccess**, **JFail** or **JError**:

```c#
public JSend PostNumber(int number)
{
    try
    {
        if (number > 0) return JSend.Success();
        else return JSend.Fail(new { number = "The number must be greater than 0." });
    }
    catch { return JSend.Error("Crashed."); }
}
```

<br/>

4. Front-end handle the response:

```js
axios
    .post('.../PostNumber?number=1')
    .then(response => {
        var jsend = response.data;
        if (jsend.status == 'success') { ... }
    	else if (jsend.status == 'fail') { ... }
        else { ... }
    });
```

<br/>

If you use **TypeScript**, the following declarations are recommended to enhance type checking:

```typescript
/* Generated by TypeSharp v1.3.3.0 */

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
```

These codes are generated by [TypeSharp](https://github.com/zmjack/TypeSharp).

If you also generated other code using [TypeSharp](https://github.com/zmjack/TypeSharp), using the same declaration would make porting a little easier.

See https://github.com/zmjack/JSend/blob/master/JSend.Tests/TypeSharpTests.cs

<br/>

**Best wishes for you !**


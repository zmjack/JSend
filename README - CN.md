# JSend

**JSend** 是基于 JSON 格式简单干净的应用层通信标准。 

文档查阅: https://github.com/omniti-labs/jsend

<br/>

## 为什么使用 JSend？

现在有很多 **WEB** 服务都提供 **JSON** 数据，但他们各有自己特殊的响应格式。那么，开发人员使用 **JavaScript** 编写前端，就需要不断地重新设计数据交互的轮子。

虽然也有很多常见模式来封装这些数据，但是在命名或类型等方面缺乏统一性。

为了让开发人员感到愉悦，**JSend** 为前后端通信提供了统一的桥梁。

<br/>

## 如何工作？

基础 **JSend** 响应：

```js
{
    status : "success",
    data : {
        "post" : { "id" : 1, "title" : "A blog post", "body" : "Some useful content" }
     }
}
```

编写 **JSON API** 时，我们会有几种不同的请求响应。**JSend** 将它们归类为以下类型，并指定了必需键和非可选键：

| 类型    | 描述                                                  | 必需键          | 可选键     |
| ------- | ----------------------------------------------------- | --------------- | ---------- |
| success | 正常执行，（通常）会返回一些数据。                    | status, data    |            |
| fail    | 提交数据有问题，或者 API 调用的某些前置条件没有满足。 | status, data    |            |
| error   | 处理请求时发生错误，即抛出异常                        | status, message | code, data |

<br/>

## JSend 的 .NET 版本

该版本是 **JSend** 在 **.NET** 平台的实现。

<br/>

### 使用方法

1. 从 **NuGet** 安装 **JSend**：

```powershell
dotnet add package JSend
```

<br/>

2. 创建 **JSend** 实例：

为了易于理解，我们提供了三个基础方法来创建实例：

- **JSend.Success**
- **JSend.Fail**
- **JSend.Error**

例如，创建 **Success**（**JSuccess**）实例：

```c#
JSend.Success();				// No data
JSend.Success("OK");			// string data
JSend.Success(new { ... });		// object data
```

**Fail**（**JFail**）实例：

```c#
JSend.Fail();					// No data
JSend.Fail("Oops");				// string data
JSend.Success(new { ... });		// object data
```

**Error**（**JError**）实例：

```c#
JSend.Error("Crashed"));						// No data
JSend.Error("Crashed", "#0"));					// string data
JSend.Error("Crashed", "#0", new { ... }));		// object data
```

<br/>

3. 返回通用类型 **JSend**:

通常我们不需要直接使用 **JSend** 类型，而是从其他三种类型转换到 **JSend**。

例如，WEB API 需要返回三种 **JSend** 子类型的一种，**JSuccess**、**JFail** 或 **JError**：

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

4. 前端处理响应：

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

如果使用 **TypeScript**，建议使用如下声明增强类型检查：

```typescript
declare namespace Ajax {
    interface JSend<TData> {
        status?: string;
        code?: string;
        message?: string;
        data?: TData;
    }
}
```

这段代码是通过 [TypeSharp](https://github.com/zmjack/TypeSharp) 生成的。如果您还使用 [TypeSharp](https://github.com/zmjack/TypeSharp) 生成了其他代码，使用相同声明会减轻一些移植工作量。

文件查看：https://github.com/zmjack/JSend/blob/master/JSend.Tests/JSendTests.cs

<br/>

**Best wishes for you !**


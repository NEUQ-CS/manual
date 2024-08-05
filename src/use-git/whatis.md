# 什么是 Git

你在任何地方都可以找到这样一句话

> Git 是一个分布式版本控制系统，由 Linus Torvalds 于 2005 年创建。Git 是一个免费开源的软件，可以在任何操作系统上运行。

这是正确的，但是作为一个新手来说，这句话可能并不是很容易理解。你不知道什么叫“分布式”，“版本控制系统”又是什么意思。甚至，你连 Git 有什么作用都不知道。

所以，让我们从一个简单的例子开始，来看看 Git 是如何工作的。

## 一个简单的例子

假设我们有一个项目，通常来说，一个项目就是一个文件夹，里面有很多文件。这些文件是项目所需的代码，构建脚本，文档等等一切相关的东西。

现在来看这个[项目](https://github.com/NEUQ-CS/manual/tree/master/src/use-git/MyProject1)，这是一个 C# 项目，你不需要了解 C#，只需要知道这是一个项目就可以了。

现在打开 [Program.cs](https://github.com/NEUQ-CS/manual/tree/master/src/use-git/MyProject1/Program.cs) ，这是一个 C# 项目的入口文件，里面有一个简单的代码：

```csharp
Console.WriteLine($"Sum from 1 to 100 is {SumFrom1ToN(100)}");

int SumFrom1ToN(int n)
{
    int sum = 0;

    for (int i = 1; i <= n; i++)
    {
        sum += i;
    }

    return sum;
}
```

你一看就知道，这是一个计算从 1 加到 100 的和的程序。你很好奇你的前辈为什么跟个弱智一样要手动从 1 加到 100。因为学过小学的都知道使用高斯公式就可以算出来，于是你决定进行修改：

```csharp
Console.WriteLine($"Sum from 1 to 100 is {SumFrom1ToN(100)}");

int SumFrom1ToN(int n)
{
    return n * ((n + 1) / 2);
}
```

然后把代码提交到了项目中。

不久，测试气冲冲地跑过来给了你一巴掌，因为`(n + 1)`是奇数时，结果会出错。现在需要fallback到原来的代码，但是不巧的是，没人记得原来的代码是什么样的了。

这时候，Git 就派上用场了。

Git 的作用是记录项目的历史，你可以在任何时候回到过去，查看项目的历史状态。这就好比是一个时间机器，你可以随时回到过去，查看项目的状态。每个状态被称为一个`commit`。当所有状态都被记录下来，你就可以随时回到任何一个状态。就不会出现像上面的情况了。

有人说，那我直接复制一份项目不就行了吗？实在行我就手动一条一条地改回去。这样不就可以了吗？

先别急，版本控制只是 Git 最基础的一个功能，但是 Git 的功能远远比这强大。最重要的功能是`协同工作`。

`commit`的实质是一个patch，它记录了你对项目的哪些文件删除了哪些行，增加了哪些行。

比如，上文中你提交的代码的commit是这样的：

```patch
diff --git a/Program.cs b/Program.cs
index c677648..1d522bd 100644
--- a/Program.cs
+++ b/Program.cs
@@ -3,12 +3,5 @@ Console.WriteLine($"Sum from 1 to 100 is {SumFrom1ToN(100)}");
 
 int SumFrom1ToN(int n)
 {
-    int sum = 0;
-
-    for (int i = 1; i <= n; i++)
-    {
-        sum += i;
-    }
-
-    return sum;
+    return n * ((n + 1) / 2);
 }
```

在 markdown 渲染下，你应该能清楚的理解我们所做的一切，修改发生在Program.cs，我们删除了 `int sum = 0;` 到 `return sum;` 这段代码，增加了 `return n * ((n + 1) / 2);` 这段代码。虽然还有些东西你看不懂，但是不要紧，我们后面会讲到。

这段patch可以被应用到任何一个拥有相同文件的项目上，而不仅仅是你的项目。当应用patch时，Git 会自动匹配相应的文件和代码行，然后应用patch。

当你的同伴在修改了项目的其他代码，比如在一开始加了一条`Console.WriteLine("Hello, world!")`，但是只要被应用patch的代码没有`冲突`，你的修改就可以被应用到项目上。

这就是 Git 的强大之处，它可以让你和你的同伴协同工作，而不会出现代码丢失。

至于冲突发生的时间，冲突的解决，我们后面会讲到。

接下来应该让你亲手体验一下 Git 的强大之处了，让我们准备安装 Git 吧。
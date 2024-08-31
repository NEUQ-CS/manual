---
title: 2. 基本步骤
type: docs
weight: 3
---

现在，来用 Vim 写个 C 程序吧。

## 打开 Vim

```bash {filename="Terminal"}
vim hello.c
```

## 按下 <kbd>i</kbd> 进入输入模式，输入以下 C 语言代码

```c {filename="hello.c",linenos=table}
#include <stdio.h>

int main() {
    printf("Hello, world!\n");
    return 0;
}
```

## 保存文件并退出

不少人第一次使用 Vim 时，不知道如何退出，于是 Vim 被调侃得称作 **新手遇到的第一个 Linux 病毒** 。

当然，退出再简单不过，你现在要做的就是依次输入 <kbd>:</kbd> <kbd>w</kbd> <kbd>q</kbd> <kbd>Enter</kbd> 。

为了以防某天你被关在 Vim 中，这里给出一些特殊解决方案：

1. 使用 Vim 前忘记加 `sudo` 导致无法保存

| 操作 | 说明 | 推荐指数 | 作用 |
|:-:|:-:|:-:|:-:|
| `:q!` | 强制退出 | 不推荐 | 对文件的修改将被丢弃 |
| `:sav /tmp/xxx` | 保存到新文件 `/tmp/xxx` [^1] | 推荐 | 保留了劳动成果 |

[^1]: 对于 GNU/Linux 文件系统的 `/tmp` 目录，任何用户都可以临时存放自己的文件。

聪明的你已经发现了，先进行 `:sav /tmp/xxx` 再进行 `:q!` 。

## 编译运行

最后，为了庆祝胜利，简简单单跑一下刚才写的程序吧。

```bash {filename="Terminal"}
gcc hello.c -o hello.o
./hello.o
```

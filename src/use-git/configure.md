# 配置 Git及简要的命令行教程

## 配置 Git

首先按照上节课教你的方法打开终端或者 Git Bash。确保你能够从终端访问到git后，把这个窗口放在一边。

我们需要配置一些基本信息，包括：
- 你的名字，一般是真实姓名，使用英文
- 你的邮箱，如果要使用 GitHub，这个邮箱必须和你的 GitHub 账号绑定
- SSH 密钥

让我们先从简单的来，配置你的名字和邮箱。

### 配置名字和邮箱

#### 配置名字
在命令行中输入以下命令：

```bash
git config --global user.name "<你的名字>"
```

姓名一定要用双引号括起来，否则空格后的内容会被忽略。

例子：
```bash
git config --global user.name "Caiyi Shyu"
```

#### 配置邮箱
在命令行中输入以下命令：

```bash
git config --global user.email "<你的邮箱>"
```

例子：
```bash
git config --global user.email "cai1hsu@outlook.com"
```

如果不小心输错了，可以再次输入命令进行更改。配置完成后，可以通过以下命令查看配置是否成功：

```bash
git config --global user.name
git config --global user.email
```

在我的机器上，输出如下：

```bash
caiyi@archlinux ~> git config --global user.name
Caiyi Shyu
caiyi@archlinux ~> git config --global user.email
cai1hsu@outlook.com
```
你的输出应该和你输入的一样。

我们在配置的时候都添加了`--global`选项，这意味着你在这台电脑上的所有仓库都会使用这个名字和邮箱。

在提交记录中，这个名字和邮箱会被记录下来，所以请确保你的名字和邮箱是正确的。

例如，在一个git仓库中，使用`git log`可以查看提交记录，其中有一个字段是`Author`，这个字段就是你的名字和邮箱。

例子：
```ascii
Author: Caiyi Shyu <cai1hsu@outlook.com>
Date:   Wed Jul 31 16:54:32 2024 +0800

    fix click to expand on touch devices

commit 77d64e0c3d593d4b912a6fc8d2f1e16a9e46e9b8
```

### 配置 SSH 密钥

当你访问在远程的仓库时，你需要凭证来证明你具有访问权限。在以前，代码托管平台允许你使用用户名和密码来访问仓库。但是现在，这种方式已经被淘汰了，因为它不够安全。

SSH 使用[非对称加密](https://en.wikipedia.org/wiki/Public-key_cryptography)来保护你的数据。在这种加密方式中，有两个密钥：公钥和私钥。公钥是公开的，任何人都可以看到。私钥是私有的，只有你自己知道。使用一种密钥加密，则必须使用相配对的另一种密钥解密。除此之外，密钥无法被暴力破解，因为它的长度太长了。

SSH 密钥有不同算法，常用的有 RSA 和 ED25519。任选一种即可。

生成 SSH 密钥需要邮箱，请**务必**使用和上面一样的邮箱。

回到终端，输入以下命令：

```bash
ssh-keygen -t <算法> -C "<邮箱>"
```

例子:

1. RAS 算法
```bash
 ssh-keygen -t rsa -b 4096 -C "cai1hsu@outlook.com"
```

2. ED25519 算法
```bash
 ssh-keygen -t ed25519 -C "cai1hsu@outlook.com"
```

**注意！请不要复制我的例子，把例子中的邮箱替换成你的邮箱。** 

输入命令后，直接一路回车，直到你看到和以下内容相似的**完整**的输出：

```bash
Generating public/private ed25519 key pair.
Enter file in which to save the key (/home/codespace/.ssh/id_ed25519): 
Created directory '/home/codespace/.ssh'.
Enter passphrase (empty for no passphrase): 
Enter same passphrase again: 
Your identification has been saved in /home/codespace/.ssh/id_ed25519
Your public key has been saved in /home/codespace/.ssh/id_ed25519.pub
The key fingerprint is:
SHA256:5SUADhuC/DSS66Zrzyj1Jqn6FMiQPv3ZAJUAYgjK940 your_email@example.com
The key's randomart image is:
+--[ED25519 256]--+
|*++.+.o..        |
|B= +.*   .       |
|+.=oo .   o .    |
|+oo.o o  o o     |
|o+.. E .S .      |
| oo.. +          |
|o..o o .         |
|oo= o            |
|B=o=             |
+----[SHA256]-----+
```

看到这个输出，说明你的 SSH 密钥已经生成成功了。请**务必注意**这个页面的输出**不能**分享给任何人。

不过你目前仍然不能通过 SSH 访问远程仓库，因为你的公钥还没有添加到远程仓库。在后面讲解GitHub工作流的章节中，我们会讲解如何添加公钥到远程仓库。

接下来，我们来学习一下命令行的基本操作。

# 认识命令行

请认真对比命令行的内容和我对内容含义的解释，确保你理解命令行界面的含义。
以下是三种常见的命令行界面，分别是：

1. Git Bash on Windows
```bash
Caiyi Shyu@archlinux MINGW64 ~
$ git --version
```
2. Bash on Unix
```bash
[caiyi@archlinux ~]$ git --version
```
3. Fish on Unix
```bash
caiyi@archlinux ~> git --version
```

它们都含有以下几个部分：
1. `Caiyi Shyu@archlinux` 或者 `caiyi@archlinux`
2. `~`
3. `$` 或者 Fish 中的 `>`
4. `git --version`

第一个部分是用户名和主机名，格式为`<用户名>@<主机名>`。

#### 用户名和主机名
在上面的例子中，用户名是`Caiyi Shyu`或者`caiyi`，主机名是`archlinux`。主机名是你的电脑的名字，在你操作系统的设置中可以找到并进行更改。

#### 工作目录
第二个部分是工作目录，格式为`<工作目录>`。在上面的例子中，工作目录是`~`。`~`表示用户的home目录，也就是你的用户目录。在 Windows 中，用户的家目录一般是`C:\Users\<用户名>`。在 Unix 中，用户的家目录一般是`/home/<用户名>`。

你也可以在终端中输入`pwd`命令来查看当前工作目录。
以下是在 Windows 和 Unix 中的输出：

1. Git Bash on Windows
```
/c/Users/Caiyi Shyu/
```
看起来和 Windows 下常见的路径有些不一样。这是因为 Git Bash 使用 Unix 风格的路径。上面的路径等价于`C:\Users\Caiyi Shyu\`。注意，在Git Bash中，只能使用Unix风格的路径，并且路径分隔符是`/`而不是`\`。

2. Bash or Fish on Unix
```
/home/caiyi
```

这是完整目录，当前用户的`home`就等价于`~`

当我进入当前目录下的`Desktop`目录时，工作目录会变成`~/Desktop`。

就像下面一样：
1. Git Bash on Windows
```bash
Caiyi Shyu@archlinux MINGW64 ~/Desktop
$ 
```
2. Bash on Unix
```bash
[caiyi@archlinux ~/Desktop]$ 
```
3. Fish on Unix
```bash
caiyi@archlinux ~/Desktop> 
```

现在输入`pwd`命令，你会看到输出是`/home/caiyi/Desktop`(Linux和macOS)或者`/c/Users/Caiyi Shyu/Desktop`(Windows)。

**需要说明的是，shell中的工作目录通常为了显示简洁，可能会省略一部分内容。如果你不清楚当前的工作目录，请随时`pwd`命令来查看。**

#### 提示符

第三个部分是提示符，格式为`<提示符>`。在上面的例子中，提示符是`$`或者`>`。提示符告诉你终端已经准备好接受你的输入了。

#### 命令

第四个部分是命令，格式为`<命令>`。在上面的例子中，命令是`git --version`。这个命令告诉终端你想要执行`git`这个程序，并且传递了一个参数`--version`给这个程序。

命令是你和shell交互的方式。当你输入完命令后，按下回车键，shell会**解释**[^1]并执行这个命令。

[^1]: 解释是指shell会根据你输入的命令，找到对应的程序，并且传递参数给这个程序。程序会根据参数执行相应的操作。

命令分为两种：内建命令和外部命令。内建命令是shell自带的命令，比如`cd`，`pwd`，`exit`等。外部命令是你安装的程序，比如`git`，`ls`，`cat`等。

Shell 在寻找命令时，会先在内建命令中查找，如果找不到，就会在外部命令中查找。所以，当你尝试执行一个不存在的命令时，shell会提示你`command not found`，就像下面这样：

```bash
[caiyi@archlinux Desktop]$ firetruck you
bash: firetruck: command not found
```

需要说明的是，只有第一个单词是命令，比如上面的`firetruck`和`git`，shell 会去寻找一个叫`firetruck`或者`git`的程序。后面的一切都是参数，shell 会把这些参数传递给这个程序。

例如，在执行`git --version`时，`--version`就是参数。程序根据不同的参数执行不同的操作。

还记得main函数的完整形式？通过argv向量，程序就可以访问到这些参数。

```c
// 省略了 envp 参数，避免让新手头大
int main(int argc, char *argv[]) {
    // argc 是参数的数量
    // argv 是参数的数组
}
```

## 认识路径

以这个路径为例：`/home/caiyi/Desktop`。

路径表示文件系统中的位置，既可以是文件夹，也可以是文件。

路径分为绝对路径和相对路径。在Unix风格的路径中，判断一个路径是绝对路径还是相对路径很简单：如果路径以`/`开头，那么这个路径就是绝对路径，否则就是相对路径。

绝对路径是从**根目录**开始的路径，相对路径是相对于当前工作目录的路径。

看到一个路径，请你的大脑将这个路径按'/'分割成一个数组：`['home', 'caiyi', 'Desktop']`。

除最后一个元素外，每个元素都是一个文件夹。最后一个元素既可以是文件夹也可以是文件。但是如果最后一个元素后面还跟了一个`/`，那么这个元素就是一个文件夹。

上面的例子中，由于是一个绝对路径，所以它的含义是
根目录下的`home`文件夹下的`caiyi`文件夹下的`Desktop`文件夹（或文件夹）。

下面来看一个相对路径的例子：`repos/manual/`

这个路径是相对路径，因为它不是以`/`开头的。这个路径的含义是**当前工作目录**下的`repos`文件夹下的`manual`文件夹[^2]。

[^2]: 前面说了，如果最后一个元素后面还跟了一个`/`，那么这个元素就是一个文件夹。

### 特殊的路径

前面介绍了`/`和`~`这两个特殊的路径。它们分别表示根目录和用户的家目录。

`/`是根目录，是文件系统的最顶层。在 Unix 系统中，所有的文件和文件夹都是从根目录开始的。

`~`是用户的家目录，是用户的默认工作目录。在 Unix 系统中，用户的家目录一般是`/home/<用户名>`。

下面再介绍两个特殊的路径：`.`和`..`。

`.`表示当前工作目录，是一个相对路径。例如，`./repos`表示当前工作目录下的`repos`文件夹。它就等价于`repos`。

`..`表示上一级目录，是一个相对路径。例如，`../repos`表示当前工作目录的上一级目录下的`repos`文件夹。

## 基本命令

从现在开始，你就要像一个程序员一样使用命令行了。在这一节中，我们会学习一些基本的命令。

命令需要工作环境，例如，我想查看文件夹的内容，我就需要进入这个文件夹。`进入文件夹` 意味着将工作目录改变到这个文件夹。
<!-- TODO  -->


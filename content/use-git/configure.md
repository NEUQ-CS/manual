---
title: 配置 Git 命令行
type: docs
weight: 3
---

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

### 补充：配置编辑器

如果上一讲中你不是在windows平台下手动安装的git，默认编辑器应该是vim。对于大多数新手来说，vim是一个很难上手的编辑器。因此，我们可以将默认编辑器更改为其他编辑器。

#### 更改为VSCode

在命令行中输入以下命令：

```bash
git config --global core.editor "code --wait"
```

这个命令会将默认编辑器更改为VSCode。`--wait`选项是告诉git等待编辑器关闭后再继续执行。

如果你没有安装VSCode，也没有其他合适的编辑器，可以使用`nano`。`nano`是一个简单的命令行编辑器，使用起来比vim简单。并且，使用nano的方式都写在了屏幕下方，你不需要查看教程就能使用。

#### 更改为nano

在命令行中输入以下命令：

```bash
git config --global core.editor "nano"
```

接下来，我们来学习一下命令行的基本操作。

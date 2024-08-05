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

一般来说，你使用的命令只有两类：
1. 更改工作目录的命令
2. 执行程序或操作

### 更改工作目录的命令

更改工作目录的一般使用`cd`命令。`cd`是`change directory`的缩写。

`cd` 后既可以接绝对路径，也可以接相对路径。

使用绝对路径：
```bash
cd /home/caiyi/Desktop
```

现在你的工作目录就变成了`/home/caiyi/Desktop`。输入pwd命令，你会看到输出是`/home/caiyi/Desktop`。同时在提示符附近也可以看到当前工作目录。

再使用相对路径：
```bash
cd repos/manual
```

现在你的工作目录就变成了`/home/caiyi/Desktop/repos/manual`。输入pwd命令，你会看到输出是`/home/caiyi/Desktop/repos/manual`。

通常来说，使用相对路径更方便，因为你不需要记住绝对路径。要进入当前工作目录下的一个文件夹，只需要输入`cd 文件夹名`即可。

现在来看看`..`和`.`的用法。

```bash
cd ..
```

输入这个命令后，你的工作目录就变成了原来工作目录的上一级目录。输入`pwd`命令，你会看到输出是`/home/caiyi/Desktop/repos`。

```bash
cd .
```

输入这个命令后，你的工作目录不会发生变化。因为`.`表示当前工作目录。虽然`.`在现在看起来好像没什么用，但是在某些情况下，`.`是非常有用的。后面我们会提到。

### 执行程序或操作

在命令行中，你可以执行程序或者操作。这些程序或操作可以是内建的，也可以是外部的。

#### 内建命令

##### `pwd`

`pwd`是`print working directory`的缩写。这个命令会输出当前工作目录的绝对路径。

样例输出：
```bash
pwd
```

输出的内容是`/home/caiyi/`。

##### `ls`

`ls`是`list`的缩写。这个命令会列出当前工作目录下的所有文件和文件夹。

样例输出：
```bash
LICENSE  book/  book.toml  src/
```
这是当前本仓库的根目录的输出。你可以看到有四个文件和文件夹。文件夹都以`/`结尾，其他的都是文件。

`ls`命令还有一些选项，常用的有`-l`和`-a`。

`-l`选项会输出更详细的信息，包括文件的权限，所有者，大小，修改时间等。

例如：
```bash
caiyi@archlinux ~/r/manual (use-git)> ls -l
total 16
-rw-r--r-- 1 caiyi caiyi 1064 Aug  5 14:57 LICENSE
drwxr-xr-x 7 caiyi caiyi 4096 Aug  5 19:03 book/
-rw-r--r-- 1 caiyi caiyi  148 Aug  5 15:29 book.toml
drwxr-xr-x 4 caiyi caiyi 4096 Aug  5 18:40 src/
```

`-a`选项会输出所有的文件和文件夹，包括隐藏的文件和文件夹。隐藏的文件和文件夹以`.`开头。
```bash
caiyi@archlinux ~/r/manual (use-git)> ls -a
./  ../  .git/  .github/  .gitignore  LICENSE  book/  book.toml  src/
```

更多的用法请上网查询。

##### `rm`

`rm`是`remove`的缩写。这个命令会删除文件或者文件夹。

###### 删除文件

直接输入`rm`，然后将文件路径作为参数传递给`rm`。

例如
```bash
rm LICENSE
rm ./LICENSE
rm ../LICENSE
```

###### 删除文件夹

如果一个文件夹不为空，你不能直接删除它。
但是有一个简单的方法可以删除一个文件夹及其所有内容，就是使用`-r`选项。`r`是`recursive`的缩写，表示递归。

```bash
rm -r book/
```

这个命令会删除`book`文件夹及其所有内容。

网上有很多人开玩笑的让新手输入`sudo rm -rf /`这个命令，这是**相当危险的**。它会递归删除根目录下的所有文件和文件夹。包括boot分区和所有数据资料。所以，**请不要输入这个命令**。

同时，在删除当前文件夹下所有文件时，有些人喜欢用`rm -rf ./`，建议不要使用这种方法，而是输入完整的文件夹名字，因为它和上面的命令相似，如果你输入错误，就会发生灾难性的后果。

###### 删除多个文件

你可以一次删除多个文件。

```bash
rm LICENSE book.toml
```

这个命令会删除`LICENSE`和`book.toml`这两个文件。

##### mv
`mv`是`move`的缩写。这个命令可以移动文件或者文件夹。

```bash
mv LICENSE book/
```

这个命令会将`LICENSE`文件移动到`book`文件夹下。

```bash
mv book/ book-old/
```

这个命令会将`book`文件夹**重命名**为`book-old`。Unix下没有专门的重命名命令，重命名就是移动。

##### cp

`cp`是`copy`的缩写。这个命令可以复制文件或者文件夹。其语法和`mv`类似。这里不再赘述。

```bash
cp LICENSE book/
```
把`LICENSE`文件复制到`book`文件夹下。

##### mkdir
`mkdir`是`make directory`的缩写。这个命令可以创建文件夹。

```bash
mkdir new-folder
```

这个命令会在当前工作目录下创建一个叫`new-folder`的文件夹。

###### 创建多级文件夹

```bash
mkdir -p new-folder/sub-folder
```

这个命令会创建一个叫`new-folder`的文件夹，然后在这个文件夹下创建一个叫`sub-folder`的文件夹。

##### touch

`touch`命令会创建一个空文件。

```bash
touch new-file
```

这个命令会在当前工作目录下创建一个叫`new-file`的文件。

#### 外部命令

常用的内部命令就以上这几个，它们覆盖了你在日常工作中的大部分需求。但是有时候你需要使用一些外部命令。

##### cat
`cat`是`concatenate`的缩写。这个命令会输出文件的内容。很多人认为`cat`是一个内建命令，但是它实际上是一个外部命令。

```bash
cat LICENSE
```

这个命令会输出`LICENSE`文件的内容。
例如：
```ascii
caiyi@archlinux ~/r/manual (use-git)> cat LICENSE 
MIT License

Copyright (c) 2024 NEUQ-CS

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

##### echo
`echo`命令会输出参数。

```bash
echo "Hello, World!"
```

这个命令会输出`Hello, World!`。

##### 其他命令

对于其他命令，只要它在环境变量`PATH`中，你就可以直接使用。使用`echo $PATH`，你可以看到`PATH`中包含了哪些路径。这些路径就是系统用来查找命令的路径。在这些路径下的**可执行文件**都可以直接使用。

我们使用的`git`命令就是一个外部命令。如果是 Unix 系统，git 在`/usr/bin`或者`/usr/local/bin`中会有一个链接指向真正的可执行文件。在 Windows 系统中，git 会被安装到`C:\Program Files\Git\bin`中或者你自己指定的路径。

如果你不知道一个命令是不是内建命令，你可以使用`which`命令来查找。

### 链接

在 Unix 系统中，有两种链接：符号链接（也叫软链接）和硬链接。

它们都是一种特殊的文件，它们**指向**另一个文件。软链接在 Windows 下叫做快捷方式。软链接在 Unix 下有两种，一种是符号链接，另一种是硬链接。符号链接是一种特殊的文件，它指向另一个文件。硬链接是一个文件的另一个名字。

指向意味着，当你访问这个链接时，实际上你访问的是被链接的文件。这样，你可以在不改变文件的情况下，改变文件的位置。同时，你也可以在不占用额外空间的情况下，创建一个文件的副本。

### 环境变量

环境变量是一种特殊的变量，它们是在操作系统启动时设置的。环境变量是一个键值对。键是环境变量的名字，值是环境变量的值。

对于新手来说，你只需要了解两个环境变量：`PATH`和`HOME`。

`PATH`是一个包含了系统用来查找命令的路径的变量。当你输入一个命令时，系统会在`PATH`中的路径下查找这个命令。如果找到了，就会执行这个命令。如果没有找到，就会提示`command not found`。

`HOME`是用户的家目录。在 Unix 系统中，用户的家目录一般是`/home/<用户名>`。前面说的`~`是家的别名是不准确的，事实上，它是`HOME`环境变量的值。如果你修改了`HOME`环境变量，`~`也会随之改变。

你可以使用`echo`命令来查看环境变量的值。

```bash
echo $PATH
```

'$'符号是一个特殊字符，它表示后面的是一个变量。在这个例子中，`$PATH`表示`PATH`环境变量的值。

在 C 语言中的完整main函数的形式是这样的：

```c
int main(int argc, char *argv[], char *envp[]) {
    // argc 是参数的数量
    // argv 是参数的数组
    // envp 是环境变量的数组
}
```

是的，这才是完整的main函数，它接受3个参数而不是大多数教程中的2个参数。

### 命令的选项
命令的选项也是一种参数，但是它们以`-`或者`--`开头。选项可以改变命令的行为。

`-`选项是单字母的选项，`--`选项是多字母的选项。

对于某些程序，例如`ls`，`-`选项可以合并，比如`-a -l`可以写成`-al`。

一般来说，对大部分程序使用`-h`或者`--help`选项可以查看帮助信息。

选项分为两种：有参数的选项和无参数的选项。有参数的选项后面需要跟一个参数，无参数的选项不需要。

上面提到的`--help`就是是无参数的选项。

例如，某款游戏可能接受`--fullscreen true`这样的选项，`--fullscreen`是有参数的选项，`true`是这个选项的参数。但是它们都是命令中的参数。

### 管道

管道是Unix中较为复杂的概念，在这里我只讲如何使用。

管道的作用是**重定向命令的输出**。你可以把一个命令的输出作为另一个命令的输入。也可以把一个命令的输出保存到文件中。

#### 重定向到另一个程序的标准输入

```bash
echo "Hello, World!" | cat
```

首先，`echo "Hello, World!"`会输出`Hello, World!`。然后，`|`会把这个输出重定向到`cat`命令的标准输入。`cat`会输出这个输入。所以输出还是`Hello, World!`。

#### 重定向到文件

```bash
echo "Hello, World!" > hello.txt
```

这个命令会把`echo "Hello, World!"`的输出重定向到`hello.txt`文件中。`>`是重定向的符号。

现在你可以使用`cat`命令查看这个文件的内容。

```bash
cat hello.txt
```

#### 重定向到文件的末尾

```bash
echo "Hello, World!" >> hello.txt
```

这个命令会把`echo "Hello, World!"`的输出**追加**到`hello.txt`文件的末尾。`>>`是追加重定向的符号。
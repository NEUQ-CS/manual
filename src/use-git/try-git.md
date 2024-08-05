# Git 入门

在了解了命令行的基本操作后，我们来尝试使用 Git。这部分的内容是命令和原理结合的，你可以在这里学到 Git 的基本操作和 Git 的工作原理。

## 将一个文件夹变成一个 Git 仓库

Git 仓库的本质是一个文件夹。所以，我们可以将一个文件夹变成一个 Git 仓库。

你可以输入以下命令，把当前文件夹变成一个 Git 仓库：
```bash
git init
```

或者，你可以输入以下命令，把指定文件夹变成一个 Git 仓库：
```bash
git init path/to/folder
```

Git 仓库和普通文件夹的区别在于，Git 仓库中有一个隐藏的`.git`文件夹，这个文件夹中存储了 Git 的所有信息，包括所有的git object，ref等。在任何情况下，你都不要应该修改`.git`文件夹中任何的内容。唯一的例外是`.git/config`文件，这个文件存储了当前仓库的配置信息，例如远程仓库的地址等。但是你也应该谨慎修改这个文件或者使用`git config`命令修改配置。

如果你不小心把一个文件夹变成了 Git 仓库[^1]，直接删除`.git`文件夹就可以了。使用以下命令即可：
```bash
rm -rf .git
```

[^1]:去年有人才把整个C盘或者桌面都变成了Git仓库。

Git 在操作 Git 仓库时，会递归的从当前文件夹向上查找`.git`文件夹，直到找到**第一个**`.git`文件夹或者到达文件系统的根目录。所以，你可以在任何一个 Git 仓库的子文件夹中使用 Git 命令。当 Git 仓库嵌套时，Git 会使用离当前文件夹最近的`.git`文件夹。

## 查看 Git 仓库的状态

在一个 Git 仓库中，你可以使用以下命令查看当前仓库的状态：
```bash
git status
```

你会看到以下输出：
```
On branch master
Your branch is up to date with 'origin/use-git'.

Changes to be committed:
  (use "git restore --staged <file>..." to unstage)
        modified:   src/use-git/configure.md

Untracked files:
  (use "git add <file>..." to include in what will be committed)
        src/use-git/try-git.md

```

当前在分支`master`上，你的分支是最新的。`Changes to be committed`中列出了你修改的文件，`Untracked files`中列出了你新建的文件。

### Git 工作原理

在继续尝试前，我们先来了解一下 Git 的工作原理，你可能已经对上面的输出感到迷惑了。

<!-- TODO -->
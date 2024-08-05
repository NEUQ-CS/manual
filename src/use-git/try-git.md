# Git 入门

在了解了命令行的基本操作后，我们来尝试使用 Git。这部分的内容是命令和原理结合的，你可以在这里学到 Git 的基本操作和 Git 的工作原理。

获得一个 Git 仓库的方法有两种，一种是“将一个文件夹变成 Git 仓库”，一种是从远程**克隆**一个 Git 仓库。

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

[^1]: 去年有人才把整个C盘或者桌面都变成了Git仓库。

```bash
rm -rf .git
```


Git 在操作 Git 仓库时，会递归的从当前文件夹向上查找`.git`文件夹，直到找到**第一个**`.git`文件夹或者到达文件系统的根目录。所以，你可以在任何一个 Git 仓库的子文件夹中使用 Git 命令。当 Git 仓库嵌套时，Git 会使用离当前文件夹最近的`.git`文件夹。

## 克隆远程仓库

要从远程克隆仓库首先要确保你具有权限，对于 GitHub，GitLab, Bitbucket等代码托管平台的公开仓库，任何人都具有权限，因此可以直接克隆。对于私有仓库，你需要一个具有读取权限的平台账号，然后将平台账户和你的 SSH 密钥绑定。

具有权限后，就能够克隆仓库了，使用以下命令即可：
```bash
git clone https://github.dev/NEUQ-CS/manual.git
```

记得将仓库地址更换成你想克隆的仓库的地址。克隆结束后，在**当前目录**下会产生一个与仓库名一致的文件夹，在本例中，是`manual`。
这个仓库就是你克隆的 Git 仓库。

`clone`命令还有一些其他参数可以使用

#### 克隆到指定文件夹

在地址后面加上指定路径即可：
```bash
git clone https://github.dev/NEUQ-CS/manual.git path/to/repo
```

注意，仓库里的文件会直接存在你指定的文件夹里面，而不是在你指定的目录里放仓库文件夹。

#### 克隆指定分支

加上参数`-b <分支名>`即可，例如:
```bash
git clone https://github.dev/NEUQ-CS/manual.git -b master
```

这将指定需要克隆master分支.

需要说明的是，即使你选择了一个分支，整个仓库的所有分支都实质上会被克隆下来，只是克隆完成后位于指定分支。

#### 指定克隆深度

使用`--depth <深度>`来指定克隆深度：
```bash
git clone https://github.dev/NEUQ-CS/manual.git --depth=1
```

仅克隆主分支上包含最新一个提交的完整仓库，克隆的仓库**不含有**任何历史记录。不推荐使用，除非你只是为了临时下载代码并且不需要历史记录和其他分支。

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

在一个 Git 仓库的文件夹中，一个文件可能存在以下三种状态的其中一种：
- 未跟踪　Untracked
- 已跟踪  Tracked
- 暂存中  Staged

#### 未跟踪
当你使用 `git init`初始化一个仓库时，原有的所有文件都是**未跟踪**。Git **不会**管理任何未跟踪的文件，但是这个文件仍然存在于这个文件夹中。*不会管理*的意思在于，当你通过 git 操作仓库的状态时，未跟踪的文件不会被修改或删除。如果一定会造成修改[^2]，git 会阻止这次操作，直到你解决完冲突。

[^2]: 比如你有一个未跟踪的a.txt，然后你通过切换到另一个分支，合并另一个分支，拉取远程尝试覆盖（其他分支上存在已跟踪的a.txt）这个文件时，Git 会阻止这次操作。

#### 已跟踪
这应该是仓库中大部分文件存在的状态。当你刚远程克隆完一个仓库时，所有文件都处于已跟踪状态。这是显然的，因为只有被跟踪的文件才会被提交到远程服务器。

##### 跟踪未跟踪的文件
要把一个未跟踪的文件变为已跟踪状态的方法是，先添加到**暂存区**，然后再commit。以下是命令行教程
```bash
# 添加a_new_file到暂存区
git add a_new_file
# commit在暂存区的所有文件
git commit -m "add `a_new_file` to this repo"
```

##### 将已跟踪的文件删除
你可以使用`git rm <文件>来删除，这会直接把删除操作直接添加到暂存区，文件系统上的文件也会被删除。它等价于以下操作：
```bash
rm an_old_file
git add an_old_file
```

要取消跟踪一个文件，但希望在文件系统上保留这个文件，使用`git rm --cached file`

#### 暂存中
准确地说，暂存的不是文件，是操作。通常来说，可以暂存
- 修改 Modify/Update
- 添加 Add
- 删除 delete
- 移动 Move

这几种操作。

当你在文件系统上修改一个文件，然后用`git add`的时候会暂存一个`修改`操作到暂存区。
当你在文件系统上添加一个文件，然后用`git add`的时候会暂存一个`添加`操作到暂存区。
当你在文件系统上删除一个文件，然后用`git add`的时候会暂存一个`删除`操作到暂存区。
当你在文件系统上移动或重命名一个文件，然后用`git add`的时候会暂存一个`移动`操作到暂存区。

将操作从暂存区撤出，使用以下命令：
```bash
git restore --staged file
```

对于这些状态的理解，我推荐使用Visual studio code的内置Git功能进行观察，他是Git的一个前端。可以代替手动的命令行，但是，就我个人而言，更会倾向使用命令行，因为这些前端**不支持**较为复杂的操作。

现在我们再来看这段输出：
```ascii
On branch master
Your branch is up to date with 'origin/use-git'.

Changes to be committed:
  (use "git restore --staged <file>..." to unstage)
        modified:   src/use-git/configure.md

Untracked files:
  (use "git add <file>..." to include in what will be committed)
        src/use-git/try-git.md

```

Changes to be committed部分就是存在于暂存区的文件，当我们使用`git commit`的时候，就会跟踪并把这些文件添加到git仓库。

Untracked files是前文说过的未跟踪文件，这是因为这个文件才创建，当使用`git add`来添加时，会在暂存区添加一个`添加`操作。

#### 代码提交

代码提交使用`git commit`命令，提交的时候需要一段简短的话描述你的这次修改。同时，你的姓名，邮箱也会被记录在这条commit记录中。

关于如何编写commit信息，我会在后面讲解良好的git使用习惯时讲到。

`git commit`命令常用的形式有以下两种：
1. 将信息作为参数直接提交
```bash
git commit -m "<提交信息>"
```

2. 使用代码编辑器编写提交信息
```bash
git commit -a
```

这会打开你在安装时选择的代码编辑器，信息编写完成后，保存关闭即可。

有时候，你觉得提交信息写的不好，打算重写编写提交信息时，可以采用以下命令：
```bash
git commit --amend -m "<提交信息>"
```
或者使用编辑器
```bash
git commit --amend -a
```

这会完全重新提交一次commit并获得不同的commit哈希[^3]，以及时间戳。

[^3]: 还记得 Git 是去中心化这句话吗？使用哈希来描述对象是去中心化的典型特征。哈希是指向去中心化网络中的一个指针，具有这个指针就能够访问到这个对象，当没有人持有哈希时，这个对象就*视为*被删除，但是这个对象本身实际上不能被删除，它仍存在于去中心化网络中。Git 的commit也是，这也就意味着，当你在GitHub上删除一个仓库，分支时，它实际上从未被删除，也不能够被删除。

使用`git commit --amend`的操作等价于以下操作：
```bash
# 保留修改回到上一次提交
git reset --soft "HEAD^"
# 重新提交
git commit -m "<提交信息>"
```
我个人更喜欢这种方法，因为更为灵活，你可以在重新提交过程中做一些修改。

### 分支
<!-- TODO -->
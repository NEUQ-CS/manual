---
title: 安装
type: docs
weight: 2
---

## GNU/Linux

大部分发行版默认都安装了 Vim，能够直接使用，为了防止特殊情况，教程再针对常用发行版说明。

- pacman 系（ArchLinux、Manjaro 等）：

```bash
sudo pacman -S vim
```

- apt 系（Ubuntu、Debian 等）：

```bash
sudo apt install vim
```

- rpm 系（RedHat、Fedora 等）：

```bash
sudo dnf install vim
```

- openSUE：

```bash
sudo zypper install vim
```

- Gentoo

```bash
我相信你会安装
```

- 对于其他 Linux 发行版，可能需要手动编译最新版本的 Vim （包管理器有就不要编译！）：

```bash {filename="Terminal"}
git clone https://github.com/vim/vim.git
cd vim/src
make
make test
make install
```

## Windows

不满足教程的环境要求，你有以下选择：

- 使用 WSL 或 VMware 等虚拟机的方式创造 GNU/Linux 环境。

- 使用 NeoVim for Windows 代替（NeoVim 兼容 Vim），具体参考[NeoVim Docs](https://github.com/neovim/neovim/blob/master/INSTALL.md#windows)。

## macOS

如果没有安装 [`Homebrew`](https://brew.sh) ，则先安装：

```zsh {filename="Terminal"}
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
```

安装 Vim：

```zsh {filename="Terminal"}
brew install vim
vim --version
```
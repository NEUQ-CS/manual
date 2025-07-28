# NEUQ Computer Science Survival Manual

[![License](https://img.shields.io/badge/license-MIT-blue)](LICENSE)
[![Hugo](https://img.shields.io/badge/Hugo-v0.148-orange)](https://gohugo.io/)

🌐 **Live Site**: [null](null)

## Local Development

### Prerequisites

- [Hugo](https://gohugo.io/installation/) (Extended version)
- [Go](https://golang.org/dl/) 1.21+

1. **Clone the repository**
   ```bash
   git clone https://github.com/Yttehs-HDX/neuq-manual.git
   cd neuq-manual
   ```

2. **Install dependencies**

   ```bash
   hugo mod get
   ```

3. **Start development server**

   ```bash
   make preview
   # or
   hugo server -D
   ```

4. **Access local site**

   Open your browser and visit [`http://localhost:1313`](http://localhost:1313)

## Build and Deploy

```bash
# Build production version
make build
# or
hugo --minify

# Clean build files
make clean
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Disclaimer

This software is for educational and communication purposes only. For other uses, such as commercial or research purposes, please obtain team approval. Users bear legal responsibility and the author is not liable.

---

**Tip**: If you find this project helpful, please give it a ⭐ Star to show your support!

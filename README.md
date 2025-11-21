# petikvx.github.io

Blog personnel créé avec Jekyll et GitHub Pages.

## 🎨 Thème

Le blog utilise un **thème moderne "Matrix/Cybersecurity"** avec :

- **Design sombre élégant** : Palette de couleurs inspirée du style Matrix (vert néon #00ff41 sur fond sombre)
- **Typographie professionnelle** : Police Fira Code pour un rendu optimal du code
- **Animations fluides** : Effets de glow, transitions et animations au survol
- **Header sticky** : Navigation qui reste visible lors du défilement
- **Cards interactives** : Articles avec effets de transformation au hover
- **Blocs de code stylisés** : Coloration syntaxique avec bordures accent
- **Scrollbar personnalisée** : Design cohérent avec le thème Matrix
- **Responsive design** : Optimisé pour tous les appareils (desktop, tablette, mobile)
- **Effets visuels** : Bordures animées, effets lumineux et ombres portées

Le design allie l'esthétique cyberpunk à l'ergonomie moderne pour une expérience de lecture immersive.

## 🚀 Fonctionnalités

- Blog avec articles en Markdown (.MD)
- Design responsive et moderne
- Navigation simple et intuitive
- Support complet de la syntaxe Markdown
- Système de tags pour les articles
- Navigation entre articles (précédent/suivant)

## 📝 Comment ajouter un nouvel article

1. Créez un nouveau fichier dans le dossier `_posts/`
2. Nommez-le selon le format: `YYYY-MM-DD-titre-de-votre-article.md`
3. Ajoutez le front matter YAML en haut du fichier:

```markdown
---
layout: post
title: "Titre de votre article"
date: 2025-11-20 10:00:00 +0000
author: Votre nom
tags: [tag1, tag2, tag3]
---

Votre contenu en Markdown ici...
```

4. Écrivez votre article en utilisant la syntaxe Markdown
5. Commitez et poussez vos changements sur GitHub
6. Votre article sera automatiquement publié!

## 🎨 Structure du projet

```
petikvx.github.io/
├── _config.yml           # Configuration du site
├── _layouts/             # Templates HTML
│   ├── default.html      # Layout principal
│   └── post.html         # Layout pour les articles
├── _posts/               # Articles du blog (Markdown)
│   ├── 2025-11-20-bienvenue-sur-mon-blog.md
│   ├── 2025-11-19-introduction-au-markdown.md
│   └── 2025-11-18-premiers-pas-avec-github-pages.md
├── assets/
│   └── css/
│       └── style.css     # Feuille de style
├── index.html            # Page d'accueil
├── blog.html             # Page listant tous les articles
└── README.md             # Ce fichier

```

## 🛠️ Configuration

Modifiez le fichier `_config.yml` pour personnaliser votre blog:

- `title`: Le titre de votre blog
- `description`: La description de votre blog
- `author`: Votre nom
- `email`: Votre adresse email
- `url`: L'URL de votre site

## 📖 Syntaxe Markdown supportée

- Titres (`#`, `##`, `###`, etc.)
- Emphase (`*italique*`, `**gras**`)
- Listes (ordonnées et non-ordonnées)
- Liens et images
- Code (inline et blocs)
- Citations (`>`)
- Tableaux
- Et plus encore!

## 🌐 Accès au blog

Votre blog sera accessible à l'adresse: `https://petikvx.github.io`

## 📚 Resources

- [Documentation Jekyll](https://jekyllrb.com/docs/)
- [Guide Markdown](https://www.markdownguide.org/)
- [GitHub Pages Documentation](https://docs.github.com/en/pages)

## 📄 Licence

Ce projet est open source et disponible sous licence MIT.
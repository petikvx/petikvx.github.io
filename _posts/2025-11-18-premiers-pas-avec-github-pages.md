---
layout: post
title: "Premiers pas avec GitHub Pages"
date: 2025-11-18 09:00:00 +0000
author: petikvx
tags: [github, web, tutoriel, hébergement]
---

GitHub Pages est un service d'hébergement gratuit qui permet de publier des sites web statiques directement depuis un dépôt GitHub. C'est l'outil parfait pour créer un blog, un portfolio ou une page de documentation.

## Qu'est-ce que GitHub Pages?

GitHub Pages est un service gratuit qui transforme vos dépôts GitHub en sites web. Il supporte:

- **HTML/CSS/JavaScript**: Pour les sites statiques classiques
- **Jekyll**: Pour générer des sites à partir de Markdown
- **Domaines personnalisés**: Vous pouvez utiliser votre propre nom de domaine
- **HTTPS**: Sécurité gratuite pour votre site

## Comment créer votre premier site?

### Étape 1: Créer un dépôt

Créez un nouveau dépôt sur GitHub avec le nom `username.github.io` (remplacez `username` par votre nom d'utilisateur).

### Étape 2: Ajouter du contenu

Créez un fichier `index.html` ou `index.md` dans votre dépôt:

```html
<!DOCTYPE html>
<html>
<head>
    <title>Mon site</title>
</head>
<body>
    <h1>Bienvenue sur mon site!</h1>
</body>
</html>
```

### Étape 3: Publier

Commitez et poussez vos changements. Votre site sera disponible à `https://username.github.io` en quelques minutes!

## Utiliser Jekyll

Jekyll est un générateur de sites statiques intégré à GitHub Pages. Il permet de:

- Écrire des articles en Markdown
- Utiliser des templates et des layouts
- Gérer automatiquement les URLs et la navigation
- Créer un blog sans base de données

### Structure d'un projet Jekyll

```
mon-blog/
├── _config.yml      # Configuration
├── _layouts/        # Templates HTML
├── _posts/          # Articles (Markdown)
├── _includes/       # Composants réutilisables
├── assets/          # CSS, JS, images
└── index.html       # Page d'accueil
```

## Avantages de GitHub Pages

- **Gratuit**: Aucun coût d'hébergement
- **Simple**: Pas de serveur à gérer
- **Versionné**: Tout l'historique est dans Git
- **Rapide**: CDN global pour une performance optimale
- **Sécurisé**: HTTPS automatique

## Limitations

- Sites statiques uniquement (pas de PHP, bases de données, etc.)
- Taille de dépôt limitée à 1 GB
- Bande passante limitée à 100 GB/mois
- Pas de backend dynamique

## Conclusion

GitHub Pages est une excellente solution pour héberger des sites statiques et des blogs. Combiné avec Jekyll, c'est un outil puissant et gratuit pour partager votre contenu en ligne!

Dans le prochain article, nous verrons comment personnaliser davantage votre blog Jekyll.

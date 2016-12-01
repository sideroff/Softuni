const icoPath = '/content/favicon.ico'
const cssPath = '/content/styles.css'

module.exports = (title) => {
    return `<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>${title}</title>
    <link rel="icon" href="${icoPath}">
    <link rel="stylesheet" type="text/css" href="${cssPath}">
    <script src="/content/scripts.js"></script>
</head>
<body>
    <header>
        <a href="/create">Create</a>
        <a href="/all">List All Todos</a>
    </header>`
}
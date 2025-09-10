// Tema anahtarı
(function () {
    const html = document.documentElement;
    const key = "qrmenu-theme";
    const saved = localStorage.getItem(key);
    if (saved) { html.setAttribute("data-theme", saved); }

    const btn = document.getElementById("themeToggle");
    if (btn) {
        btn.addEventListener("click", () => {
            const next = html.getAttribute("data-theme") === "dark" ? "light" : "dark";
            html.setAttribute("data-theme", next);
            localStorage.setItem(key, next);
        });
    }
})();

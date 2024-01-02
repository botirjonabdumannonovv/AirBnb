export class AppThemeService {
    public isDarkMode(): boolean {
        if(localStorage.getItem("darkMode") !== null)
            return localStorage.getItem("darkMode") === "true";

        return window.matchMedia("(prefers-color-scheme: dark)").matches
    }

    public toggleDarkMode(): void {
        document.body.classList.toggle("dark");
        const dakMode= localStorage.getItem("darkMode") !== null ? localStorage.getItem("darkMode") == "true" : false;
        localStorage.setItem("darkMode", (!dakMode).toString());
    }

    public setAppTheme(): void {
        if (this.isDarkMode()) {
            document.body.classList.add("dark");
        } else {
            document.body.classList.remove("dark");
        }

        localStorage.setItem("darkMode", this.isDarkMode.toString());
    }
}
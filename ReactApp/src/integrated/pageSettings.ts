// The server embeds the page settings as JSON in the Razor shell (Views/Shared/ReactDocument.cshtml).
export interface PageSettings {
  configurationUrl: string
}

export const settings = JSON.parse(document.getElementById('react-config')!.textContent!) as PageSettings